using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetAvatarByIdController : ApiController
    {
        public string get(string id)
        {
            string FilePath = string.Format("{0}{1}/{2}.{3}", System.Configuration.ConfigurationManager.AppSettings["FileServer"], "KingsunFiles/AvatarFile", id, "jpg");
            return FilePath;
        }
    }
}
