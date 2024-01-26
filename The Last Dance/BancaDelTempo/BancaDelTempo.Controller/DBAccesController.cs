using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Controller
{
    public abstract class DBAccesController
    {
        protected readonly AdoNetController _dbController = new AdoNetController(
                AdoNetController.GetConnectionStringFromDBName(Path.Combine("App_Data", "DB_BANCADELTEMPO.mdf"))
            );
    }
}
