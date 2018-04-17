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
using FzDatabase.ModMetaBreach;

namespace Fz.Core.Web.ApiControllers
{
    public class GetUnitInfoTechController : ApiController
    {
        /// <summary>
        /// 老师端获取目录信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="SubjectID"></param>
        /// <param name="GradeID"></param>
        /// <returns></returns>
        public PageInit GET(string UserID, int SubjectID, int GradeID)
        {
            PageInit m = new PageInit();
            clr_electronic_book eb = null;
            List<r_resource> lRes = null;
            using (var db = new fz_wisdomcampusEntities())
            {
                eb = db.clr_electronic_book.Where(w => w.UserID == UserID && w.SubjectID == SubjectID && w.GradeID == GradeID).FirstOrDefault();
            }
            using (var db1 = new fz_resourceEntities())
            {
                lRes = db1.r_resource.Where(w => w.ResourceCreaterID == UserID && w.SubjectID == SubjectID && w.GradeID == eb.GradeID).ToList();
            }           
            
            m.UserID = UserID;
            m.BookID = eb.BookID;
            m.BookName = GetBookName(eb.BookID);
            List<UnitInfo> nonDuplicateList1= lRes.Select(s => new UnitInfo
            {
                UnitID = s.Catalog,
                UnitName = GetUnitNameTech(s.Catalog)
            }).Distinct().ToList();
            List<UnitInfo> nonDuplicateList2 = nonDuplicateList1.Where((x, i) => nonDuplicateList1.FindIndex(z => z.UnitID == x.UnitID) == i).ToList();//Lambda表达式去重 
            m.UnitInfo = nonDuplicateList2;
            //m.UnitInfo = Bll.DictTextbookCatalogBll.GetTextbookCatalogByBookid((int)eb.BookID).Select(s => new UnitInfo
            //{
            //    UnitID = s.Id,
            //    UnitName = s.Name
            //}).ToList();
            //string UnitID = null;
            //foreach (UnitInfo un in m.UnitInfo)
            //{
            //    if (un.UnitID == UnitID)
            //    {

            //    }
            //    UnitID=
            //}
            return m;
        }
        public string GetBookName(int? BookID)
        {
            tb_StandardBook book;
            using (var db1 = new MODMetaDatabaseBranchEntities())
            {
                book = db1.tb_StandardBook.Where(w => w.ID == BookID).FirstOrDefault();
            }
            if (book == null)
            {
                return "无教材";
            }
            else
            {
                return book.BooKName;
            }
        }
        public string GetUnitNameTech(int? unitid)
        {
            tb_StandardCatalog unit = new tb_StandardCatalog();
            tb_StandardCatalog unitP = new tb_StandardCatalog();
            string unitName;
            using (var db1 = new MODMetaDatabaseBranchEntities())
            {
                unit = db1.tb_StandardCatalog.Where(w => w.ID == unitid).FirstOrDefault();
                if (unit != null&&unit.ParentID != 0) {
                    unitP = db1.tb_StandardCatalog.Where(w => w.ID == unit.ParentID).FirstOrDefault();
                    unitName = unitP.FolderName + "-" + unit.FolderName;
                    return unitName;
                }
            }
            if(unit==null)
            {
                return "目录";
            }           
            return unit.FolderName;
        }
    }
}
