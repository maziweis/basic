using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web
{
    /// <summary>
    /// 系统监控
    /// </summary>
    public class MonitorAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 执行开始
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GetTimer(filterContext, "action").Start();
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 执行结束
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            GetTimer(filterContext, "action").Stop();
            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// 渲染开始
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(System.Web.Mvc.ResultExecutingContext filterContext)
        {
            GetTimer(filterContext, "render").Start();
            base.OnResultExecuting(filterContext);
        }

        /// <summary>
        /// 渲染结束
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            GetTimer(filterContext, "render").Stop();

            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();
            string httpMethod = filterContext.HttpContext.Request.HttpMethod;

            var actionTimer = GetTimer(filterContext, "action");
            var renderTimer = GetTimer(filterContext, "render");

            SyLogMonitorAdd data = new SyLogMonitorAdd();
            data.ControllerName = controllerName;
            data.ActionName = actionName;
            data.HttpMethod = httpMethod;
            data.Url = filterContext.HttpContext.Request.FilePath;
            data.CreateIp = Common.Function.GetIp(filterContext.HttpContext.Request);
            data.CreateTime = DateTime.Now;
            data.ResponseTime = Convert.ToDecimal(actionTimer.Elapsed.TotalSeconds);
            data.RenderTime = Convert.ToDecimal(renderTimer.Elapsed.TotalSeconds);
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
            BigdataBll.SyLogMonitorWeb_Add(data);

            base.OnResultExecuted(filterContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private Stopwatch GetTimer(ControllerContext context, string name)
        {
            string key = "__timer__" + name;
            if (context.HttpContext.Items.Contains(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }

            var result = new Stopwatch();
            context.HttpContext.Items[key] = result;
            return result;
        }
    }
}
