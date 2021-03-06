﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Fz.Core.Web
{
    /// <summary>
    /// 访问权限
    /// </summary>
    public class AuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                VModel.SyPassport.UserInfo userInfo = filterContext.HttpContext.Session["UserInfo"] as VModel.SyPassport.UserInfo;
                if (userInfo == null)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        ContentResult cr = new ContentResult();
                        cr.Content = "<p style=\"padding:30px 0 30px 0;text-align:center\">你的账号已经下线了请回到首页</p><p style=\"text-align:center;margin:10px 0 20px 0;\"><a href=\"/SyPassport/Login\" style=\"display:inline-block;width:80px;height:30px;line-height:30px;background-color:#36aa9d;color:#fff;text-align:center;\">重新登录</a></p>";
                        cr.ContentType = "application/x-javascript";
                        filterContext.Result = cr;
                    }
                    else
                        filterContext.Result = new RedirectResult("/SyPassport/Login");
                }
            }
        }
    }
}