using Fz.Core.VModelAPI;
using FzDatabase.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetUserResourceByKeyController : ApiController
    {
        // GET api/<controller>/5
        public List<rResource> Get(string UserID,int SubjectID,string key)
        {
            using (var db = new fz_resourceEntities()) {
                List<rResource> resourcelist = db.r_resource.Where(w=>w.ResourceCreaterID == UserID && w.SubjectID == SubjectID && w.ResourceName.Contains(key)).Select(s=>new rResource
               {
                   ResourceID = s.ResourceID,
                   ResourceName = s.ResourceName,
                   FileID = s.FileID,
                   Description = s.Description,
                   SubjectID = s.SubjectID,
                   EditionID = s.EditionID,
                   GradeID = s.GradeID,
                   BookReelID = s.BookReelID,
                   SchoolStage = s.SchoolStage,
                   Catalog = s.Catalog,
                   FileType = s.FileType,
                   BreviaryImgUrl = s.BreviaryImgUrl,
                   KeyWords = s.KeyWords,
                   ResourceStyle = s.ResourceStyle,
                   ResourceType = s.ResourceType,
                   ResourceSize = s.ResourceSize,
                   ResourceCreaterID = s.ResourceCreaterID,
                   ResourceCreaterName = s.ResourceCreaterName,
                   ResourceCreaterDate = s.ResourceCreateDate
               }).ToList();
                return resourcelist;
            }
        }

    }
}