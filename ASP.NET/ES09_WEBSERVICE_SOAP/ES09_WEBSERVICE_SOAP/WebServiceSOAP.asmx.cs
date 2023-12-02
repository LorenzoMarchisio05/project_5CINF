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

        [WebMethod]
        public DataTable Alunni(string idClasse)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = SELECT_ALUNNI_ID_CLASSE,
                Parameters =
                {
                    new SqlParameter("@idClasse", idClasse),
                },
            };

            var dataTable = _adoNetController.ExecuteQuery(command);
            dataTable.TableName = "dtAlunni";


            return dataTable;
        }

        [WebMethod]
        public int InserisciAlunno(string idClasse, string nome, string cognome)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = INSERT_INTO_ALUNNI,
                Parameters =
                {
                    new SqlParameter("@idClasse", idClasse),
                    new SqlParameter("@nome", nome),
                    new SqlParameter("@cognome", cognome),
                },
            };

            var id = (int)_adoNetController.ExecuteScalar(command); 

            return id;
        }

        private const string SELECT_IDCLASSE_CLASSE = @"SELECT idClasse, classe
                                                        FROM classi
                                                        ORDER BY classe";

        private const string SELECT_ALUNNI_ID_CLASSE = @"SELECT idAlunno, cognome, nome
                                                        FROM alunni
                                                        WHERE idClasse = @idClasse";

        private const string INSERT_INTO_ALUNNI = @"INSERT INTO ALUNNI (idClasse, cognome, nome)
                                                        VALUES
                                                        (@idClasse, @cognome, @nome);
                                                    SELECT SCOPE_IDENTITY();";

    }
}
