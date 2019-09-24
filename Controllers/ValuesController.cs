using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

using WebApplication1.Services;

namespace WebApplication1.Controllers
{
  

    public class ValuesController : ApiController
    {
        private Class1 c;
        // GET api/values
        public ValuesController()
        {
            this.c = new Class1();
        }
        [HttpGet]
        public  IEnumerable<string> Get()
        {
            yield return c.GetAllJsons();
        }
        [HttpGet]
        public object Get(String data)
        {
            var res = c.GetALLquery(data);
            return res;
        }

        public object Get(String data,String id)
        {
            return c.getstates(data,id);
        }


        // GET api/values/5
        public object Get(int id)
        {
            return c.Getisdwithcountry(id);
        }

        
        [HttpPost]
        // POST api/values
        public string Post([FromBody]Class3 value)
        {
            return c.postJsonData(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
