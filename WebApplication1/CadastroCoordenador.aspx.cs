using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class CadastroCoordenador : System.Web.UI.Page
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
            if (Repositorio.listaCoordenador.Count > 0)
            {
                gvcoordenador.DataSource = Repositorio.listaCoordenador;
                gvcoordenador.DataBind();
                gvcoordenador.Visible = true;
                botoes.Visible = true;
            }
            else
            {
                gvcoordenador.Visible = false;
                botoes.Visible = false;
            }
        }

        protected void Btn_salvar(object sender, EventArgs e)
        {
            try
            {
                Coordenador coordenador = new Coordenador();

                coordenador.Nome = txtnome.Text;
                coordenador.CPF = txtcpf.Text;
                coordenador.Titulação = ddltitulacao.SelectedValue;
                coordenador.AreaDeAtuação = txtareadeatuacao.Text;
                coordenador.Email = txtemail.Text;
                Repositorio.listaCoordenador.Add(coordenador);
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
            txtnome.Text = "";
            txtcpf.Text = "";
            ddltitulacao.SelectedIndex = 0;
            txtareadeatuacao.Text = "";
            txtemail.Text = "";
        }

        protected void Btn_Limpar(object sender, EventArgs e)
        {
            Limpar();
        }



        protected void Btn_Filtrar(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim();

            var resultado = Repositorio.listaCoordenador.Where(x =>
                 x.Nome.Contains(filtro) ||
                 x.Titulação.Contains(filtro)
             ).ToList();

            gvcoordenador.DataSource = resultado;
            gvcoordenador.DataBind();
        }
    }
}