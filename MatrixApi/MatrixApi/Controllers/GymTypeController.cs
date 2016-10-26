using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MatrixApi.DataAccess;
using MatrixApi.Models;

namespace MatrixApi.Controllers
{
    public class GymTypeController : ApiController
    {

        private GymTypeAccess objGymTypeAccess = new GymTypeAccess();

        [HttpGet]
        [ActionName("getallgymtype")]
        public HttpResponseMessage GetAllGymType()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objGymTypeAccess.GetAllGymType());
        }

        [HttpGet]
        [ActionName("getgymtypebyid")]
        public HttpResponseMessage GetGymTypeById(int gymtypeid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objGymTypeAccess.GetGymTypeById(gymtypeid));
        }

        [HttpPost]
        [ActionName("addgymtype")]
        public HttpResponseMessage AddGymType([FromBody]GymType objGymType)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objGymTypeAccess.AddGymType(objGymType));
        }

        [HttpPost]
        [ActionName("editgymtype")]
        public HttpResponseMessage EditGymType([FromBody]GymType objGymType)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objGymTypeAccess.EditGymType(objGymType));
        }
    }
}
