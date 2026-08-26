using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        public static List<Despesas> ObterDespesas()
        {
            var lista = new List<Despesas>();
            string connStr = ConfigurationManager.ConnectionStrings["labrasoftT2"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT ID, Descricao, Valor, Categoria, ProjetoID FROM dbo.Despesas";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Despesas
                        {
                            ID = (int)reader["ID"],
                            Descricao = reader["Descricao"].ToString(),
                            Valor = (decimal)reader["Valor"],
                            Categoria = reader["Categoria"].ToString(),
                            ProjetoID = (int)reader["ProjetoID"]
                        });
                    }
                }
            }
            return lista;
        }

        public static void AdicionarDespesa(Despesas despesa)
        {
            string connStr = ConfigurationManager.ConnectionStrings["labrasoftT2"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"INSERT INTO dbo.Despesas (Descricao, Valor, Categoria, ProjetoID)
                        VALUES (@Descricao, @Valor, @Categoria, @ProjetoID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                cmd.Parameters.AddWithValue("@Valor", despesa.Valor);
                cmd.Parameters.AddWithValue("@Categoria", despesa.Categoria);
                cmd.Parameters.AddWithValue("@ProjetoID", despesa.ProjetoID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}