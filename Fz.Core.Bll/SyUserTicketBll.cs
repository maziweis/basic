using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class SyUserTicketBll
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static void Add(string id, string account, string ip)
        {
            using (var db = new fz_basicEntities())
            {
                db.sy_user_ticket.Add(new sy_user_ticket
                {
                    Id = id,
                    Account = account,
                    Ip = ip,
                    ExpiresTime = DateTime.Now.AddHours(2),
                    IsDelete = false
                });

                db.SaveChanges();
            }
        }
    }
}
