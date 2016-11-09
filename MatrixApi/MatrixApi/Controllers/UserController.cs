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

        [HttpGet]
        [ActionName("getuser")]
        public HttpResponseMessage GetUserBySearch(int userid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetUserById(userid));
        }

        [HttpGet]
        [ActionName("getuserbyusername")]
        public HttpResponseMessage GetUserByUsername(string username)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetUserByUsername(username));
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

        [HttpGet]
        [ActionName("activechange")]
        public HttpResponseMessage UserLogin(int userid, int active)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.ActiveChange(userid, active));
        }

        [HttpGet]
        [ActionName("getusersearch")]
        public HttpResponseMessage GetMemberTypeChart()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objUserAccess.GetUserSearch());
        }
    }
}
 