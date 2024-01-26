using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Model.Entity
{
    public sealed class Socio
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Email { get; set; }
        
        public string Pasword { get; set; }

        public uint OreErogate { get; set; }
        
        public uint OreRicevute { get; set; }

        public int IdTipo { get; set; }
        
        public int IdResponsabile { get; set; }

        public Socio(int id, string nome, string cognome, string email, string pasword, uint oreErogate, uint oreRicevute, int idTipo, int idResponsabile)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Pasword = pasword;
            OreErogate = oreErogate;
            OreRicevute = oreRicevute;
            IdTipo = idTipo;
            IdResponsabile = idResponsabile;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
