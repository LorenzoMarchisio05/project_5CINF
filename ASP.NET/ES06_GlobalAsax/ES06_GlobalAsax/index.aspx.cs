using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ES06_GlobalAsax
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblContaVisite.Text = $"visite: {Application.Get("counterVisite").ToString()}";
            lblConteggioUtenti.Text = $"utenti: {Application.Get("counterUtenti").ToString()}";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("https://www.google.com");
        }
    }
}