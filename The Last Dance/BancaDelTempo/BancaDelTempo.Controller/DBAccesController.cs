using System.IO;

namespace BancaDelTempo.Controller
{
    public abstract class DBAccesController
    {
        protected readonly AdoNetController _dbController = new AdoNetController(
                AdoNetController.GetConnectionStringFromDBName(Path.Combine("App_Data", "DB_BANCADELTEMPO.mdf"))
            );
    }
}
