using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ES03_ViewStateCookieSession
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Write($"ViewState: {ViewState["viewState"]} <br />");

                Response.Write($"Cookie: {Request.Cookies["cookie"]?.Value} <br />");

                Response.Write($"Session: {Session["session"]} <br />");

                Response.Write($"Session ID: {Session.SessionID} <br />");
            }
            catch (Exception ex)
            {
                Response.Write($"errore: {ex.Message} <br />");
            }
        }
    }
}