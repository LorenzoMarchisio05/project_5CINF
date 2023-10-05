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
    public sealed class VotiController : DBControllerBase
    {
        public VotiController()
            : base()
        {

        }

        public DataTable fetchVoti()
        {
            try
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = @"SELECT idVoto, valore 
                                    FROM VOTI"
                };

                return _adoNetController.ExecuteQuery(command);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable fetchVoti(int idAlunno)
        {
            try
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = @"SELECT idVoto, voto 
                                    FROM VOTI
                                    WHERE idAlunno = @idAlunno",
                    Parameters =
                    {
                        new SqlParameter("@idAlunno", idAlunno),
                    },
                };

                return _adoNetController.ExecuteQuery(command);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
