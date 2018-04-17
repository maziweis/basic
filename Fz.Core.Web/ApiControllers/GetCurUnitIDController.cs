using Fz.Room.VModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FzDatabase.Room;
namespace Fz.Core.Web.ApiControllers
{
    public class GetCurUnitIDController : ApiController
    {
        /// <summary>
        /// 获取当前单元ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public UnitInfo Get(string UserID,int BookID,int ClassID) {
            clr_pageInit unit = new clr_pageInit();
            using (var db = new fz_wisdomcampusEntities())
            {
                unit = db.clr_pageInit.Where(w => w.UserID == UserID.Trim()&&w.ClassID == ClassID && w.BookID == BookID && w.AspxName== "Teaching").FirstOrDefault();
            }
            UnitInfo UnitInfo = new UnitInfo();
            UnitInfo.UnitID = unit.UnitID;
            UnitInfo.UnitName = Bll.DictTextbookCatalogBll.GetName((int)unit.UnitID);

            return UnitInfo;
            //}
            //using (var db1 = new FzDatabase.ModMetaBreach.MODMetaDatabaseBranchEntities())
            //{
            //   return db1.tb_StandardCatalog.Where(w => w.ID == unit.UnitID).Select(s => new UnitInfo
            //    {
            //        UnitID = unit.UnitID,
            //        UnitName = s.FolderName
            //    }).FirstOrDefault();
            //}
        }
        
    }
}
