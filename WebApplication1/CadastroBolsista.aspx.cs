using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CadastroBolsista : System.Web.UI.Page
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
            List<Bolsista> lista = Repositorio.ObterBolsistas();

            if (lista != null && lista.Count > 0)
            {
                gvAlunos.DataSource = lista;
                gvAlunos.DataBind();
                gvAlunos.Visible = true;
                botoes.Visible = true;
            }
            else
            {
                gvAlunos.Visible = false;
                botoes.Visible = false;
            }
        }

        protected void Btn_salvar(object sender, EventArgs e)
        {
            try
            {
                Bolsista aluno = new Bolsista();

                aluno.Nome = txtnome.Text;
                aluno.CPF = txtcpf.Text;
                aluno.Matricula = txtmatricula.Text;
                aluno.DataNascimento = DateTime.Parse(txtdata.Text);
                aluno.Sexo = ddlSexo.SelectedValue;

                Repositorio.AdicionarBolsista(aluno);

                Mostrar_Lista();

                string salvo = aluno.ObterResumo();
                int idade = aluno.CalcularIdade();

                lblMensagem.Text = $"Salvo com sucesso! {salvo} - Idade: {idade} anos.";
                lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;

                Limpar();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = $"Erro ao salvar: {ex.Message}";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Limpar()
        {
            txtnome.Text = "";
            txtcpf.Text = "";
            txtmatricula.Text = "";
            txtdata.Text = "";
            ddlSexo.SelectedIndex = 0;
        }

        protected void Btn_Limpar(object sender, EventArgs e)
        {
            Limpar();
            lblMensagem.Text = ""; 
        }

        protected void Btn_Filtrar(object sender, EventArgs e)
        {
            var listaFiltrada = Repositorio.ObterBolsistas()
                                           .Where(x => x.Sexo == "Feminino")
                                           .ToList();

            gvAlunos.DataSource = listaFiltrada;
            gvAlunos.DataBind();
        }

        protected void Btn_Ordenar(object sender, EventArgs e)
        {
            var listaOrdenada = Repositorio.ObterBolsistas()
                                           .OrderBy(x => x.Nome)
                                           .ToList();

            gvAlunos.DataSource = listaOrdenada;
            gvAlunos.DataBind();
        }

        protected void Btn_Desfazer_Alteracoes(object sender, EventArgs e)
        {
            Mostrar_Lista();
        }
    }
}