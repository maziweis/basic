using Fz.Core.VModelAPI;
using FzDatabase.Basic;
using FzDatabase.ModMetaBreach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetTextbookDictController : ApiController
    {
        // GET api/<controller>/5
        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="Stage">所属学段</param>
        /// <param name="Subject">所属学科</param>
        /// <param name="Grade">所属年级</param>
        /// <param name="Booklet">册别</param>
        /// <param name="Edition">版本</param>
        /// <returns></returns>
        public List<C_Textbook> Get(int? Stage, int? Subject, int? Grade, int? Booklet, int? Edition)
        {
            using (var db = new MODMetaDatabaseBranchEntities())
            {
                IQueryable<tb_StandardBook> query = db.tb_StandardBook.Where(w => w.Deleted == 0);

                if (Stage != null && Stage != 0) query = query.Where(w => w.Stage == Stage);
                if (Subject != null && Subject != 0) query = query.Where(w => w.Subject == Subject);
                if (Grade != null && Grade != 0) query = query.Where(w => w.Grade == Grade);
                if (Booklet != null && Booklet != 0) query = query.Where(w => w.Booklet == Booklet);
                if (Edition != null && Edition != 0) query = query.Where(w => w.Edition == Edition);

                return query.Select(s => new C_Textbook
                {
                    Id = s.ID,
                    BookName = s.BooKName,
                    Stage = s.Stage,
                    Subject = s.Subject,
                    Grade = s.Grade,
                    Edition = s.Edition,
                    Booklet = s.Booklet,
                }).ToList();
            }
        }
    }
}