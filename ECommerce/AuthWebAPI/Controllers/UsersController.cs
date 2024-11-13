using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EcommerceEntities;
using EcommerceServices;
using Specification;

namespace AuthWebAPI.Controllers
{
    public class UsersController : ApiController
    {
        //CRUD  Operation
        // GET api/values
        public IEnumerable<User> Get() //return type is collection
        {
            IAuthService svc = new AuthService();
            List<User> Users = svc.GetAllUser();

            return Users;
        }

        // GET api/values/5
        public User Get(int id)
        {
            IAuthService svc = new AuthService();
            User Users = svc.GetById(id);

            return Users;
        }

        // POST api/values
        public void Post([FromBody] User p)
        {
            IAuthService svc = new AuthService();
            svc.Register(p,"password");                     //continue with the code here
        }

        // PUT api/values/5
       /* public void Put(int id, [FromBody] User p)
        {
            IAuthService svc = new AuthService();
            svc.Update(p);
        }*/

        // DELETE api/values/5
        public void Delete(int id)
        {
            IAuthService svc = new AuthService();
            svc.Delete(id);
        }
    }
}
