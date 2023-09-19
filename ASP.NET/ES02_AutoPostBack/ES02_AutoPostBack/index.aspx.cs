using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ES02_AutoPostBack
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                postBack();
            }
            else
            {
                init();
            }
        }

        private void init()
        {
            chkAutoPostBack.AutoPostBack = true;
            cmbColori.Items.AddRange(new[]
            {
                    new ListItem("Rosso", "Red"),
                    new ListItem("Verde", "Green"),
                    new ListItem("Giallo", "Yellow"),
                    new ListItem("Blu", "Blue"),
                });
        }

        private void postBack()
        {

        }

        protected void cmbColori_SelectedIndexChanged(object sender, EventArgs e) => pnlColore.BackColor = Color.FromName(cmbColori.SelectedItem.Value);

        protected void chkAutoPostBack_CheckedChanged(object sender, EventArgs e) => cmbColori.AutoPostBack = chkAutoPostBack.Checked;
    }
}