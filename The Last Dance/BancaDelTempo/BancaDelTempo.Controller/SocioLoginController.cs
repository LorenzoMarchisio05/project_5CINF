using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Controller
{
    public sealed class SocioLoginController : DBAccesController
    {
        public bool Login(string email, string password)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT password FROM soci WHERE email = @email",
                Parameters =
                {
                    new SqlParameter("email", email),
                },
            };

            var result = _dbController.ExecuteScalar(command).ToString();

            var hash = "";

            return result == hash;
        }
    }
}
