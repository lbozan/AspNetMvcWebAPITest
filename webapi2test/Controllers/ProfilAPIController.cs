using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi2test.Business;
using webapi2test.Models;

namespace webapi2test.Controllers
{
    public class ProfilAPIController : ApiController
    {
        private ProfilCRUD _profilEntity =  ProfilCRUD.Instans;

        // GET: api/profilapi
        [HttpGet]
        public IEnumerable<Profile> All()
        {
            return _profilEntity.List();
        }

        public HttpResponseMessage Add( Profile data)
        {
            if (_profilEntity.Add(data))
                return Request.CreateResponse(HttpStatusCode.OK, data.Id);
            return Request.CreateResponse(HttpStatusCode.NotFound, "false");
        }

        public HttpResponseMessage Update(Profile data)
        {
            if (_profilEntity.Update(data))
                return Request.CreateResponse(HttpStatusCode.OK, "True");
            return Request.CreateResponse(HttpStatusCode.NotFound, "False");
        }
        [HttpGet]
        public HttpResponseMessage Delete(int Id)
        {
            if (_profilEntity.Delete(new Profile() { Id = Id }))
                return Request.CreateResponse(HttpStatusCode.OK, "True");
            return Request.CreateResponse(HttpStatusCode.NotFound, "False");
        }

        public Profile Details(int Id)
        {
            var details = _profilEntity.Details(new Profile() { Id = Id });
            if (details != null)
                return details;
            return null;
        }
    }
}
