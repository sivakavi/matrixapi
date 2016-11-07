using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixApi.Models
{
    public class User
    {
        public int userid
        {
            get;
            set;
        }
        public string fname
        {
            get;
            set;
        }
        public string lname
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string phone
        {
            get;
            set;
        }
        public string address
        {
            get;
            set;
        }
        public string profileimage
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public int active
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
        public int updatedby
        {
            get;
            set;
        }
        public int userrole
        {
            get;
            set;
        }
    }
}