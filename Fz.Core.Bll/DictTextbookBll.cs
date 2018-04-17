using FzDatabase.Basic;
using FzDatabase.ModMetaBreach;
using System.Collections.Generic;
using System.Linq;

namespace Fz.Core.Bll
{
    public class DictTextbookBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<tb_StandardBook> GetList()
        {
            List<tb_StandardBook> list = Common.Caches.GetCache("dict_textbook") as List<tb_StandardBook>;
            if (list == null)
            {
                using (var db = new MODMetaDatabaseBranchEntities())
                {
                    list = db.tb_StandardBook.ToList();
                }
                Common.Caches.SetCache("dict_textbook", list);
            }
            return list;
        }

        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="Stage">所属学段</param>
        /// <param name="Subject">所属学科</param>
        /// <param name="Grade">所属年级</param>
        /// <param name="Booklet">册别</param>
        /// <param name="Edition">版本</param>
        /// <returns></returns>
        public static List<VModelAPI.Textbook> GetTextbookDict(int? Stage, int? Subject, int? Grade, int? Booklet, int? Edition)
        {
            using (var db = new MODMetaDatabaseBranchEntities())
            {
                IQueryable<tb_StandardBook> query = db.tb_StandardBook.Where(w => w.Deleted == 0);

                if (Stage != null && Stage != 0) query = query.Where(w => w.Stage == Stage);
                if (Subject != null && Subject != 0) query = query.Where(w => w.Subject == Subject);
                if (Grade != null && Grade != 0) query = query.Where(w => w.Grade == Grade);
                if (Booklet != null && Booklet != 0) query = query.Where(w => w.Booklet == Booklet);
                if (Edition != null && Edition != 0) query = query.Where(w => w.Edition == Edition);

                return query.Select(s => new VModelAPI.Textbook
                {
                    Id = s.ID,
                    BookName = s.BooKName,
                    Stage = s.Stage,
                    Subject = s.Subject,
                    Grade = s.Grade,
                    Edition = s.Edition,
                    Booklet = s.Booklet
                }).ToList();
            }
        }

        /// <summary>
        /// 获取教材名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int id)
        {
            return GetList().Where(w => w.ID == id).Select(s => s.BooKName).FirstOrDefault();
        }
    }
}
