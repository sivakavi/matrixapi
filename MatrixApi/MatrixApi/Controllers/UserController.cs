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

        [HttpPost]
        [ActionName("getuser")]
        public HttpResponseMessage GetUserBySearch([FromBody]User objUser)
        {
           return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetUserBySearch(objUser));
        }

        [HttpPost]
        [ActionName("getuserbyusername")]
        public HttpResponseMessage GetUserByUsername([FromBody]User objUser)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetUserByUsername(objUser));
        }

        [HttpPost]
        [ActionName("userlogin")]
        public HttpResponseMessage UserLogin([FromBody]User objUser)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.UserLogin(objUser));
        }

        [HttpGet]
        [ActionName("changepassword")]
        public HttpResponseMessage UserLogin(string oldpassword, string newpassword, string username)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.ChangePassword(oldpassword, newpassword, username));
        }

        [HttpPost]
        [ActionName("adduser")]
        public HttpResponseMessage AddUser([FromBody]User objUser)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.AddUser(objUser));
        }

        [HttpPost]
        [ActionName("edituser")]
        public HttpResponseMessage EditUser([FromBody]User objUser)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.EditUser(objUser));
        }
    }
}
 