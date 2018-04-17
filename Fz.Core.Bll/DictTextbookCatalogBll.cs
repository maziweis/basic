using FzDatabase.Basic;
using FzDatabase.ModMetaBreach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class DictTextbookCatalogBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<tb_StandardCatalog> GetList()
        {
            List<tb_StandardCatalog> list = Common.Caches.GetCache("dict_textbook_catalog") as List<tb_StandardCatalog>;
            if (list == null)
            {
                using (var db = new MODMetaDatabaseBranchEntities())
                {
                    list = db.tb_StandardCatalog.ToList();
                }
                Common.Caches.SetCache("dict_textbook_catalog", list);
            }
            return list;
        }

        public static List<VModelAPI.TextbookCatalog> GetTextbookCatalogByBookid(int bookId)
        {
            using (var db = new MODMetaDatabaseBranchEntities())
            {
                IQueryable<tb_StandardCatalog> query = db.tb_StandardCatalog.Where(w => w.Deleted == 0 && w.BookID == bookId);
                return query.Select(s => new VModelAPI.TextbookCatalog { Id = s.ID, PId = s.ParentID, Name = s.FolderName, PageStart = s.PageStart, PageEnd = s.PageEnd }).ToList();
            }
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int id)
        {
            return GetList().Where(w => w.ID == id).Select(s => s.FolderName).FirstOrDefault();
        }
    }
}
