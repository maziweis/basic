using Fz.Common;
using Fz.Core.VModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Fz.Resource.Web.ApiControllers
{
    public class UploadSmartClassController : ApiController
    {
        public KingResponse Post(string JsonFile)
        {
            rFileResource fResource = JsonHelper.DecodeJson<rFileResource>(JsonFile);
            string PrePath = System.Configuration.ConfigurationManager.AppSettings["FileAddress"] + "/KingsunFiles/SmartClassFile/"+ fResource.UserName;
            KingResponse response;
            try
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;
                HttpPostedFile file = files[files.AllKeys[0]];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    response = Bll.FileUploadBll.UploadSmartClassFile(file, PrePath, fResource);
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
