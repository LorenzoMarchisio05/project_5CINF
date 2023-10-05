using ES04_SqlServer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ES04_SqlServer
{
    public partial class Alunni : System.Web.UI.Page
    {
        private static readonly AlunniController _alunniController = new AlunniController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                load();
            }
            else
            {
                init();
            }
        }

        private void load()
        {
            
        }

        private void init()
        {
            cmbAlunni.DataSource = _alunniController.fetchAlunni();
            cmbAlunni.DataValueField = "idAlunno";
            cmbAlunni.DataTextField = "nominativo";
            cmbAlunni.DataBind();
            
            cmbAlunni.Items.Insert(0, new ListItem("Selezionare un alunno", "-1"));

            load();
        }

        protected void cmbAlunni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbAlunni.SelectedValue == "-1")
            {
                return;
            }

            Session.Add("idAlunno", cmbAlunni.SelectedValue);
            Session.Add("nominativo", cmbAlunni.SelectedItem.Text);
            Response.Redirect("voti.aspx");
        }
    }
}