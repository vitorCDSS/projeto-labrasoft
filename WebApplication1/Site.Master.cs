using System;

namespace WebApplication1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is usuario1)
            {
                pnlMenu.Visible = false;
            }
            else
            {
                pnlMenu.Visible = true;
            }
        }
    }
}