using System;
using System.Web.UI;
using WebApplication1.Models;
using BCrypt.Net;

namespace WebApplication1
{
    public partial class usuario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

    protected void Btn_salvar(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();

                usuario.Nome = txtnomeusuario.Text;
                usuario.Email = txtemail.Text;
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(txtsenha.Text);

                Repositorio.AdicionarUsuario(usuario);

                lblMensagem.Text = "Salvo com sucesso!";
                lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;

                Limpar();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao salvar: " + ex.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Limpar()
        {
            txtnomeusuario.Text = "";
            txtemail.Text = "";
            txtsenha.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            mvLoginCadastro.ActiveViewIndex = 0;
            lblMensagem.Text = "";
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            mvLoginCadastro.ActiveViewIndex = 1;
            lblMensagem.Text = "";
        }

        protected void Btn_Entrar(object sender, EventArgs e)
        {
            string email = txtEmailLogin.Text.Trim();
            string senha = txtSenhaLogin.Text;

            bool loginValido = Repositorio.VerificarLogin(email, senha);

            if (loginValido)
            {
                lblMensagem.Text = "Login realizado com sucesso!";
                lblMensagem.ForeColor = System.Drawing.Color.DarkGreen;
                Response.Redirect("CadastroBolsista.aspx");
            }
            else
            {
                lblMensagem.Text = "E-mail ou senha incorretos.";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

}
