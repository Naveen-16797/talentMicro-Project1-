using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        private Class8 c;
        public EmployeeController()
        {
            this.c = new Class8();
        }
        // GET: api/Employee
        public IEnumerable<object> Get()
        {
            yield return c.getAll();
        }

        // GET: api/Employee/5
        public object Get(String data, String id)
        {
            return c.getstates(data, id);
        }
        public object Get(String username, String password,int id) {
            return c.validateLogin(username, password,id);
        }

        // GET api/values/5
        public object Get(String data)
        {
            return c.Getisdwithcountry(data);
        }
        public object Get(int id) {

            return c.getoneEmp(id);
        }

        [HttpPost]
        // POST: api/Employee
        public object Post(int id,[FromBody]Class4 value)
        {
            return c.postJsonData(id, value);
        }
        public object Post(String pass, String link) {
            return c.putPassword(pass, link);
        }
       
        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }
        public object Put(String pass, String link) {
            return c.putPassword(pass, link);
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
