using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES04_SqlServer.Model
{
    public sealed class Voto
    {
        public int IdVoto { get; set; }
        public int IdAlunno { get; set; }
        public int IdMateria { get; set; }
        public float valore { get; set; }
        public DateTime DataVoto { get; set; }

        public Voto(int idVoto, int idAlunno, int idMateria, float valore, DateTime dataVoto)
        {
            this.IdVoto = idVoto;
            this.IdAlunno = idAlunno;
            this.IdMateria = idMateria;
            this.valore = valore;
            this.DataVoto = dataVoto;
        }
    }
}
