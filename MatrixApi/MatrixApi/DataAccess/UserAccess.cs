using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MatrixApi.Models;
using MatrixApi.Core;

namespace MatrixApi.DataAccess
{
    public class UserAccess
    {
        public List<Dictionary<string, object>> GetAllUser()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_user");
        }
    }
}