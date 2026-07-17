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
            if (Repositorio.listaBolsista.Count > 0)
            {
                gvAlunos.DataSource = Repositorio.listaBolsista;
                gvAlunos.DataBind();
                gvAlunos.Visible = true;
                botoes.Visible = true;
            }
            else {
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
                Repositorio.listaBolsista.Add(aluno);
                Mostrar_Lista();

                string salvo = aluno.ObterResumo();
                int idade = aluno.CalcularIdade();

                lblMensagem.Text = $"salvo com sucesso {salvo} {idade}";
                lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;
                Limpar();
                Response.Redirect("CadastroBolsista.aspx");

            }
            catch (Exception)
            {
                lblMensagem.Text = $"erro";
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
        }

        protected void Btn_Filtrar(object sender, EventArgs e)
        {
            gvAlunos.DataSource = Repositorio.listaBolsista.Where(x => x.Sexo == "Feminino").ToList();
            gvAlunos.DataBind();
        }

        protected void Btn_Ordenar(object sender, EventArgs e)
        {
            gvAlunos.DataSource = Repositorio.listaBolsista.OrderBy(x => x.Nome).ToList();
            gvAlunos.DataBind();
        }
        protected void Btn_Desfazer_Alteracoes(object sender, EventArgs e)
        {
            gvAlunos.DataSource = Repositorio.listaBolsista;
            gvAlunos.DataBind();
        }
    }
}