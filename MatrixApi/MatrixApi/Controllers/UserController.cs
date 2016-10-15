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
    public class UserController : ApiController
    {

        private UserAccess objUserAccess = new UserAccess();

        [HttpGet]
        [ActionName("getalluser")]
        public HttpResponseMessage GetAllUser()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetAllUser());
            
        }
    }
}
