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
    public class GetUnitInfoController : ApiController
    {
        /// <summary>
        /// 学生端获取目录信息
        /// </summary>
        /// <param name="UserID">131b1f49-7064-4fba-a380-9c169701a818</param>
        /// <param name="SubjectID"></param>
        /// <returns></returns>
        public PageInit GET(string UserID, int SubjectID,int GradeID)
        {
            string tid = "";
            int? grade = null;
            List<r_resource> lRes=null;

            using (var db1 = new FzDatabase.Basic.fz_basicEntities())
            {
                var stu = db1.sy_student.Where(w => w.UserId == UserID.Trim()).FirstOrDefault();
                grade = stu.sy_grade.SGradeId+1;
                tid = db1.sy_teacher_and_class_and_subject.Where(w => w.ClassId == stu.Class && w.Subject == SubjectID).Select(s => s.sy_teacher.UserId).FirstOrDefault();
            }
            
            using (var db2 = new fz_resourceEntities())
            {
                lRes = db2.r_resource.Where(w => w.ResourceCreaterID == tid && w.SubjectID == SubjectID && w.GradeID == GradeID).ToList();
            }
            PageInit m = new PageInit();
            clr_electronic_book eb = null;
            using (var db = new fz_wisdomcampusEntities())
            {
                eb = db.clr_electronic_book.Where(w => w.UserID == tid && w.GradeID == GradeID && w.SubjectID==SubjectID).FirstOrDefault();
            }
            m.UserID = tid;
            m.BookID = eb.BookID;
            m.BookName = eb.BookID == null ? "" : Bll.DictTextbookBll.GetName((int)eb.BookID);
            List<UnitInfo> nonDuplicateList1 = lRes.Select(s => new UnitInfo
            {
                UnitID = s.Catalog,
                UnitName = GetUnitNameStu(s.Catalog)
            }).Distinct().ToList();
            List<UnitInfo> nonDuplicateList2 = nonDuplicateList1.Where((x, i) => nonDuplicateList1.FindIndex(z => z.UnitID == x.UnitID) == i).ToList();//Lambda表达式去重 
            m.UnitInfo = nonDuplicateList2;
            //m.UnitInfo = Bll.DictTextbookCatalogBll.GetTextbookCatalogByBookid((int)eb.BookID).Select(s => new UnitInfo
            //{
            //    UnitID = s.Id,
            //    UnitName = s.Name
            //}).ToList();
            return m;
        }
        public string GetUnitNameStu(int? unitid)
        {
            tb_StandardCatalog unit = new tb_StandardCatalog();
            using (var db = new MODMetaDatabaseBranchEntities())
            {
                unit = db.tb_StandardCatalog.Where(w => w.ID == unitid).FirstOrDefault();
            }
            if (unit == null)
            {
                return "目录";
            }
            return unit.FolderName;
        }
    }
}
