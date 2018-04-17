using Fz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Fz.Resource.Web.ApiControllers
{
    public class UploadAvatarController : ApiController
    {
        [System.Web.Http.HttpPost]
        // POST api/<controller>
        public KingResponse Post(string id)
        {
            //string PrePath = System.Web.Hosting.HostingEnvironment.MapPath("~/KingsunFiles/AvatarFile");
            string PrePath = System.Configuration.ConfigurationManager.AppSettings["FileAddress"] + "/KingsunFiles/AvatarFile";
            KingResponse response;
            try
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;
                HttpPostedFile file = files[files.AllKeys[0]];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    response = Bll.FileUploadBll.UploadAvatarFile(file, PrePath, id);
                }
                else
                {
                    response = KingResponse.GetErrorResponse("文件不存在！");
                }

            }
            catch
            {
                response = KingResponse.GetErrorResponse("处理过程中出现错误！");
                return response;
            }
            return response;
        }
    }
}