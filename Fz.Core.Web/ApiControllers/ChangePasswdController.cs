using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class ChangePasswdController : ApiController
    {
        public class Person
        {
            public string UserID { get; set; }
            public string OldPasswd { get; set; }
            public string NewPasswd { get; set; }
        }
        // PUT api/<controller>/5
        [HttpPost]
        public int Post(string id, [FromBody]Person model)
        {
            if(model == null)
            {
                return 0;   // 提交信息有误
            }
            else
            {
                if (model.OldPasswd == null)
                {
                    return 0;   // 提交信息有误
                }
                if (model.NewPasswd == null)
                {
                    return 0;   // 提交信息有误
                }
                using (var db = new fz_basicEntities())
                {
                    sy_user user = db.sy_user.Find(id);
                    if (user == null)
                    {
                        return -1; // 账号不存在
                    }
                    if (Common.Function.MD5Encrypt(model.OldPasswd) != user.Password)
                    {
                        return 100; // 原始密码错误
                    }
                    user.Password = Common.Function.MD5Encrypt(model.NewPasswd);
                    if (db.SaveChanges() == 0)
                    {
                        return 400; // 修改失败
                    }
                    else
                    {
                        return 200; // 密码修改成功
                    }

                }
            }        
        }
    }
}