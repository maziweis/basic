using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Fz.Core.Web
{
    /// <summary>
    /// 系统监控
    /// </summary>
    public class MonitorApiAttribute : ActionFilterAttribute
    {
        private const string Key = "__action_duration__";

        /// <summary>
        /// 执行开始
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var stopWatch = new Stopwatch();
            filterContext.Request.Properties[Key] = stopWatch;
            stopWatch.Start();

            //base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 执行结束
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            if (filterContext.Request.Properties.ContainsKey(Key))
            {
                var stopWatch = filterContext.Request.Properties[Key] as Stopwatch;
                if (stopWatch != null)
                {
                    stopWatch.Stop();

                    System.Web.HttpContextWrapper context = ((System.Web.HttpContextWrapper)filterContext.Request.Properties["MS_HttpContext"]);
                    string controllerName = filterContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    string actionName = filterContext.ActionContext.ActionDescriptor.ActionName;
                    string httpMethod = filterContext.Request.Method.ToString();

                    SyLogMonitorAdd data = new SyLogMonitorAdd();
                    data.ControllerName = controllerName;
                    data.ActionName = actionName;
                    data.HttpMethod = httpMethod;
                    data.Url = filterContext.Request.RequestUri.ToString();
                    data.CreateIp = Common.Function.GetIp(context.Request);
                    data.CreateTime = DateTime.Now;
                    data.ResponseTime = Convert.ToDecimal(stopWatch.Elapsed.TotalSeconds);

                    //if (filterContext.HttpContext.Session["UserInfo"] != null)
                    //{
                    //    Common.Model.UserInfo user = filterContext.HttpContext.Session["UserInfo"] as Common.Model.UserInfo;
                    //    if (user != null)
                    //    {
                    //        data.CreateUserId = user.Id;
                    //        data.CreateUserName = user.Name;
                    //    }
                    //}
                    BigdataBll.SyLogMonitorApi_Add(data);
                }
            }

            //base.OnActionExecuted(filterContext);
        }
    }
}
