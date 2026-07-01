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
        protected void Btn_salvar(object sender, EventArgs e)
        {
            try
            {
                Bolsista aluno = new Bolsista();

                aluno.Nome = txtnome.Text;
                aluno.CPF = txtcpf.Text;
                aluno.Matricula = txtmatricula.Text;
                aluno.DataNascimento = DateTime.Parse(txtdata.Text);

                string salvo = aluno.ObterResumo();
                int idade = aluno.CalcularIdade();

                lblMensagem.Text = $"salvo com sucesso {salvo} {idade}";
                lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;
            }
            catch (Exception)
            {
                lblMensagem.Text = $"erro";
                lblMensagem.ForeColor = System.Drawing.Color.Red;

            }
            


        }
    }
}