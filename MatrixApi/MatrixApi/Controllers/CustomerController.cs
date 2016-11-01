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
    public class CustomerController : ApiController
    {
        private CustomerAcces objCustomerAccess = new CustomerAcces();

        [HttpGet]
        [ActionName("getallcustomer")]
        public HttpResponseMessage GetAllCustomer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetAllCustomer());
        }

        [HttpGet]
        [ActionName("getcustomerbyid")]
        public HttpResponseMessage GetCustomerById(string cid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetCustomerById(cid));
        }

        [HttpGet]
        [ActionName("getallbalanceduecustomer")]
        public HttpResponseMessage GetAllBalanceDueCustomer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetAllBalanceDueCustomer());
        }

        [HttpGet]
        [ActionName("getallexpiredcustomer")]
        public HttpResponseMessage GetAllExpiredCustomer(string today)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetAllExpiredCustomer(today));
        }

        [HttpGet]
        [ActionName("getallthismonthexpirecustomer")]
        public HttpResponseMessage GetAllThisMonthExpireCustomer(string year, string month)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetAllThisMonthExpireCustomer(year,month));
        }

        [HttpGet]
        [ActionName("getallthismonthbirthdaycustomer")]
        public HttpResponseMessage GetAllThisMonthBirthdayCustomer(string month)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetAllThisMonthBirthdayCustomer(month));
        }

        [HttpGet]
        [ActionName("getlasteightcustomer")]
        public HttpResponseMessage GetLastEightCustomer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetLastEightCustomer());
        }

        [HttpPost]
        [ActionName("addcustomer")]
        public HttpResponseMessage AddCustomer([FromBody]Customer objCustomer)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.AddCustomer(objCustomer));
        }

        [HttpPost]
        [ActionName("editcustomer")]
        public HttpResponseMessage EditCustomer([FromBody]Customer objCustomer)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.EditCustomer(objCustomer));
        }

    }
}
