using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetCoverByIdController : ApiController
    {
        // GET: api/tt/5
        public HttpResponseMessage Get(string id)
        {
            string path = string.Format(@"F:\FileWeb\KingsunFiles\img\{0}.jpg", id);
            var imgStream = new MemoryStream(File.ReadAllBytes(path));//从图片中读取流
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(imgStream)
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return resp;

            //return string.Format("http://192.168.3.190:8030/KingsunFiles/img/{0}.jpg", id);
        }
    }
}