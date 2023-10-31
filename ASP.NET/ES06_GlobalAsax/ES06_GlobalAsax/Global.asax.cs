using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ES06_GlobalAsax
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            if(int.TryParse(ConfigurationManager.AppSettings.Get("counterVisite"), out var counterVisite)) 
            {
                Application.Add("counterVisite", counterVisite);
            }

            Application.Add("counterUtenti", 0);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var counterVisite = Convert.ToInt32(Application["counterVisite"]);
            Application["counterVisite"] = counterVisite + 1;

            var counterUtenti = Convert.ToInt32(Application["counterUtenti"]);
            Application["counterUtenti"] = counterUtenti + 1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            var counterUtenti = Convert.ToInt32(Application["counterUtenti"]);
            Application["counterUtenti"] = counterUtenti - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {
           
        }
    }
}