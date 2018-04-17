using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fz.Core.Web
{
    public class ErrAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 全局异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            //导向友好错误界面
            filterContext.Result = new RedirectResult("/Home/Index");
            filterContext.HttpContext.Response.Charset = "UTF-8";
            filterContext.HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;

            filterContext.ExceptionHandled = true;//重要！！告诉系统异常已处理！！如果没有这个步骤，系统还是会按照正常的异常处理流程走

            WriteDatabase(filterContext);


            Exception e = filterContext.Exception;
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //filterContext.Result = new JsonResult { Data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Exception, msg = "系统异常：" + e.Message } };
                filterContext.HttpContext.Response.Write("系统异常：" + e.Message);
            }
            else
            {
                filterContext.HttpContext.Response.Write("系统异常：" + e.Message);
            }

            base.OnException(filterContext);
        }

        /// <summary>
        /// 写数据库
        /// </summary>
        /// <param name="e"></param>
        private void WriteDatabase(ExceptionContext filterContext)
        {
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string httpMethod = filterContext.HttpContext.Request.HttpMethod;

            SyLogErrorAdd data = new SyLogErrorAdd();
            data.ControllerName = controllerName;
            data.ActionName = actionName;
            data.HttpMethod = httpMethod;
            data.Url = filterContext.HttpContext.Request.FilePath;
            data.Message = filterContext.Exception.Message;
            data.CreateIp = Common.Function.GetIp(filterContext.HttpContext.Request);
            data.CreateTime = DateTime.Now;

            if (filterContext.HttpContext.Session["UserInfo"] != null)
            {
                VModel.SyPassport.UserInfo user = filterContext.HttpContext.Session["UserInfo"] as VModel.SyPassport.UserInfo;
                if (user != null)
                {
                    data.CreateUserId = user.Id;
                    data.CreateUserName = user.Name;
                    data.CreateAccount = user.Account;
                }
            }

            BigdataBll.SyLogErrorWeb_Add(data);
        }
    }
}