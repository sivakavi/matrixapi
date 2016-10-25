using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MatrixApi.Core;

namespace MatrixApi.Controllers
{
    public class FileUploadController : ApiController
    {
        public HttpResponseMessage Post()
        {
            try
            {
                var reponseheader = Request;
                var header = reponseheader.Headers;
                string filename = string.Empty;

                if (header.Contains("filename"))
                {
                    filename = header.GetValues("filename").First();
                }
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                    if (httpPostedFile != null)
                    {
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/"), filename + ".png");
                        FileInfo file = new FileInfo(fileSavePath);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                        httpPostedFile.SaveAs(fileSavePath);
                        string addlogo = filename + ".png";
                        return Request.CreateResponse(HttpStatusCode.Created, addlogo);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch
            {
                throw;
            }
        }
    }
}
