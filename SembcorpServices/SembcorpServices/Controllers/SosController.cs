using SembcorpServices.Models;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System;
using System.Web.Mvc;

namespace SembcorpServices.Controllers
{
    public class SosController : ApiController
    {
        // GET: api/Sos
        public ActionResult Get()
        {

            List<SosMessage> sosMessages = new SosMessageDAO().GetAllSosMessage();

            if (sosMessages == null) return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            JsonResult result = new JsonResult()
            {
                Data = sosMessages
            };
            return result;
        }

        // GET: api/Sos/5
        public ActionResult Get(Guid id)
        {

            SosMessage sosMessage = new SosMessageDAO().GetbyGuid(id);

            if (sosMessage == null) return new HttpStatusCodeResult(HttpStatusCode.NoContent);

            JsonResult result = new JsonResult()
            {
                Data = sosMessage
            };
            return result;
        }

        // POST: api/Sos
        public HttpResponseMessage Post([FromBody]string value)
        {
            SosMessage sosMessage = JsonConvert.DeserializeObject<SosMessage>(value);
            bool result = new SosMessageDAO().AddSosMessage(sosMessage);

            if (result)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, sosMessage);
                response.Headers.Location = new Uri(Request.RequestUri, string.Format("AdminAlert/{0}", sosMessage.SosId));
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Conflict, sosMessage);
                return response;
            }
        }

        // PUT: api/Sos/5
        public HttpResponseMessage Put(string id, [FromBody]string value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Conflict, id);
            try
            {
                SosUpdate sosUpdate = JsonConvert.DeserializeObject<SosUpdate>(value);
                bool result = new SosMessageDAO().UpdateSosMessage(Guid.Parse(id), sosUpdate);

                if (result)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, sosUpdate.LastUpdate);
                    response.Headers.Location = new Uri(Request.RequestUri, string.Format("sos/{0}", id));
                    return response;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            
            return response;
        }

        public HttpResponseMessage Resolve(string id, [FromBody]string value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Conflict, id);
            try
            {
                ResolveUpdate resolveUpdate = JsonConvert.DeserializeObject<ResolveUpdate>(value);
                bool result = new SosMessageDAO().ResolveMessage(Guid.Parse(id), resolveUpdate);

                if (result)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, resolveUpdate.LastUpdate);
                    response.Headers.Location = new Uri(Request.RequestUri, string.Format("sos/{0}", id));
                    return response;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return response;
        }

        public class ResolveUpdate
        {
            public double Lat { get; set; }
            public double Longi { get; set; }
            public DateTime LastUpdate { get; set; }
            public bool IsResolved { get; set; }

            [JsonConstructor]
            public ResolveUpdate(double lat, double longi, DateTime lastUpdate, bool isResolved)
            {
                Lat = lat;
                Longi = longi;
                LastUpdate = lastUpdate;
                IsResolved = isResolved;
            }
        }

        public class SosUpdate
        {
            public double Lat { get; set; }
            public double Longi { get; set; }
            public DateTime LastUpdate { get; set; }
            public string Message { get; set; }

            [JsonConstructor]
            public SosUpdate(double lat, double longi, DateTime lastUpdate, string message)
            {
                Lat = lat;
                Longi = longi;
                LastUpdate = lastUpdate;
                Message = message;
            }
        }

        // DELETE: api/Sos/5
        public void Delete(int id)
        {
        }
    }
}
