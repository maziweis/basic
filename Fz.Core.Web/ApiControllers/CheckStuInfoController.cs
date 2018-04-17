using Fz.Core.VModelAPI;
using Fz.Common.Model;
using Fz.Room.VModel;
using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class CheckStuInfoController : ApiController
    {
        public JsonData Get(string account, string password)
        {
            int rv = 1;
            List<Student> stu = null;
            using (var db = new fz_basicEntities())
            {
                sy_user user = db.sy_user.Where(w => w.Account == account.Trim()).FirstOrDefault();

                if (user == null)
                {
                    return new JsonData {  msg="账号不存在"};
                }
                else if (user.Password != Common.Function.MD5Encrypt(password.Trim()))
                {
                    return new JsonData { msg = "密码不正确" };
                }
                else if (user.IsEnabled == false)
                {
                    return new JsonData { msg = "账号已停用" };
                }
                string FilePath = string.Format("{0}{1}/{2}.{3}", System.Configuration.ConfigurationManager.AppSettings["FileServer"], "KingsunFiles/AvatarFile", user.Id, "jpg");
             
                sy_user m = db.sy_user.Where(w => w.Account == account.Trim()).FirstOrDefault();
                stu = db.sy_student.Where(w => w.UserId == m.Id).Select(s => new Student
                {
                    Id = s.Id,
                    IsGraduate = s.IsGraduate,
                    Name = s.Name,
                    Sex = s.Sex,
                    Type = m.Type,
                    UserID = m.Id,
                    year = s.Year,
                    Avatar= FilePath

                }).ToList();
                return new JsonData { data = stu };
            }
        }
    }
}
