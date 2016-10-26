using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatrixApi.Models
{
    public class GymType
    {
        public int gymtypeid
        {
            get;
            set;
        }
        public string gymtypename
        {
            get;
            set;
        }
        public DateTime createdat
        {
            get;
            set;
        }
        public DateTime updatedat
        {
            get;
            set;
        }
    }
}