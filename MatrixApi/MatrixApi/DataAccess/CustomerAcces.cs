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
    public class CustomerAcces
    {
        public List<Dictionary<string, object>> GetAllCustomer()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_customer");
        }

        public List<Dictionary<string, object>> GetCustomerById(string cid)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_customer WHERE cid='" + cid + "'");
        }

        public List<Dictionary<string, object>> GetAllBalanceDueCustomer()
        {
            return DbAccess.DbASelect("select * from tbl_customer where balance > 0");
        }

        public List<Dictionary<string, object>> GetAllExpiredCustomer(string today)
        {
            return DbAccess.DbASelect("select * from tbl_customer where enddate < '"+today+"'");
        }

        public List<Dictionary<string, object>> GetAllThisMonthExpireCustomer(string year, string month)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_customer WHERE YEAR(enddate) = '"+year+"' and MONTH(enddate) = '"+month+"'");
        }

        public List<Dictionary<string, object>> GetAllThisMonthBirthdayCustomer(string month)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_customer WHERE MONTH(dob) = '" + month + "'");
        }

        public List<Dictionary<string, object>> GetLastEightCustomer()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_customer ORDER BY xlimit DESC LIMIT 8");
        }

        public string AddCustomer(Customer objCustomer)
        {
            return DbAccess.DbAInsert("insert into tbl_customer VALUES ('NULL','" + objCustomer.cid
                    + "', '" + objCustomer.fname
                    + "', '" + objCustomer.lname
                    + "', '" + objCustomer.email
                    + "', '" + objCustomer.gender
                    + "', '" + objCustomer.dob
                    + "', '" + objCustomer.address
                    + "', '" + objCustomer.phone
                    + "', '" + objCustomer.email
                    + "', '" + objCustomer.cphoto
                    + "', '" + objCustomer.occupation
                    + "', " + objCustomer.membertypeid
                    + ", " + objCustomer.gymtypeid
                    + ", '" + objCustomer.joindate
                    + "', '" + objCustomer.startdate
                    + "', '" + objCustomer.enddate
                    + "', '" + objCustomer.amount
                    + "', '" + objCustomer.paid
                    + "', '" + objCustomer.balance
                    + "', '" + objCustomer.password
                    + "', " + objCustomer.active
                    + ", '" + objCustomer.createdat
                    + "', '" + objCustomer.updatedat
                    + "', " + objCustomer.createdby
                    + ", " + objCustomer.updatedby
                    + ", '" + objCustomer.height
                    + "', '" + objCustomer.weight
                    + "', '" + objCustomer.thighsize
                    + "', '" + objCustomer.bicepsize
                    + "', '" + objCustomer.calfsize
                    + "')");
        }

        public string EditCustomer(Customer objEditCustomer)
        {
            return DbAccess.DbAInsert("UPDATE tbl_customer SET "
            + "fname='" + objEditCustomer.fname + "',"
            + "lname='" + objEditCustomer.lname + "',"
            + "gender='" + objEditCustomer.gender + "',"
            + "dob='" + objEditCustomer.dob + "',"
            + "address='" + objEditCustomer.address + "',"
            + "phone='" + objEditCustomer.phone + "',"
            + "email='" + objEditCustomer.email + "',"
            + "occupation='" + objEditCustomer.occupation + "',"
            + "updatedat='" + objEditCustomer.updatedat + "',"
            + "updatedby='" + objEditCustomer.updatedby + "',"
            + "height='" + objEditCustomer.height + "',"
            + "weight='" + objEditCustomer.weight + "',"
            + "thighsize='" + objEditCustomer.thighsize + "',"
            + "bicepsize='" + objEditCustomer.bicepsize + "',"
            + "calfsize='" + objEditCustomer.calfsize + "' WHERE cid='" + objEditCustomer.cid + "'");
        }
    }
}