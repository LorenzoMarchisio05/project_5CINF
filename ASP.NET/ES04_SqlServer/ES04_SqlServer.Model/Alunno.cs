using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES04_SqlServer.Model
{
    public sealed class Alunno
    {
        public int IdAlunno { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Alunno(int idAlunno, string nome, string cognome)
        {
            this.IdAlunno = idAlunno;
            this.Nome = nome;
            this.Cognome = cognome;
        }
    }
}
