using BancaDelTempo.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BancaDelTempo.View.Controllers
{
    public class SociController : ApiController
    {
        private static readonly SocioController socioController = new SocioController();

        // GET: api/Soci
        public IEnumerable<string> Get() => socioController
                .GetSoci()
                .Select(socio => socio.ToString());

        // GET: api/Soci/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Soci
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Soci/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Soci/5
        public void Delete(int id)
        {
        }
    }
}
