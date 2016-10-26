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

        public string AddUser(User objUser)
        {
            return DbAccess.DbAInsert("insert into tbl_user VALUES ('NULL','" + objUser.fname
                    + "', '" + objUser.lname
                    + "', '" + objUser.email
                    + "', '" + objUser.phone
                    + "', '" + objUser.address
                    + "', '" + objUser.profileimage
                    + "', '" + objUser.username
                    + "', '" + objUser.password
                    + "', '" + objUser.active
                    + "', '" + objUser.createdat
                    + "', '" + objUser.updatedat
                    + "', '" + objUser.updatedby
                    + "', '" + objUser.userrole
                    + "')");
        }

        public string EditUser(User objEditUser)
        {
            return DbAccess.DbAInsert("UPDATE tbl_user SET "
            + "fname='" + objEditUser.fname + "',"
            + "lname='" + objEditUser.lname + "',"
            + "email='" + objEditUser.email + "',"
            + "phone='" + objEditUser.phone + "',"
            + "address='" + objEditUser.address + "',"
            + "updatedat='" + objEditUser.updatedat + "',"
            + "updatedby='" + objEditUser.updatedby + "' WHERE userid='" + objEditUser.userid + "'");
        }

        public string ChangePassword(string oldpassword, string newpassword, string username)
        {
            string oldpasscheck = DbAccess.DbChangePassword("SELECT * FROM tbl_user WHERE username='" + username + "'");

            if (oldpasscheck!="nil")
            { 
            if (oldpasscheck != oldpassword)
            {
                return "wrong";
            }
            else
            {
                return DbAccess.DbAInsert("UPDATE tbl_user SET password='" + newpassword + "' WHERE username='" + username + "'");
            }
            }
            else
            {
                return "nouser";
            }
        }


    }
}