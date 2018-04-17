using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Resource.Web.ApiControllers
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseApiController()
        {

        }

        /// <summary>
        /// 获取FileServer的http地址
        /// </summary>
        /// <returns></returns>
        public string GetFileServerHttp()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["FileServer"];
            if (path.Last() == '/')
            {
                path = path.Substring(0, path.Length - 1);
            }
            return path;
        }
        /// <summary>
        /// 获取FileServer的http地址
        /// </summary>
        /// <returns></returns>
        public string GetFileServer()
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["FileAddress"];
            if (path.Last() == '/')
            {
                path = path.Substring(0, path.Length - 1);
            }
            return path;
        }
        /// <summary>
        /// 获取FilePath地址
        /// </summary>
        /// <param name="oldPath"></param>
        /// <returns></returns>
        public string GetFilePath(string oldPath)
        {
            return oldPath.Replace(@"\", @"/");
        }
    }
}