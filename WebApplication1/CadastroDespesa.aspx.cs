using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
namespace WebApplication1
{
    public partial class CadastroDespesa : System.Web.UI.Page
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
            List<Despesas> lista = Repositorio.ObterDespesas();
            if (lista != null && lista.Count > 0)
            {
                gvdespesas.DataSource = lista;
                gvdespesas.DataBind();
                gvdespesas.Visible = true;
                botoes.Visible = true;
            }
            else
            {
                gvdespesas.Visible = false;
                botoes.Visible = false;
            }
        }

        protected void Btn_salvar(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtvalor.Text, out decimal valor))
                {
                    lblMensagem.Text = $"Valor inválido.";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!int.TryParse(txtprojetoid.Text, out int projetoId))
                {
                    lblMensagem.Text = $"ID do projeto inválido.";
                    lblMensagem.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                Despesas despesa = new Despesas();
                despesa.Descricao = txtdescricao.Text;
                despesa.Valor = valor;
                despesa.Categoria = ddlcategoria.SelectedValue;
                despesa.ProjetoID = projetoId;
                Repositorio.AdicionarDespesa(despesa);
                Mostrar_Lista();
                lblMensagem.Text = $"salvo com sucesso";
                lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;
                Limpar();
            }
            catch (Exception)
            {
                lblMensagem.Text = $"erro";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Limpar()
        {
            txtdescricao.Text = "";
            txtvalor.Text = "";
            ddlcategoria.SelectedIndex = 0;
            txtprojetoid.Text = "";
        }

        protected void Btn_Limpar(object sender, EventArgs e)
        {
            Limpar();
        }

        protected void Btn_Filtrar(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();
            var resultado = Repositorio.ObterDespesas()
                .Where(x => x.Descricao.Contains(filtro) ||
                            x.Categoria.Contains(filtro))
                .ToList();
            gvdespesas.DataSource = resultado;
            gvdespesas.DataBind();
        }
    }
}