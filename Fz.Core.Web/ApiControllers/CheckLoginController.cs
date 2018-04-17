using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class CheckLoginController : ApiController
    {

        // GET api/<controller>/5
        public int Get(string account, string password)
        {
            int rv = 1;
            using (var db = new fz_basicEntities())
            {
                sy_user user = db.sy_user.Where(w => w.Account == account.Trim()).FirstOrDefault();

                if (user == null)
                {
                    rv = -1;//账号不存在
                }
                else if (user.Password != Common.Function.MD5Encrypt(password.Trim()))
                {
                    rv = -2;//密码错误
                }
                else if (user.IsEnabled == false)
                {
                    rv = -3;//账号已停用
                }
                else
                {
                    db.SaveChanges();
                }
            }

            return rv;
        }
    }
}