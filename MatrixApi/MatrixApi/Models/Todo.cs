using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixApi.Models
{
    public class Todo
    {
        public int todoid
        {
            get;
            set;
        }
        public string todoname
        {
            get;
            set;
        }
        public int status
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