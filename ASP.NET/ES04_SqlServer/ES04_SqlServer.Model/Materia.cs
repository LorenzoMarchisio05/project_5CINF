using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES04_SqlServer.Model
{
    public sealed class Materia
    {
        public int IdMateria { get; set; }
        public string Nome { get; set; }

        public Materia(int idMateria, string nome)
        {
            this.IdMateria = idMateria;
            this.Nome = nome;
        }
    }
}
