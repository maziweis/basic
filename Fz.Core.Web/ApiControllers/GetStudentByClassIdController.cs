using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetStudentByClassIdController : ApiController
    {
        // GET api/<controller>/5
        /// <summary>
        /// 根据班级ID获取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public Dictionary<string, string> Get(int id)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_student.OrderBy(o => o.Name).Where(w => w.Class == id && w.UserId != null).ToDictionary(k => k.sy_user.Account, v => v.Name);
            }
        }
    }
}