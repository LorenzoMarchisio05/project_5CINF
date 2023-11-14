using Producer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;


namespace ES09_WEBSERVICE_SOAP
{
    /// <summary>
    /// Descrizione di riepilogo per WebServiceSOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceSOAP : System.Web.Services.WebService
    {

        private static readonly string connectionString = AdoNetController.GetConnectionStringFromDBName(@"App_Data\Scuola.mdf");

        private readonly AdoNetController _adoNetController = new AdoNetController(connectionString);

        [WebMethod]
        public string ClassiJSON()
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = SELECT_IDCLASSE_CLASSE,
            };

            var dataTable = _adoNetController.ExecuteQuery(command);
            dataTable.TableName = "dtClassi";


            return JsonConvert.SerializeObject(dataTable);
        }

        [WebMethod]
        public DataTable Classi()
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = SELECT_IDCLASSE_CLASSE,
            };

            var dataTable = _adoNetController.ExecuteQuery(command);
            dataTable.TableName = "dtClassi";


            return dataTable;
        }

        private const string SELECT_IDCLASSE_CLASSE = @"SELECT idClasse, classe
                                                        FROM classi
                                                        ORDER BY classe";
    }
}
