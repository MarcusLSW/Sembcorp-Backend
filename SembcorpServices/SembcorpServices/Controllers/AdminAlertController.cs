using Newtonsoft.Json;
using SembcorpServices.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SembcorpServices.Controllers
{
    public class AdminAlertController : ApiController
    {
        // GET: api/AdminAlert
        public List<AdminAlert> Get()
        {
            return new AdminAlertDAO().GetAllAlert();
        }

        // GET: api/AdminAlert/5
        public AdminAlert Get(string id)
        {
            return new AdminAlertDAO().GetAdminAlertById(Guid.Parse(id));
        }

        // POST: api/AdminAlert
        public HttpResponseMessage Post([FromBody]string value)
        {
            System.Diagnostics.Debug.WriteLine("Alert " + value);
            AdminAlert adminAlert = JsonConvert.DeserializeObject<AdminAlert>(value);
            bool result = new AdminAlertDAO().AddAdminAlert(adminAlert);

            if (result)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, adminAlert);
                response.Headers.Location = new Uri(Request.RequestUri, string.Format("AdminAlert/{0}", adminAlert.Id));
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Conflict, adminAlert);
                return response;
            }

        }
        
        public HttpResponseMessage PutChild(string id, [FromBody]string value)
        {
            HttpResponseMessage response = null;

            Guid alertId = Guid.Empty;
            Guid childId = Guid.Empty;
            try
            {
                alertId = Guid.Parse(id);
                childId = Guid.Parse(value);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
                response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }

            bool result = new AdminAlertDAO().UpdateChild(alertId, childId);

            if (result)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, id);
                response.Headers.Location = new Uri(Request.RequestUri, string.Format("AdminAlert/{0}", id));
                return response;
            } else
            {
                response = Request.CreateResponse(HttpStatusCode.Conflict, "Update was unsuccessful");
                return response;
            }
        }

        public HttpResponseMessage PutMessage(string id, [FromBody]string value)
        {
            HttpResponseMessage response = null;

            Guid alertId = Guid.Empty;
            try
            {
                alertId = Guid.Parse(id);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message.ToString());
                response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }

            bool result = new AdminAlertDAO().UpdateMessage(alertId, value);

            if (result)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, id);
                response.Headers.Location = new Uri(Request.RequestUri, string.Format("AdminAlert/{0}", id));
                return response;
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Conflict, "Update was unsuccessful");
                return response;
            }
        }

        // DELETE: api/AdminAlert/5
        public void Delete(string id)
        {
            Guid guid = Guid.Parse(id);

        }
    }
}
