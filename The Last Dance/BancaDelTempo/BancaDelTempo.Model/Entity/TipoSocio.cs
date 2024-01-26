using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Model.Entity
{
    public sealed class TipoSocio
    {
        public int IdTipo { get; set; }

        public string Tipo { get; set; }

        public TipoSocio(int idTipo, string tipo)
        {
            IdTipo = idTipo;
            Tipo = tipo;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
