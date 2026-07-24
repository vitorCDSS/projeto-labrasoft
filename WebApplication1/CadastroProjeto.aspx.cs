using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CadastroProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mostrar_Lista();
            }
        }
        protected void Mostrar_Lista()
        {
            ddlcoordenador.DataSource = Repositorio.ObterCoordenadores();
            ddlcoordenador.DataTextField = "Nome";
            ddlcoordenador.DataValueField = "CPF";            
            ddlcoordenador.DataBind();
            ddlcoordenador.Items.Insert(0, new ListItem("selecione o coordenador", ""));
            
            lstBolsistas.DataSource = Repositorio.ObterBolsistas();
            lstBolsistas.DataTextField = "Nome";
            lstBolsistas.DataValueField = "CPF";
            lstBolsistas.DataBind();
            var lista = Repositorio.ObterProjetos();
            if (lista.Count > 0)
            {
                gvProjetos.DataSource = lista;
                gvProjetos.DataBind();
                gvProjetos.Visible = true;
                botoes.Visible = true;                
            }
            else
            {
                gvProjetos.Visible = false;
                botoes.Visible = false;
            }

        }
        protected void Btn_salvar(object sender, EventArgs e)
        {

            try
            {
                string CPFcord = ddlcoordenador.SelectedValue;
                Repositorio.ObterProjetos().Any(x => x.coordenador.CPF == CPFcord);
                {
                    lblMensagem.Text = $"coordenador já está vinculado a outro projeto.";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                foreach (ListItem item in lstBolsistas.Items)
                {
                    if (item.Selected)
                    {
                        bool bolsistaJaCadastrado = Repositorio.ObterProjetos().Any(p =>
                            p.Bolsista.Any(b => b.CPF == item.Value));

                        if (bolsistaJaCadastrado)
                        {
                            lblMensagem.Text = "Um dos bolsistas selecionados já está vinculado a outro projeto.";
                            lblMensagem.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }
                Projeto projeto = new Projeto();

                    projeto.Titulo = txttitulo.Text;

                    projeto.VerbaAprovada = decimal.Parse(txtverba.Text);
                    projeto.ValorBolsaIndividual = decimal.Parse(txtvalor.Text);
                    projeto.AreaConhecimento = txtarea.Text;
                    projeto.coordenador =
                        Repositorio.ObterCoordenadores()
                                   .FirstOrDefault(c => c.CPF == CPFcord);
                string CPFbol = lstBolsistas.SelectedValue;
                    foreach (ListItem item in lstBolsistas.Items)
                    {
                        if (item.Selected)
                        {
                            Bolsista bolsista = Repositorio.ObterBolsistas()
                                .FirstOrDefault(b => b.CPF == item.Value);

                            if (bolsista != null)
                            {
                                projeto.Bolsista.Add(bolsista);
                            }
                        }
                    }
                    Repositorio.ObterProjetos().Add(projeto);
                    Mostrar_Lista();
                    lblMensagem.Text = $"salvo com sucesso";
                    lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;
                    Limpar();
                    Response.Redirect("CadastroProjeto.aspx");
            }
            catch (Exception)
            {
                lblMensagem.Text = $"erro";
                lblMensagem.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void Limpar()
        {
            txttitulo.Text = "";
            txtverba.Text = "";
            txtvalor.Text = "";
            txtarea.Text = "";
            ddlcoordenador.SelectedIndex = 0;
            lstBolsistas.SelectedIndex = 0;
        }

        protected void Btn_Limpar(object sender, EventArgs e)
        {
            Limpar();
        }
        protected void Btn_FiltrarProjeto(object sender, EventArgs e)
        {
            string filtro = txtFiltroProjeto.Text.Trim().ToLower();

            var resultado = Repositorio.ObterProjetos().Where(x =>
                x.Titulo.ToLower().Contains(filtro) ||
                x.AreaConhecimento.ToLower().Contains(filtro) ||
                x.coordenador.Nome.ToLower().Contains(filtro)
            ).ToList();


            gvProjetos.DataSource = resultado;
            gvProjetos.DataBind();
        }
        protected void Btn_Ordenar(object sender, EventArgs e)
        {
            gvProjetos.DataSource = Repositorio.ObterProjetos().OrderBy(x => x.Titulo).ToList();
            gvProjetos.DataBind();
        }
        protected void Btn_Desfazer_Alteracoes(object sender, EventArgs e)
        {
            gvProjetos.DataSource = Repositorio.ObterProjetos();
            gvProjetos.DataBind();
        }
        protected void gvProjetos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalhar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);

                Projeto projeto = Repositorio.ObterProjetos()[indice];

                lblTitulo.Text = projeto.Titulo;
                lblVerba.Text = projeto.VerbaAprovada.ToString("C");
                lblBolsa.Text = projeto.ValorBolsaIndividual.ToString("C");
                lblArea.Text = projeto.AreaConhecimento;

                lblCoordenador.Text = projeto.coordenador.Nome;

                bltBolsistas.Items.Clear();

                foreach (Bolsista b in projeto.Bolsista)
                {
                    bltBolsistas.Items.Add(b.Nome);
                }

                pnlDetalhes.Visible = true;
            }
        }
        protected void btnFecharDetalhes_Click(object sender, EventArgs e)
        {
            pnlDetalhes.Visible = false;
        }
    }
}