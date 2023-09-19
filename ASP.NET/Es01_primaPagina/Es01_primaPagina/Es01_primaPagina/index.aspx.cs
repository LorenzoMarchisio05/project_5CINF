using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es01_primaPagina
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLeggiASPNET_Click(object sender, EventArgs e)
        {
            lblLettoASPNET.Text = txtASPNET.Text;
        }

        protected void btnLeggiHTML_Click(object sender, EventArgs e)
        {
            //POST
            //lblLettoHTML.Text = Request.Form["txtHTML"];//N.B. devo mettere name="txtHTML" nel controllo html
            //ved pag 13 dispense
            //lblLettoHTML.Text = Request.ServerVariables.ToString();
            /*foreach (var sv in Request.ServerVariables)
            {
                lblLettoHTML.Text += sv.ToString() + " = " + 
                    Request.ServerVariables[sv.ToString()].ToString() + "<hr>";
            }
            */
            //lblLettoHTML.Text = Request.QueryString.ToString(); //GET
            //lblLettoHTML.Text = Request.Url.ToString();
            //lblLettoHTML.Text = Request.Headers.ToString();
            lblLettoHTML.Text = Request.HttpMethod.ToString();
        }
    }
}