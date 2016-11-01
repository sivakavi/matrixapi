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
    public class TodoAccess
    {
        public List<Dictionary<string, object>> GetAllTodo()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_todo");
        }

        public List<Dictionary<string, object>> GetAllOpenTodo()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_todo where status = 0");
        }

        public List<Dictionary<string, object>> GetAllCloseTodo()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_todo where status = 1");
        }

        public List<Dictionary<string, object>> GetTodoById(int todoid)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_todo WHERE todoid='" + todoid + "'");
        }

        public string AddTodo(Todo objTodo)
        {
            return DbAccess.DbAInsert("insert into tbl_todo VALUES ('NULL','" + objTodo.todoname
                    + "', 0, '" + objTodo.createdat
                    + "', '" + objTodo.updatedat
                    + "')");
        }

        public string EditTodo(Todo objTodo)
        {
            return DbAccess.DbAInsert("UPDATE tbl_todo SET "
            + "todoname='" + objTodo.todoname + "',"
            + "updatedat='" + objTodo.updatedat + "' WHERE todoid='" + objTodo.todoid + "'");
        }

        public string CloseTodo(int todoid)
        {
            return DbAccess.DbAInsert("UPDATE tbl_todo SET status = 1 WHERE todoid='" + todoid + "'");
        }
    }
}