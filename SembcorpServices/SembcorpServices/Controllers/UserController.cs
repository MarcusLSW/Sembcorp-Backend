using Newtonsoft.Json;
using SembcorpServices.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SembcorpServices.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public List<User> Get()
        {
            return new UserDAO().GetAllUsers();
        }

        //Always end the requests with a / for this method call as the .com or .sg extensions of emails will throw off these reqeuests

        // GET: api/User/{email}/
        public User Get(string id)
        {
            return new UserDAO().GetUserByEmail(id);
        }

        // POST: api/User
        public HttpResponseMessage Post([FromBody]string value)
        {
            User user = JsonConvert.DeserializeObject<User>(value);
            bool result = new UserDAO().AddUser(user);

            if (result)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Request.RequestUri, string.Format("user/{0}", user.Email));
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Conflict, user);
                return response;
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
