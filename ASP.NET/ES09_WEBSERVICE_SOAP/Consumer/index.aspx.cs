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
                var service = new localhost.WebServiceSOAP();

                cmbClassi.DataSource = service.Classi();
                cmbClassi.DataValueField = "idClasse";
                cmbClassi.DataTextField = "classe";
                cmbClassi.DataBind();
            }
        }

        protected void cmbClassi_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = cmbClassi.SelectedValue;

            var service = new localhost.WebServiceSOAP();

            var datatable = service.Alunni(id);
        }
    }
}