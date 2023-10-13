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

        private readonly Dictionary<string, Action<GridViewRow, DataKeyArray>> gridViewCommands;

        public Alunni()
        {
            gridViewCommands = new Dictionary<string, Action<GridViewRow, DataKeyArray>>(StringComparer.OrdinalIgnoreCase)
            {
                { "mostraDettagli",  mostraDettagli },
            };
        }


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

            dgvAlunni.DataSource = _alunniController.fetchAlunni();
            dgvAlunni.DataBind();

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

        protected void dgvAlunni_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;

            if(!gridViewCommands.TryGetValue(command, out var action))
            {
                Console.WriteLine("invalid command");
            }

            var rowIndex = Convert.ToInt32(e.CommandArgument);

            var row = dgvAlunni.Rows[rowIndex];

            action?.Invoke(row, dgvAlunni.DataKeys);
        }

        #region GridView Commands

        private void mostraDettagli(GridViewRow row, DataKeyArray dataKeys)
        {
            var idAlunno = dataKeys[0]?.Value;
            var nome = row.Cells[1].Text; 
            var cognome = row.Cells[2].Text;
            var nominativo = $"{nome} {cognome}";

            Session.Add("idAlunno", idAlunno);
            Session.Add("nominativo", nominativo);
            Response.Redirect("voti.aspx");
        }

        #endregion
    }
}