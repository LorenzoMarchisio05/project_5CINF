using BancaDelTempo.Controller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BancaDelTempo.Client
{
    public partial class login1 : System.Web.UI.Page
    {
        private readonly string webService = "http://localhost:5011/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["logged"] is bool logged && logged)
            {
                return;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
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

                var httpPromise = client.PostAsJsonAsync("api/login/", hash);
                httpPromise.Wait();

                var response = httpPromise.Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Errore login " + response.StatusCode);
                }

                var jsonPromise = response.Content.ReadAsStringAsync();
                jsonPromise.Wait();

                var content = jsonPromise.Result;
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