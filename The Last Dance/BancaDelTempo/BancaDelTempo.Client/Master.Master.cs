using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancaDelTempo.Client
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var email = Session["email"]?.ToString();

            if(string.IsNullOrEmpty(email))
            {
                lblUsername.Text = "";
                lblUsername.Visible = false;
            }
            else
            {
                lblUsername.Text = email;
                lblUsername.Visible = true;
            }
        }
    }
}