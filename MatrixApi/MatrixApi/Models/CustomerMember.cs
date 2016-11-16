using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixApi.Models
{
    public class CustomerMember
    {
        public int sno
        {
            get;
            set;
        }
        public string cid
        {
            get;
            set;
        }
        public int membertypeid
        {
            get;
            set;
        }
        public float amount
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
    }
}