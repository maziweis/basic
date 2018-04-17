using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetAccountController : ApiController
    {

        // GET api/<controller>/5
        /// <summary>
        /// 根据凭证获取帐号
        /// </summary>
        /// <param name="ticket">凭证</param>
        /// <param name="ip">IP地址</param>
        /// <returns>凭证无效返回null</returns>
        public string Get(string ticket, string ip)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user_ticket m = db.sy_user_ticket.Find(ticket);
                if (m != null && m.IsDelete == false && m.Ip == ip)
                {
                    return m.Account;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}