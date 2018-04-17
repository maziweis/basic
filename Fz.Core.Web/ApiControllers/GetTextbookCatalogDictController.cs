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
    public class GetTextbookCatalogDictController : ApiController
    {

        // GET api/<controller>/5
        /// <summary>
        /// 根据教材获取目录
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<C_TextbookCatalog> Get(int id)
        {
            using (var db = new MODMetaDatabaseBranchEntities())
            {
                IQueryable<tb_StandardCatalog> query = db.tb_StandardCatalog.Where(w => w.Deleted == 0 && w.BookID == id);
                return query.Select(s => new C_TextbookCatalog { Id = s.ID, PId = s.ParentID, Name = s.FolderName, PageStart = s.PageStart, PageEnd = s.PageEnd }).ToList();
            }
        }
    }
}