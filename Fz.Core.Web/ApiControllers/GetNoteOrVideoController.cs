using Fz.Room.VModel;
using FzDatabase.Resource;
using FzDatabase.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetNoteOrVideoController : ApiController
    {
        /// <summary>
        /// 老师获取课堂资源（课堂笔记）
        /// </summary>
        /// <param name="UserID">老师ID</param>
        /// <param name="SubjectID"></param>
        /// <param name="BookID"></param>
        /// <param name="UnitID"></param>
        /// <returns></returns>
        public List<ClassResource> GET(string UserID, int SubjectID, int UnitID)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["FileServer"];
            List<ClassResource> query;
            using (var db = new fz_resourceEntities())
            {
                query = (from order in db.r_files
                         join d in db.r_resource on order.Id equals d.FileID
                         where d.ResourceCreaterID == UserID && d.SubjectID == SubjectID && d.Catalog == UnitID                         
                         select new ClassResource
                         {
                             FileID = d.FileID,
                             ResourceName = order.FileName,
                             ResourceUrl = order.FilePath,
                             FileExtension = order.FileExtension
                         }).ToList();
                foreach (ClassResource cr in query)
                {
                    cr.ResourceUrl = path + "KingsunFiles/SmartClassFile/" + Bll.SyUserBll.GetAccount(UserID) + "/" + cr.FileID + "." + cr.FileExtension;
                }
            }
            return query;
        }
    }
}
