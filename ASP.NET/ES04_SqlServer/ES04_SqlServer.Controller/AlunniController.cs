using ES04_SqlServer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES04_SqlServer.Controller
{
    public sealed class AlunniController : DBControllerBase
    {
        public AlunniController() 
            : base()
        {

        }

        public DataTable fetchAlunni()
        {
            try
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = @"SELECT idAlunno, nome, cognome, (nome + ' ' + cognome) AS nominativo 
                                    FROM ALUNNI
                                    ORDER BY nominativo"
                };

                return _adoNetController.ExecuteQuery(command);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
