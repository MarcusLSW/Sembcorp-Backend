using SembcorpServices.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System;

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
        public HttpResponseMessage Post([FromBody]string value)
        {
            System.Diagnostics.Debug.WriteLine(value);

            EmergencyContact emergencyContact = JsonConvert.DeserializeObject<EmergencyContact>(value);
            bool result = new EmergencyContactDAO().AddEmergencyContact(emergencyContact);

            if (result)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, emergencyContact);
                response.Headers.Location = new Uri(Request.RequestUri, string.Format("AdminAlert/{0}", emergencyContact.EmergencyNumber));
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Conflict, emergencyContact);
                return response;
            }
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
