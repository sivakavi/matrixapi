using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace MatrixApi.Core
{
    public class DbAccess
    {
        private static string dbConnection = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public static List<Dictionary<string, object>> DbASelect(string query)
        {
            try
            {
                DataTable dt = new DataTable();

                using (MySqlConnection mySqlConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection))
                    {
                        mySqlConnection.Open();

                        using (MySqlDataAdapter da = new MySqlDataAdapter(mySqlCommand))
                        {
                            da.Fill(dt);
                        }

                        return DictionaryData(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static string DbAInsert(string query)
        {
            try
            {
                using (MySqlConnection objDbConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand DBcommand = new MySqlCommand(query, objDbConnection))
                    {
                        objDbConnection.Open();

                        int i = DBcommand.ExecuteNonQuery();

                        if (i == 1)
                        {
                            return "success";
                        }
                        else
                        {
                            return "fail";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static string DbLogin(string query)
        {
            try
            {
                using (MySqlConnection objDbConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand DBcommand = new MySqlCommand(query, objDbConnection))
                    {
                        MySqlDataReader DBreader;

                        objDbConnection.Open();

                        DBreader = DBcommand.ExecuteReader();

                        if (DBreader.HasRows)
                        {
                            DBreader.Read();
                            int active = Int32.Parse(DBreader["active"].ToString());
                            if (active == 1)
                            {
                                return "success";
                            }
                            else if (active == 0)
                            {
                                return "noactive";
                            }
                            else
                            {
                                return "";
                            }
                        }
                        else
                        {
                            return "fail";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static string DbChangePassword(string query)
        {
            try
            {
                using (MySqlConnection objDbConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand DBcommand = new MySqlCommand(query, objDbConnection))
                    {
                        MySqlDataReader DBreader;

                        objDbConnection.Open();

                        DBreader = DBcommand.ExecuteReader();

                        if (DBreader.Read())
                        {
                            return DBreader["password"].ToString();
                        }
                        else
                        {
                            return "nil";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static List<Dictionary<string, object>> DbChart(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("value", typeof(int));
                dt.Columns.Add("color", typeof(string));
                dt.Columns.Add("highlight", typeof(string));
                dt.Columns.Add("label", typeof(string));

                using (MySqlConnection objDbConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand DBcommand = new MySqlCommand(query, objDbConnection))
                    {
                        MySqlDataReader DBreader;

                        objDbConnection.Open();

                        DBreader = DBcommand.ExecuteReader();

                        while (DBreader.Read())
                        {
                            int v = Int32.Parse(DBreader["co"].ToString());
                            string c = DBreader["colorcode"].ToString();
                            string h = DBreader["colorcode"].ToString();
                            string l = DBreader["membertypename"].ToString();

                            dt.Rows.Add(v, c, h, l);
                            
                        }

                        return DictionaryData(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static List<Dictionary<string, object>> DbUserSearch(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("value", typeof(string));
                dt.Columns.Add("label", typeof(string));
                dt.Columns.Add("userid", typeof(int));
                
                using (MySqlConnection objDbConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand DBcommand = new MySqlCommand(query, objDbConnection))
                    {
                        MySqlDataReader DBreader;

                        objDbConnection.Open();

                        DBreader = DBcommand.ExecuteReader();

                        while (DBreader.Read())
                        {
                            int u = Int32.Parse(DBreader["userid"].ToString());
                            string v = DBreader["fname"].ToString() + " - " + u.ToString();
                            dt.Rows.Add(v, v, u);

                        }

                        return DictionaryData(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static List<Dictionary<string, object>> DbCustomerSearch(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("value", typeof(string));
                dt.Columns.Add("label", typeof(string));
                dt.Columns.Add("cid", typeof(string));

                using (MySqlConnection objDbConnection = new MySqlConnection(dbConnection))
                {
                    using (MySqlCommand DBcommand = new MySqlCommand(query, objDbConnection))
                    {
                        MySqlDataReader DBreader;

                        objDbConnection.Open();

                        DBreader = DBcommand.ExecuteReader();

                        while (DBreader.Read())
                        {
                            string u = DBreader["cid"].ToString();
                            string v = DBreader["fname"].ToString() + " - " + u;
                            dt.Rows.Add(v, v, u);

                        }

                        return DictionaryData(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public static List<Dictionary<string, object>> DictionaryData(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return rows;
        }
    }
}