using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API_1.Models;
using AdoNetWrapper;
using System.IO;

namespace WEB_API_1.Controllers
{   
    public class AlunniController : ApiController
    {
        private readonly AdoNetController _adoNetController;

        public AlunniController()
        {
            _adoNetController = new AdoNetController(Path.Combine("../", "App_Data", "Scuola.mdf"));
        }


        // GET api/<controller>
        public IEnumerable<Alunno> Get()
        {
            return null;
        }

        // GET api/<controller>/5
        public Alunno Get(int id)
        {
            return null;
        }

        // POST api/<controller>
        public void Post(
            [FromBody] Alunno value
            ) {

        }

        // PUT api/<controller>/5
        public void Put(
            int id, 
            [FromBody] Alunno value
            ) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}