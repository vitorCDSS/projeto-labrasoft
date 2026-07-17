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
            ddlcoordenador.DataSource = Repositorio.listaCoordenador;
            ddlcoordenador.DataTextField = "Nome";
            ddlcoordenador.DataValueField = "CPF";            
            ddlcoordenador.DataBind();
            ddlcoordenador.Items.Insert(0, new ListItem("selecione o coordenador", ""));
            
            lstBolsistas.DataSource = Repositorio.listaBolsista;
            lstBolsistas.DataTextField = "Nome";
            lstBolsistas.DataValueField = "CPF";
            lstBolsistas.DataBind();
            //lstBolsistas.Items.Insert(0, new ListItem("selecione os bolsistas", ""));
            if (Repositorio.listaProjetos.Count > 0)
            {
                gvProjetos.DataSource = Repositorio.listaProjetos;
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
                Projeto projeto = new Projeto();

                projeto.Titulo = txttitulo.Text;

                projeto.VerbaAprovada = decimal.Parse (txtverba.Text);
                projeto.ValorDaBolsa = decimal.Parse(txtvalor.Text);
                //pesquisar um metódo que garanta a escrita de apenas números!
                projeto.AreaDeConhecimento = txtarea.Text;
                string CPFcord = ddlcoordenador.SelectedValue;
                projeto.coordenador = Repositorio.listaCoordenador.FirstOrDefault(c => c.CPF == CPFcord);
                string CPFbol = lstBolsistas.SelectedValue;
                foreach (ListItem item in lstBolsistas.Items)
                {
                    if (item.Selected)
                    {
                        Bolsista bolsista = Repositorio.listaBolsista
                            .FirstOrDefault(b => b.CPF == item.Value);

                        if (bolsista != null)
                        {
                            projeto.Bolsista.Add(bolsista);
                        }
                    }
                }
                Repositorio.listaProjetos.Add(projeto);
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

        protected void Btn_Filtrar(object sender, EventArgs e)
        {
            gvProjetos.DataSource = Repositorio.listaProjetos.Where(x => x.AreaDeConhecimento == "ADS").ToList();
            gvProjetos.DataBind();
        }

        protected void Btn_Ordenar(object sender, EventArgs e)
        {
            gvProjetos.DataSource = Repositorio.listaProjetos.OrderBy(x => x.Titulo).ToList();
            gvProjetos.DataBind();
        }
        protected void Btn_Desfazer_Alteracoes(object sender, EventArgs e)
        {
            gvProjetos.DataSource = Repositorio.listaProjetos;
            gvProjetos.DataBind();
        }
    }
}