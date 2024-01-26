using BancaDelTempo.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Model.Mapper
{
    public static class TipoSocioMapper
    {
        public static List<TipoSocio> Map(DataTable table)
        {
            var list = new List<TipoSocio>(table.Rows.Count);
            foreach (DataRow row in table.Rows)
            {
                list.Add(
                        Map(row)
                    );
            }
            return list;
        }

        public static TipoSocio Map(DataRow row)
        {
            return new TipoSocio(
                    Convert.ToInt32(row[0]),
                    row[1].ToString()
                );
        }
    }
}
