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
        public List<Dictionary<string, object>> GetUserBySearch(User objUser)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_user WHERE userid='" + objUser.userid + "'");
        }
        public List<Dictionary<string, object>> GetUserByUsername(User objUser)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_user WHERE username='" + objUser.username + "'");
        }

        public string UserLogin(User objUser)
        {
            return DbAccess.DbLogin("SELECT * FROM tbl_user WHERE username='" + objUser.username + "' and password='" + objUser.password + "'");
        }
    }
}