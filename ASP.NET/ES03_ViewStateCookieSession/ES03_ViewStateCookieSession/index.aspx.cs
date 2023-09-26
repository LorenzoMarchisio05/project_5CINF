using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ES03_ViewStateCookieSession
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                init();
            }
            else
            {
                page_load();
            }
        }

        private void init()
        {

        }

        private void page_load()
        {
            
        }

        protected void btnViewState_Click(object sender, EventArgs e)
        {
            ViewState.Add("viewState", "Ciao sono una view state");
        }

        protected void btnCookie_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("cookie")
            {
                Value = "Ciao sono un cookie",
                Expires = DateTime.Now.AddDays(10),
            });
        }

        protected void btnSession_Click(object sender, EventArgs e)
        {
            Session.Add("session", "Ciao sono una sessione");
        }

        protected void btnVediOggetti_Click(object sender, EventArgs e)
        {
            Response.Write($"ViewState: { ViewState["viewState"] } <br />");

            Response.Write($"Cookie: { Request.Cookies["cookie"]?.Value } <br />");

            Response.Write($"Session: { Session["session"] } <br />");

            Response.Write($"Session ID: { Session.SessionID } <br />");
        }
    }
}