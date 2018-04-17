using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Collections.Generic;
using System.Web.Http.Filters;

namespace Fz.Core.Web
{
    public class ErrApiAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// API全局异常处理
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            WriteDatabase(filterContext);

            base.OnException(filterContext);
        }

        /// <summary>
        /// 写数据库
        /// </summary>
        /// <param name="e"></param>
        private void WriteDatabase(HttpActionExecutedContext filterContext)
        {
            System.Web.HttpContextWrapper context = ((System.Web.HttpContextWrapper)filterContext.Request.Properties["MS_HttpContext"]);
            string controllerName = filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionContext.ActionDescriptor.ActionName;
            string httpMethod = filterContext.Request.Method.ToString();

            SyLogErrorAdd data = new SyLogErrorAdd();
            data.ControllerName = controllerName;
            data.ActionName = actionName;
            data.HttpMethod = httpMethod;
            data.Url = filterContext.Request.RequestUri.ToString();
            data.Message = filterContext.Exception.Message;
            data.CreateIp = Common.Function.GetIp(context.Request);
            data.CreateTime = DateTime.Now;
            BigdataBll.SyLogErrorApi_Add(data);
        }
    }
}