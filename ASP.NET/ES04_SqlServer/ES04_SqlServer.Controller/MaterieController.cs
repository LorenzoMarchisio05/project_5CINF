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
    public sealed class MaterieController : DBControllerBase
    {
        public MaterieController() 
            : base()
        {

        }

        public DataTable fetchMaterie()
        {
            try
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = @"SELECT idMateria, materia
                                    FROM MATERIE"
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
