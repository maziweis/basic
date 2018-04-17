using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    [ValidateInput(false)]
    public class BaseController : Controller
    {
        private VModel.SyPassport.UserInfo userInfo = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseController()
        {
            userInfo = System.Web.HttpContext.Current.Session["UserInfo"] as VModel.SyPassport.UserInfo;
        }

        /// <summary>
        /// 获取用户id
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            return userInfo == null ? null : userInfo.Id;
        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return userInfo == null ? null : userInfo.Name;
        }

        /// <summary>
        /// 获取用户帐号
        /// </summary>
        /// <returns></returns>
        public string GetUserAccount()
        {
            return userInfo == null ? null : userInfo.Account;
        }
        /// <summary>
        /// 获取用户学科
        /// </summary>
        /// <returns></returns>
        public int? GetUserSubjectId()
        {
            using (var db = new fz_basicEntities())
            {
                if(userInfo == null)
                {
                    return null;
                }
              sy_teacher teacher =  db.sy_teacher.Where(w => w.UserId == userInfo.Id).FirstOrDefault();
              return teacher == null ? null : teacher.Subject;
            }
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