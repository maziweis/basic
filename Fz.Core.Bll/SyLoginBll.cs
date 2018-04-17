using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Fz.Core.Bll
{
    public class SyLoginBll
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Check(string account, string password)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user user = db.sy_user.Where(w => w.Account == account.Trim()).FirstOrDefault();

                if (user == null)
                {
                    return -1;//账号不存在
                }
                else if (user.Password.Trim() != Common.Function.MD5Encrypt(password.Trim()))
                {
                    return -2;//密码错误
                }
                else if (user.IsEnabled == false)
                {
                    return -3;//账号已停用
                }
                else if (user.ExpiresTime != null && ((DateTime)user.ExpiresTime).Date < DateTime.Now.Date)
                {
                    return -3;//账号已停用
                }
                else if (user.Type == 26)
                {
                    return -4;//学生账号功能尚未开通
                }
            }

            using (var db = new fz_basicEntities())
            {
                //停用数据库中所有过期的账户
                DateTime DateNow = DateTime.Now.Date;
                var query = db.sy_user.Where(w => w.ExpiresTime != null && DbFunctions.TruncateTime(w.ExpiresTime) <= DbFunctions.TruncateTime(DateNow)).ToList();
                foreach (var q in query)
                {
                    q.IsExpires = true;
                    q.IsEnabled = false;
                }
                db.SaveChanges();
            }

            return 1;
        }

        /// <summary>
        /// 根据帐号获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static VModel.SyPassport.UserInfo GetUserInfo(string account)
        {
            VModel.SyPassport.UserInfo userinfo = null;
            using (var db = new fz_basicEntities())
            {
                sy_user user = db.sy_user.Where(w => w.Account == account.Trim()).FirstOrDefault();

                if (user != null)
                {
                    userinfo = new VModel.SyPassport.UserInfo();
                    userinfo.Id = user.Id;
                    userinfo.Account = user.Account;
                    userinfo.Name = user.Name;
                    userinfo.Type = user.Type;
                    userinfo.Navs = db.sy_nav.Where(w => w.sy_role.Where(w1 => w1.sy_user_and_role.Where(w2 => w2.UserId == user.Id && w2.sy_role.IsEnabled == true).Any()).Any()).Select(s => s.Id).ToArray();

                    var sids = db.sy_nav.Where(w => userinfo.Navs.Contains(w.Id)).Select(s => s.SId).Distinct();
                    var spids = db.sy_system.Where(w => sids.Contains(w.Id)).Select(s => s.PId);
                    userinfo.SysNavs = db.sy_system.Where(w => sids.Contains(w.Id) || spids.Contains(w.Id)).Select(s => s.Id).ToArray();
                }
            }

            return userinfo;
        }

        /// <summary>
        /// 判断跳转页面是否在相同域名下
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsSameDomain(string id)
        {
            return false;
        }
    }
}
