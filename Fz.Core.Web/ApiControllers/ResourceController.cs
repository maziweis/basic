using Fz.Common;
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
    public class ResourceController : ApiController
    {
        // GET api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CatalogIds"></param>
        /// <returns></returns>
        public List<rResource> Get(string UserID,string CatalogIds)
        {
            using (var db = new fz_resourceEntities())
            {
                if (CatalogIds.IndexOf(',') > -1)
                {
                    string[] cataArray = CatalogIds.Split(',');
                    return db.r_resource.Where(w => (w.ResourceCreaterID == UserID || db.r_resource_favorite.Where(w1 => w1.UId == UserID).Select(s => s.ResourceID).Contains(w.ResourceID)) && cataArray.Contains(w.Catalog.ToString())).Select(s => new rResource
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
                }
                else
                {
                    int CataId = int.Parse(CatalogIds);
                    return db.r_resource.Where(w => (w.ResourceCreaterID == UserID || db.r_resource_favorite.Where(w1 => w1.UId == UserID).Select(s => s.ResourceID).Contains(w.ResourceID)) && w.Catalog == CataId).Select(s => new rResource
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
                }
            }
        }

        // POST api/<controller>
        /// <summary>
        /// 智慧教室上传文件
        /// </summary>
        /// <param name="Filedata">文件数据</param>
        /// <returns></returns>
        public bool Post([FromBody]List<rFileResource> Filedata)
        {
            using (var db = new fz_resourceEntities())
            {
              //  List<rFileResource> fileresList = JsonHelper.JosnDeserializer<rFileResource>(Filedata);
                foreach (rFileResource fr in Filedata)
                {
                    r_files file = db.r_files.Find(fr.FileID);
                    if (file == null)
                    {
                        file = new r_files();
                        file.Id = fr.FileID;
                        file.FileName = fr.FileName;
                        file.FilePath = fr.FilePath;
                        file.FileSize = Convert.ToInt32(fr.FileSize);
                        file.FileDescription = fr.FileDescription;
                        file.FileExtension = fr.FileExtension;
                        file.FileType = fr.FileType;
                        file.UploadTime = DateTime.Now;
                        db.r_files.Add(file);
                    }
                    r_resource resource = db.r_resource.Where(w => w.FileID == file.Id).FirstOrDefault();
                    if (resource == null)
                    {
                        resource = new r_resource();
                        resource.ResourceID = System.Guid.NewGuid().ToString();
                        resource.SubjectID = fr.SubjectID;
                        resource.FileID = file.Id;
                        resource.GradeID = fr.GradeID;
                        resource.EditionID = fr.EditionID;
                        resource.Catalog = fr.Catalog;
                        resource.ResourceName = fr.FileName;
                        resource.ResourceSize = fr.FileSize;
                        resource.Description = fr.FileDescription;
                        resource.ResourceStyle = fr.ResourceStyle;
                        resource.FileType = file.FileExtension;
                        resource.ShareStauts = 0;
                        resource.Copyright = 4;
                        resource.ResourceCreaterID = fr.UserID;
                        resource.ResourceCreaterName = fr.UserName;
                        resource.ResourceCreateDate = DateTime.Now;
                    }
                    else
                    {
                        resource.ResourceStyle = fr.ResourceStyle;
                    }

                    db.r_resource.Add(resource);
                }
                return db.SaveChanges() > 0;
            }
        }     
    }
}