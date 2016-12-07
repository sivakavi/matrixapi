using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixApi.Models
{
    public class Invoice
    {
        public int sno
        {
            get;
            set;
        }
        public int invoiceno
        {
            get;
            set;
        }
        public string cid
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public float amount
        {
            get;
            set;
        }
        public float paid
        {
            get;
            set;
        }
        public float balance
        {
            get;
            set;
        }
        public string idate
        {
            get;
            set;
        }
        public string createdat
        {
            get;
            set;
        }
        public int createdby
        {
            get;
            set;
        }
        public int membertypeid
        {
            get;
            set;
        }
        public string startdate
        {
            get;
            set;
        }
        public string enddate
        {
            get;
            set;
        }
    }
}