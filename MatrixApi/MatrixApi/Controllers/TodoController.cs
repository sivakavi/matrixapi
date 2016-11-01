using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MatrixApi.DataAccess;
using MatrixApi.Models;

namespace MatrixApi.Controllers
{
    public class TodoController : ApiController
    {
        private TodoAccess objTodoAccess = new TodoAccess();

        [HttpGet]
        [ActionName("getalltodo")]
        public HttpResponseMessage GetAllTodo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objTodoAccess.GetAllTodo());
        }

        [HttpGet]
        [ActionName("getallopentodo")]
        public HttpResponseMessage GetAllOpenTodo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objTodoAccess.GetAllOpenTodo());
        }

        [HttpGet]
        [ActionName("getallclosetodo")]
        public HttpResponseMessage GetAllCloseTodo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, objTodoAccess.GetAllCloseTodo());
        }

        [HttpGet]
        [ActionName("gettodobyid")]
        public HttpResponseMessage GetTodoById(int todoid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objTodoAccess.GetTodoById(todoid));
        }

        [HttpPost]
        [ActionName("addtodo")]
        public HttpResponseMessage AddTodo([FromBody]Todo objTodo)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objTodoAccess.AddTodo(objTodo));
        }

        [HttpPost]
        [ActionName("edittodo")]
        public HttpResponseMessage EditTodo([FromBody]Todo objTodo)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objTodoAccess.EditTodo(objTodo));
        }

        [HttpGet]
        [ActionName("closetodo")]
        public HttpResponseMessage CloseTodo(int todoid)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objTodoAccess.CloseTodo(todoid));
        }
    }
}
