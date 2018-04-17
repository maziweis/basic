using FzDatabase.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Resource.Web.ApiControllers
{
    public class ResourcePreviewController : BaseApiController
    {
       
        // GET api/<controller>/5
        public string Get(string id)
        {
            using (var db = new fz_resourceEntities())
            {
               r_files file = db.r_files.Find(id);
                if(file == null)
                {
                    return "该文件不存在";
                }
                string url = string.Format("{0}/KingsunFiles/{1}/{2}.{3}", GetFileServerHttp(),file.FilePath,file.Id,file.FileExtension);
                return url;
            }
        }     
    }
}