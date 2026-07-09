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
        private static List<Bolsista> listaBolsista = new List<Bolsista>()
        {
            new Bolsista
            {
                Nome = "Ana Beatriz Souza",
                CPF = "123.456.789-01",
                Matricula = "2024001",
                DataNascimento = new DateTime(2002, 3, 15),
                Sexo = "Feminino"
            },
            new Bolsista
            {
                Nome = "Bruno Henrique Lima",
                CPF = "234.567.890-12",
                Matricula = "2024002",
                DataNascimento = new DateTime(2001, 7, 22),
                Sexo = "Masculino"
            },
            new Bolsista
            {
                Nome = "Carla Mendes Oliveira",
                CPF = "345.678.901-23",
                Matricula = "2024003",
                DataNascimento = new DateTime(2003, 1, 10),
                Sexo = "Feminino"
            },
            new Bolsista
            {
                Nome = "Diego Santos Ferreira",
                CPF = "456.789.012-34",
                Matricula = "2024004",
                DataNascimento = new DateTime(2000, 11, 5),
                Sexo = "Mmasculino"
            },
            new Bolsista
            {
                Nome = "Eduarda Costa Almeida",
                CPF = "567.890.123-45",
                Matricula = "2024005",
                DataNascimento = new DateTime(2002, 9, 28),
                Sexo = "Feminino"
            }
        };

        protected void Mostrar_Lista()
        {
            if (listaBolsista.Count > 0)
            {
                gvAlunos.DataSource = listaBolsista;
                gvAlunos.DataBind();
                gvAlunos.Visible = true;
            }
            else { gvAlunos.Visible = false; }
            
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
                listaBolsista.Add(aluno);
                Mostrar_Lista();

                string salvo = aluno.ObterResumo();
                int idade = aluno.CalcularIdade();

                lblMensagem.Text = $"salvo com sucesso {salvo} {idade}";
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
    }
}