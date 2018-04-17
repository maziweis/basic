using Fz.Core.VModelAPI;
using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetUserInfoController : ApiController
    {

        // GET api/<controller>/5
        /// <summary>
        /// 根据帐号获取用户信息
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        public C_UserInfo Get(string id)
        {
            C_UserInfo userinfo = null;

            using (var db = new fz_basicEntities())
            {
                sy_user m = db.sy_user.Where(w => w.Account == id.Trim()).FirstOrDefault();
                int tid = db.sy_teacher.Where(w => w.UserId == m.Id).Select(s => s.Id).FirstOrDefault();
                if (m != null)
                {
                    userinfo = new C_UserInfo();
                    userinfo.Id = m.Id;
                    userinfo.Type = m.Type;
                    userinfo.Account = m.Account;
                    userinfo.Name = m.Name;
                    userinfo.Subject = 3;
                    userinfo.userClass = db.sy_class.Where(w => db.sy_teacher_and_class_and_subject.Any(a => a.TeacherId == tid && a.ClassId == w.Id)).Select(s => new C_UserClass
                    {
                        ClassId = s.Id,
                        ClassName = s.Name,
                        GradeId = s.sy_grade.Id,
                        GradeName = s.sy_grade.Name
                    }).ToArray();
                }
            }

            return userinfo;
        }
    }
}