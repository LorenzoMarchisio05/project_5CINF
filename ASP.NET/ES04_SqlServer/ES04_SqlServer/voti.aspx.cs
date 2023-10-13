using ES04_SqlServer.Controller;
using ES04_SqlServer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ES04_SqlServer
{
    public partial class voti : System.Web.UI.Page
    {
        private static VotiController _votiController = new VotiController();
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
            if (string.IsNullOrEmpty(Session["idAlunno"]?.ToString()))
            {
                //var source = Request.Url.AbsolutePath.Substring(Request.Url.AbsolutePath.LastIndexOf('/') + 1);
                //Response.Redirect(source);
                return;
            }
            var idAlunno = Convert.ToInt32(Session["idAlunno"]);
            lblNominativo.Text = Session["nominativo"].ToString();

            caricaDgv(idAlunno);
        }

        private void init()
        {
            load();
        }

        public void caricaDgv(int idAlunno)
        {
            var voti = _votiController.fetchVoti(idAlunno);

            dgvVoti.DataSource = voti;
            dgvVoti.DataBind();
        }
    }
}