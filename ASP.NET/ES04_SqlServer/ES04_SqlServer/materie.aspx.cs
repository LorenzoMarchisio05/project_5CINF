using ES04_SqlServer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ES04_SqlServer
{
    public partial class materie : System.Web.UI.Page
    {
        private static MaterieController _materieController = new MaterieController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
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
            cmbMaterie.DataSource = _materieController.fetchMaterie();
            cmbMaterie.DataValueField = "idMateria";
            cmbMaterie.DataTextField = "materia";
            cmbMaterie.DataBind();

            load();
        }
    }
}