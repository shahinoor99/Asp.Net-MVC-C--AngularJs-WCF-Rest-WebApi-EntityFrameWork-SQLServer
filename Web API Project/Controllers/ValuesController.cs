using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WCFRest;
using Web_API_Project.Models;

namespace Web_API_Project.Controllers
{
    public class ValuesController : ApiController
    {
        EmpTestEntities db = new EmpTestEntities();
        EMBRACING_DBEntities db1 = new EMBRACING_DBEntities();
        // GET api/values/Get
        //[ActionName("GetData")]
        public IEnumerable<UserDataContract> Get()
        {
            var query = (from a in db.UserTables
                         select a).Distinct();

            List<UserDataContract> UserList = new List<UserDataContract>();

            query.ToList().ForEach(rec =>
            {
                UserList.Add(new UserDataContract
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Address = rec.Address,
                    City = rec.City,
                });
            });
            return UserList;
        }

        // GET api/values/5
       //api/values/Get?id=1
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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