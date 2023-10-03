using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES04_SqlServer.Controller
{
    public class DBControllerBase
    {
        protected readonly AdoNetController _adoNetController;
        public DBControllerBase()
        {
            var connectionString = AdoNetController.GetConnectionStringFromDBName(@"App_Data\DBScuola.mdf");
            _adoNetController = new AdoNetController(connectionString);
        }
    }
}
