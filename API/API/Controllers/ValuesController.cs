using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ValuesController : ApiController
    {
        dbGoTripEntities1 db = new dbGoTripEntities1 ();
        // GET api/values
        public IEnumerable<tblTurPaket> Get()
        {
            return db.tblTurPakets.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public tblTurPaket Get(int id)
        {
            return db.tblTurPakets.FirstOrDefault(i => i.Id == id);
            //return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
