using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fz.Room.VModel;
using FzDatabase.Room;
namespace Fz.Core.Web.ApiControllers
{
    public class GetUnitInfoTController : ApiController
    {
        /// <summary>
        /// 老师获取单元目录
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="SubjectID"></param>
        /// <returns></returns>
        public PageInit GET(string UserID, int SubjectID,int GradeID)
        {
            string tid = UserID;            
            PageInit m = new PageInit();
            clr_electronic_book eb = null;
            using (var db = new fz_wisdomcampusEntities())
            {
                eb = db.clr_electronic_book.Where(w => w.UserID == tid && w.GradeID == GradeID).FirstOrDefault();
            }
            m.UserID = tid;
            m.BookID = eb.BookID;
            m.BookName = eb.BookID == null ? "" : Bll.DictTextbookBll.GetName((int)eb.BookID);
            m.UnitInfo = Bll.DictTextbookCatalogBll.GetTextbookCatalogByBookid((int)eb.BookID).Select(s => new UnitInfo
            {
                UnitID = s.Id,
                UnitName = s.Name
            }).ToList();
            return m;
        }
    }
}
