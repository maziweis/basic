using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fz.Room.VModel;
using FzDatabase.Room;
using FzDatabase.Basic;
using FzDatabase.Resource;

namespace Fz.Core.Web.ApiControllers
{
    public class GetAllUnitInfoTechController : ApiController
    {
        public PageInit GET(string UserID, int SubjectID, int GradeID)
        {
            PageInit m = new PageInit();
            clr_electronic_book eb = null;
            List<r_resource> lRes = null;
            using (var db = new fz_wisdomcampusEntities())
            {
                eb = db.clr_electronic_book.Where(w => w.UserID == UserID && w.SubjectID == SubjectID && w.GradeID == GradeID).FirstOrDefault();
            }
            //using (var db1 = new fz_resourceEntities())
            //{
            //    lRes = db1.r_resource.Where(w => w.ResourceCreaterID == UserID && w.SubjectID == SubjectID && w.GradeID == eb.GradeID).ToList();
            //}

            //foreach (var ds in eb)
            //{
            //    m.Add(new PageInit
            //    {
            //        BookID = ds.BookID,
            //        BookName = ds.BookID == null ? "" : Bll.DictTextbookBll.GetName((int)ds.BookID),
            //        UnitInfo = Bll.DictTextbookCatalogBll.GetTextbookCatalogByBookid((int)ds.BookID).Select(s => new UnitInfo
            //        {
            //            UnitID = s.Id,
            //            UnitName = s.Name
            //        }).ToList(),
            //        UserID = ds.UserID
            //    });
            //}
            m.UserID = UserID;
            m.BookID = eb.BookID;
            m.BookName = eb.BookID == null ? "" : Bll.DictTextbookBll.GetName((int)eb.BookID);
            //m.UnitInfo = lRes.Select(s => new UnitInfo
            //{
            //    UnitID = s.Catalog,
            //    UnitName = s.KeyWords
            //}).ToList();
            m.UnitInfo = Bll.DictTextbookCatalogBll.GetTextbookCatalogByBookid((int)eb.BookID).Select(s => new UnitInfo
            {
                UnitID = s.Id,
                UnitName = s.Name
            }).ToList();
            return m;
        }
    }
}
