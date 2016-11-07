using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixApi.Models
{
    public class MemberType
    {
        public int membertypeid
        {
            get;
            set;
        }
        public string membertypename
        {
            get;
            set;
        }
        public float amount
        {
            get;
            set;
        }
        public int duration
        {
            get;
            set;
        }
        public string colorcode
        {
            get;
            set;
        }
        public string createdat
        {
            get;
            set;
        }
        public string updatedat
        {
            get;
            set;
        }
    }
}