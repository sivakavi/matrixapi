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
        public HttpResponseMessage GetAllThisMonthExpireCustomer(string year, string month, string today)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetAllThisMonthExpireCustomer(year,month,today));
        }

        [HttpGet]
        [ActionName("getallthismonthbirthdaycustomer")]
        public HttpResponseMessage GetAllThisMonthBirthdayCustomer(string month, string day)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetAllThisMonthBirthdayCustomer(month,day));
        }

        [HttpGet]
        [ActionName("getlasteightcustomer")]
        public HttpResponseMessage GetLastEightCustomer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetLastEightCustomer());
        }

        [HttpGet]
        [ActionName("getmembertypechart")]
        public HttpResponseMessage GetMemberTypeChart()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetMemberTypeChart());
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

        [HttpGet]
        [ActionName("getcustomersearch")]
        public HttpResponseMessage GetCustomerSearch()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetCustomerSearch());
        }

        [HttpGet]
        [ActionName("getcheckcid")]
        public HttpResponseMessage GetCheckCid(string cid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetCheckCid(cid));
        }

        [HttpGet]
        [ActionName("getnewbillcustomersearch")]
        public HttpResponseMessage GetNewBillCustomerSearch()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetNewBillCustomerSearch());
        }

        [HttpGet]
        [ActionName("getbalancebillcustomersearch")]
        public HttpResponseMessage GetBalanceBillCustomerSearch()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetBalanceBillCustomerSearch());
        }

        [HttpGet]
        [ActionName("getrenewalupgradebillcustomersearch")]
        public HttpResponseMessage GetRenewalUpgradeBillCustomerSearch()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetRenewalUpgradeBillCustomerSearch());
        }

        [HttpGet]
        [ActionName("getinvoicenumber")]
        public HttpResponseMessage GetInvoiceNumber()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetInvoiceNumber());
        }

        [HttpPost]
        [ActionName("addnewbalanceinvoice")]
        public HttpResponseMessage AddNewBalanceInvoice([FromBody]Invoice objInvoice)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.AddNewBalanceInvoice(objInvoice));
        }

        [HttpGet]
        [ActionName("getinvoice")]
        public HttpResponseMessage GetInvoice(int invoiceno)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetInvoice(invoiceno));
        }

        [HttpGet]
        [ActionName("getinvoicecustomer")]
        public HttpResponseMessage GetInvoice(string cid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetInvoiceCustomer(cid));
        }

        [HttpGet]
        [ActionName("getcustomermember")]
        public HttpResponseMessage GetCustomerMember(string cid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.GetCustomerMember(cid));
        }

        [HttpGet]
        [ActionName("summa")]
        public HttpResponseMessage Summa(string cid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objCustomerAccess.Summa(cid));
        }

    }
}
