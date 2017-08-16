using SembcorpServices.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace SembcorpServices.Controllers
{
    public class EmergencyContactController : ApiController
    {
        // GET: api/EmergencyContact
        public ActionResult Get()
        {
            List<EmergencyContact> emergencyContacts = new EmergencyContactDAO().GetAllEmergencyContacts();

            if (emergencyContacts == null) return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            JsonResult result = new JsonResult()
            {
                Data = emergencyContacts
            };
            return result;
        }

        // GET: api/EmergencyContact/5
        public ActionResult Get(string id)
        {
            EmergencyContact emergencyContact = new EmergencyContactDAO().GetEmergencyContactById(id);

            if (emergencyContact == null) return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            
            JsonResult result = new JsonResult()
            {
                Data = emergencyContact
            };
            return result;
        }

        // POST: api/EmergencyContact
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EmergencyContact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmergencyContact/5
        public void Delete(int id)
        {
        }
    }
}
