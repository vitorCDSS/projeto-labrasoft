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
            ddlcoordenador.DataValueField = "ID";
            ddlcoordenador.DataBind();

            ddlcoordenador.Items.Insert(
                0,
                new ListItem("selecione o coordenador", "")
            );

            lstBolsistas.DataSource =
                Repositorio.ObterBolsistasSemProjeto();

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
                Projeto projeto = new Projeto();

                projeto.Titulo = txttitulo.Text;
                projeto.VerbaAprovada = Convert.ToDecimal(txtverba.Text);
                projeto.ValorBolsaIndividual = Convert.ToDecimal(txtvalor.Text);
                projeto.AreaConhecimento = txtarea.Text;

                projeto.CoordenadorID = Convert.ToInt32(ddlcoordenador.SelectedValue);

                int novoProjetoId = Repositorio.AdicionarProjeto(projeto);

                lblMensagem.Text = "Salvo com sucesso!";
                lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;

                Limpar();

                Response.Redirect("CadastroProjeto.aspx");
            }
            catch (Exception)
            {
                lblMensagem.Text = "Erro ao salvar o projeto.";
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

                hfProjetoID.Value = projeto.ID.ToString();

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

                bltDespesas.Items.Clear();

                var despesasDoProjeto = Repositorio.ObterDespesas()
                    .Where(d => d.ProjetoID == projeto.ID)
                    .ToList();

                if (despesasDoProjeto.Count > 0)
                {
                    foreach (Despesas d in despesasDoProjeto)
                    {
                        bltDespesas.Items.Add(
                            new ListItem($"{d.Descricao} - {d.Valor.ToString("C")}")
                        );
                    }
                }
                else
                {
                    bltDespesas.Items.Add(
                        new ListItem("Nenhuma despesa cadastrada para este projeto.")
                    );
                }

                pnlSelecionarBolsistas.Visible = false;

                pnlDetalhes.Visible = true;
            }
        }

        protected void btnFecharDetalhes_Click(object sender, EventArgs e)
        {
            pnlDetalhes.Visible = false;
        }

        protected void btnSelecionarBolsistas_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(hfProjetoID.Value))
                {
                    lblMensagem.Text = "Nenhum projeto selecionado.";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                int projetoId = Convert.ToInt32(hfProjetoID.Value);

                Projeto projeto = Repositorio.ObterProjetos()
                    .FirstOrDefault(p => p.ID == projetoId);

                if (projeto == null)
                {
                    lblMensagem.Text = "Projeto não encontrado.";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                gvBolsistas.DataSource = Repositorio.ObterBolsistasDisponiveis(projetoId);
                gvBolsistas.DataBind();

                pnlSelecionarBolsistas.Visible = true;
            }
            catch (Exception)
            {
                lblMensagem.Text = "Erro ao carregar os bolsistas.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        protected void btnCancelarBolsistas_Click(object sender, EventArgs e)
        {
            pnlSelecionarBolsistas.Visible = false;
        }

        protected void gvBolsistas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Alternar")
                return;

            try
            {
                int linha = Convert.ToInt32(e.CommandArgument);

                int bolsistaId = Convert.ToInt32(
                    gvBolsistas.DataKeys[linha].Value
                );

                int projetoId = Convert.ToInt32(hfProjetoID.Value);

                bool estaVinculado =
                    Repositorio.BolsistaEstaNoProjeto(
                        bolsistaId,
                        projetoId
                    );

                if (estaVinculado)
                {
                    Repositorio.RemoverBolsistaDoProjeto(
                        bolsistaId,
                        projetoId
                    );
                }
                else
                {
                    bool estaEmOutroProjeto =
                        Repositorio.BolsistaEstaEmOutroProjeto(
                            bolsistaId,
                            projetoId
                        );

                    if (estaEmOutroProjeto)
                    {
                        lblMensagem.Text =
                            "Este bolsista já está vinculado a outro projeto.";

                        lblMensagem.ForeColor =
                            System.Drawing.Color.Red;

                        return;
                    }

                    Repositorio.VincularBolsistaAoProjeto(
                        bolsistaId,
                        projetoId
                    );
                }

                gvBolsistas.DataSource =
                    Repositorio.ObterBolsistasDisponiveis(projetoId);

                gvBolsistas.DataBind();

                lblMensagem.Text =
                    "Alteração realizada com sucesso.";

                lblMensagem.ForeColor =
                    System.Drawing.Color.DarkGreen;
            }
            catch (Exception)
            {
                lblMensagem.Text =
                    "Erro ao alterar o bolsista.";

                lblMensagem.ForeColor =
                    System.Drawing.Color.Red;
            }
        }

        protected string ObterTextoBotao(object dataItem)
        {
            Bolsista bolsista = (Bolsista)dataItem;

            int projetoId = Convert.ToInt32(hfProjetoID.Value);

            bool estaVinculado =
                Repositorio.BolsistaEstaNoProjeto(
                    bolsista.ID,
                    projetoId
                );

            return estaVinculado ? "remover" : "adicionar";
        }
    }
}