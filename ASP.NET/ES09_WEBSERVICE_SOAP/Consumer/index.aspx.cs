using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consumer.View
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                cmbClassi.DataSource = new localhost.WebServiceSOAP().Classi();
                cmbClassi.DataValueField = "idClasse";
                cmbClassi.DataTextField = "classe";
                cmbClassi.DataBind();
            }
        }


    }
}