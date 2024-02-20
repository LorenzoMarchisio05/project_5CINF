using BancaDelTempo.Model.Entity;
using BancaDelTempo.Model.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Controller
{
    public sealed class SocioController : DBAccesController
    {
        private readonly List<Socio> _soci;

        public SocioController()
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM SOCI",
            };

            var result = _dbController.ExecuteQuery(command);

            _soci = SocioMapper.Map(result);
        }

        public IReadOnlyList<Socio> GetSoci()
        {
            return _soci;
        }

        public object TryLogin(string hash)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT cognome, nome, email, idTipo as 'tipoSocio' FROM SOCI WHERE pwd = @hash",
                Parameters =
                {
                    new SqlParameter("@hash", hash),
                },
            };

            var result = _dbController.ExecuteQuery(command);

            if(result.Rows.Count != 1)
            {
                return new
                {
                    Authorized = false,
                    Message = "Invalid login credentials",
                };
            }

            var row = result.Rows[0];

            return new
            {
                Authorized = true,
                Message = "Login Success",

                Cognome = row.ItemArray[0].ToString(),
                Nome = row.ItemArray[1].ToString(),
                Email = row.ItemArray[2].ToString(),
                TipoSocio = Convert.ToInt32(row.ItemArray[3]),
            };
        }
    }
}
