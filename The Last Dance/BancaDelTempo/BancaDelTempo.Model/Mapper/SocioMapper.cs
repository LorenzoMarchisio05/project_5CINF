using BancaDelTempo.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Model.Mapper
{
    public static class SocioMapper
    {
        public static List<Socio> Map(DataTable table)
        {
            var list = new List<Socio>(table.Rows.Count);
            foreach(DataRow row in table.Rows) 
            {
                list.Add(
                        Map(row)
                    );
            }
            return list;    
        }

        public static Socio Map(DataRow row)
        {
            return new Socio(
                    Convert.ToInt32(row[0]),
                    row[1].ToString(),
                    row[2].ToString(),
                    row[3].ToString(),
                    row[4].ToString(),
                    Convert.ToUInt32(row[5]),
                    Convert.ToUInt32(row[6]),
                    Convert.ToInt32(row[7]),
                    Convert.ToInt32((row[8] is DBNull || row[8] is null) ? -1 : row[8])
                );
        }
    }
}
