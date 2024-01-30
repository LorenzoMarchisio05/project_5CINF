using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using BancaDelTempo.Controller;
using Newtonsoft.Json;

namespace BancaDelTempo.Client
{
    public partial class login : System.Web.UI.Page
    {
        private readonly string webService = "http://localhost:5011/";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtEmail.Text?.Trim();
                var password = txtPassword.Text?.Trim();

                var client = new HttpClient
                {
                    BaseAddress = new Uri(webService),
                };

                var hash = EncryptionController.Encrypt(email, password);

                var response = await client.PostAsJsonAsync("api/login/", hash);

                if(!response.IsSuccessStatusCode)
                {
                    throw new Exception("Errore login " + response.StatusCode);
                }

                var content = await response.Content.ReadAsStringAsync();
                var parsed = JsonConvert.DeserializeObject(content);

                lblMessaggio.Text = parsed.ToString();
            }
            catch (Exception ex)
            {
                lblMessaggio.Text = ex.Message;
            }
        }
    }
}