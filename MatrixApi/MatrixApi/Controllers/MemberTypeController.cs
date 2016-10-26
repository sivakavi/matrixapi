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
    public class MemberTypeController : ApiController
    {

        private MemberTypeAccess objMemberTypeAccess = new MemberTypeAccess();

        [HttpGet]
        [ActionName("getallmembertype")]
        public HttpResponseMessage GetAllMemberType()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objMemberTypeAccess.GetAllMemberType());
        }

        [HttpGet]
        [ActionName("getmembertypebyid")]
        public HttpResponseMessage GetMemberTypeById(int membertypeid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objMemberTypeAccess.GetMemberTypeById(membertypeid));
        }

        [HttpPost]
        [ActionName("addmembertype")]
        public HttpResponseMessage AddMemberType([FromBody]MemberType objMemberType)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objMemberTypeAccess.AddMemberType(objMemberType));
        }

        [HttpPost]
        [ActionName("editmembertype")]
        public HttpResponseMessage EditMemberType([FromBody]MemberType objMemberType)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objMemberTypeAccess.EditMemberType(objMemberType));
        }
    }
}
