using SembcorpServices.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace SembcorpServices.Controllers
{
    public class SosController : ApiController
    {
        // GET: api/Sos
        public List<SosMessage> Get()
        {
            List<SosMessage> sosMessages = new SosMessageDAO().GetAllSosMessage();
            return sosMessages;
        }

        // GET: api/Sos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sos/5
        public void Delete(int id)
        {
        }
    }
}
