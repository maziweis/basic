using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    [AllowAnonymous]
    public class SyPassportController : BaseController
    {
        public ActionResult Login(int? id)
        {
            VModel.SyPassport.UserInfo userinfo = Session["UserInfo"] as VModel.SyPassport.UserInfo;
            if (userinfo != null)
            {
                switch (userinfo.Type)
                {
                    case 12:
                    case 26:
                    case 27:
                        return RedirectToAction("Index", "ResourceHome");
                    case 4:
                        return RedirectToAction("Index", "SyUserManager");
                }
            }

            VModel.SyPassport.LoginModel m = new VModel.SyPassport.LoginModel();
            m.Account = Common.CookieHelper.GetCookieValue("account");
            m.pwd2 = Common.CookieHelper.GetCookieValue("pwd");
            m.ChkPwd = m.Account != null && m.Account.Trim() != "" ? true : false;
            m.SId = id;
            return View(m);
        }

        [HttpPost]
        public ActionResult Login(VModel.SyPassport.LoginModel m)
        {
            if (ModelState.IsValid)
            {
                int check = Bll.SyLoginBll.Check(m.Account, m.Password);

                switch (check)
                {
                    case 1://验证成功
                        string ticket = Guid.NewGuid().ToString();

                        //记录密码
                        if (m.ChkPwd)
                        {
                            Common.CookieHelper.SetCookie("account", m.Account, DateTime.Now.AddDays(30));
                            Common.CookieHelper.SetCookie("pwd", m.Password, DateTime.Now.AddDays(30));
                        }
                        else
                        {
                            Common.CookieHelper.ClearCookie("account");
                            Common.CookieHelper.ClearCookie("pwd");
                        }

                        VModel.SyPassport.UserInfo userinfo = Bll.SyLoginBll.GetUserInfo(m.Account);
                        userinfo.ticket = ticket;
                        Session["UserInfo"] = userinfo;

                        Bll.SyUserTicketBll.Add(ticket, m.Account, Common.Function.GetIp(Request));//将凭证写到数据库中

                        Common.CookieHelper.SetCookie("t", ticket);//将凭证写到Cookie

                        //页面跳转
                        string url = "";
                        if (m.SId == null)
                        {
                            switch (userinfo.Type)
                            {
                                case 12:
                                    url = "/ResourceHome/Index";
                                    break;
                                case 26:
                                    return Content("尚未开通学生用户功能！");
                                case 27:
                                    return Content("尚未开通家长用户功能！");
                                case 4:
                                    url = "/SyUserManager/Index";
                                    break;
                            }
                        }
                        else
                        {
                            Common.Dict.Model_System sys = Common.Dict.MySystem.GetVal((int)m.SId);
                            string homeUrl = sys == null ? "" : sys.DomainUrl + sys.HomeUrl;
                            if (Bll.SyLoginBll.IsSameDomain(""))
                            {
                                url = homeUrl;
                            }
                            else
                            {
                                url = string.Format("{0}?t={1}", homeUrl, ticket);
                            }
                        }
                        return Redirect(url);
                    case -1:
                        ModelState.AddModelError("Account", "你输入的用户名不存在！");
                        break;
                    case -2:
                        ModelState.AddModelError("Password", "你输入的密码有误！");
                        break;
                    case -3:
                        ModelState.AddModelError("Account", "你输入的用户名已停用！");
                        break;
                    case -4:
                        ModelState.AddModelError("Account", "学生相关功能尚未开通！");
                        break;
                }
            }
            return View(m);
        }

        [HttpPost]
        public JsonResult Exit()
        {
            System.Web.HttpContext.Current.Session["UserInfo"] = null;
            Common.CookieHelper.ClearCookie("t");
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }
    }
}