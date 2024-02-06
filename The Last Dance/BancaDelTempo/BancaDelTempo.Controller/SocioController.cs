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

        public bool SocioExists(string hash)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "SELECT 1 FROM SOCI WHERE pwd = @hash",
                Parameters =
                {
                    new SqlParameter("@hash", hash),
                },
            };

            var result = _dbController.ExecuteNonQuery(command);

            return result == 1;
        }
    }
}
