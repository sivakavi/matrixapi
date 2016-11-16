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
            return DbAccess.DbASelect("SELECT c.*,m.membertypename,g.gymtypename FROM tbl_customer as c INNER JOIN tbl_membertype as m ON c.membertypeid = m.membertypeid INNER JOIN tbl_gymtype as g ON c.gymtypeid = g.gymtypeid");
        }

        public List<Dictionary<string, object>> GetCustomerById(string cid)
        {
            return DbAccess.DbASelect("SELECT c.*,m.membertypename,g.gymtypename FROM tbl_customer as c INNER JOIN tbl_membertype as m ON c.membertypeid = m.membertypeid INNER JOIN tbl_gymtype as g ON c.gymtypeid = g.gymtypeid WHERE cid='" + cid + "'");
        }

        public List<Dictionary<string, object>> GetAllBalanceDueCustomer()
        {
            return DbAccess.DbASelect("SELECT c.*,m.membertypename,g.gymtypename FROM tbl_customer as c INNER JOIN tbl_membertype as m ON c.membertypeid = m.membertypeid INNER JOIN tbl_gymtype as g ON c.gymtypeid = g.gymtypeid where balance > 0");
        }

        public List<Dictionary<string, object>> GetAllExpiredCustomer(string today)
        {
            return DbAccess.DbASelect("SELECT c.*,m.membertypename,g.gymtypename FROM tbl_customer as c INNER JOIN tbl_membertype as m ON c.membertypeid = m.membertypeid INNER JOIN tbl_gymtype as g ON c.gymtypeid = g.gymtypeid where enddate < '" + today + "'");
        }

        public List<Dictionary<string, object>> GetAllThisMonthExpireCustomer(string year, string month, string today)
        {
            return DbAccess.DbASelect("SELECT c.*,m.membertypename,g.gymtypename FROM tbl_customer as c INNER JOIN tbl_membertype as m ON c.membertypeid = m.membertypeid INNER JOIN tbl_gymtype as g ON c.gymtypeid = g.gymtypeid WHERE YEAR(enddate) = '" + year + "' and MONTH(enddate) = '" + month + "' and enddate >= '" + today + "'");
        }

        public List<Dictionary<string, object>> GetAllThisMonthBirthdayCustomer(string month, string day)
        {
            return DbAccess.DbASelect("SELECT c.*,m.membertypename,g.gymtypename FROM tbl_customer as c INNER JOIN tbl_membertype as m ON c.membertypeid = m.membertypeid INNER JOIN tbl_gymtype as g ON c.gymtypeid = g.gymtypeid WHERE MONTH(dob) = '" + month + "' and DAY(dob) >= '" + day + "'");
        }

        public List<Dictionary<string, object>> GetLastEightCustomer()
        {
            return DbAccess.DbASelect("SELECT c.*,m.membertypename,g.gymtypename FROM tbl_customer as c INNER JOIN tbl_membertype as m ON c.membertypeid = m.membertypeid INNER JOIN tbl_gymtype as g ON c.gymtypeid = g.gymtypeid ORDER BY xlimit DESC LIMIT 8");
        }

        public List<Dictionary<string, object>> GetMemberTypeChart()
        {
            return DbAccess.DbChart("select c.membertypeid, m.membertypename, m.colorcode, count(*) as co from tbl_customer AS c join tbl_membertype as m on c.membertypeid = m.membertypeid GROUP BY c.membertypeid");
        }

        public string AddCustomer(Customer objCustomer)
        {
            string ret = DbAccess.DbAInsert("insert into tbl_customer VALUES ('NULL','" + objCustomer.cid
                    + "', '" + objCustomer.fname
                    + "', '" + objCustomer.lname
                    + "', '" + objCustomer.gender
                    + "', '" + objCustomer.dob
                    + "', '" + objCustomer.address
                    + "', '" + objCustomer.phone
                    + "', '" + objCustomer.email
                    + "', '" + " "
                    + "', '" + objCustomer.occupation
                    + "', " + objCustomer.membertypeid
                    + ", " + objCustomer.gymtypeid
                    + ", '" + objCustomer.joindate
                    + "', '" + objCustomer.startdate
                    + "', '" + objCustomer.enddate
                    + "', '" + objCustomer.amount
                    + "', '" + objCustomer.paid
                    + "', '" + objCustomer.balance
                    + "', 'welcomematrix', 1, '"+ objCustomer.createdat
                    + "', '" + objCustomer.updatedat
                    + "', " + objCustomer.createdby
                    + ", " + objCustomer.updatedby
                    + ", '" + objCustomer.height
                    + "', '" + objCustomer.weight
                    + "', '" + objCustomer.thighsize
                    + "', '" + objCustomer.bicepsize
                    + "', '" + objCustomer.calfsize
                    + "')");

            if (ret == "success")
            {
                return DbAccess.DbAInsert("insert into tbl_customer_member VALUES ('NULL','" + objCustomer.cid
                    + "', " + objCustomer.membertypeid
                    + ", " + objCustomer.amount
                    + ", '" + objCustomer.startdate
                    + "', '" + objCustomer.enddate
                    + "', '" + objCustomer.createdat
                    + "', " + objCustomer.createdby
                    + ")");
            }
            else
            {
                return "fail";
            }
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

        public List<Dictionary<string, object>> GetCustomerSearch()
        {
            return DbAccess.DbCustomerSearch("select cid, fname from tbl_customer");
        }

        public List<Dictionary<string, object>> GetNewBillCustomerSearch()
        {
            return DbAccess.DbCustomerSearch("select cid, fname from tbl_customer where paid = 0");
        }

        public List<Dictionary<string, object>> GetBalanceBillCustomerSearch()
        {
            return DbAccess.DbCustomerSearch("select cid, fname from tbl_customer where balance > 0 and paid != 0");
        }

        public List<Dictionary<string, object>> GetRenewalUpgradeBillCustomerSearch()
        {
            return DbAccess.DbCustomerSearch("select cid, fname from tbl_customer where balance = 0");
        }

        public string GetCheckCid(string cid)
        {
            return DbAccess.DbCidCheck("select * from tbl_customer where cid='"+ cid +"'");
        }

        public List<Dictionary<string, object>> GetCustomerMemberByCid(string cid)
        {
            return DbAccess.DbASelect("select * from tbl_customer_member where cid='" + cid + "'");
        }

        public List<Dictionary<string, object>> GetInvoiceByCid(string cid)
        {
            return DbAccess.DbASelect("select * from tbl_invoice where cid='" + cid + "'");
        }

        public string AddNewBalanceInvoice(Invoice objInvoice)
        {
           string ret = DbAccess.DbAInsert("insert into tbl_invoice VALUES ('NULL'," + objInvoice.invoiceno
                    + ", '" + objInvoice.cid
                    + "', '" + objInvoice.description
                    + "', '" + objInvoice.amount
                    + "', '" + objInvoice.paid
                    + "', '" + objInvoice.balance
                    + "', '" + objInvoice.idate
                    + "', '" + objInvoice.createdat
                    + "', " + objInvoice.createdby
                    + ")");

            if (ret == "success")
            {
                List<Customer> listcustomer = new List<Customer>();
                listcustomer = DbAccess.DbSingleCustomer("select * from tbl_customer where cid='" + objInvoice.cid + "'");

                float paid = listcustomer[0].paid + objInvoice.paid;
                float balance = listcustomer[0].balance - objInvoice.paid;

                return DbAccess.DbAInsert("UPDATE tbl_customer SET "
                    + "paid='" + paid + "',"
                    + "balance='" + balance + "' WHERE cid='" + objInvoice.cid + "'");
            }
            else
            {
                return "fail";
            }
        }

        public string Summa(string cid)
        {
            List<Customer> listcustomer = new List<Customer>();
            listcustomer = DbAccess.DbSingleCustomer("select * from tbl_customer where cid='" + cid + "'");

            return "";
        }

        public int GetInvoiceNumber()
        {
            return DbAccess.DbGetInvoiceNumber("SELECT * FROM tbl_invoice ORDER BY sno DESC LIMIT 1");

        }

        public List<Dictionary<string, object>> GetInvoiceCustomer(int invoiceno)
        {
            return DbAccess.DbASelect("SELECT i.*, c.fname, c.lname, c.phone, c.email, c.address FROM tbl_invoice as i INNER JOIN tbl_customer as c ON i.cid = c.cid where invoiceno ="+invoiceno);
        }

    }
}