using FzDatabase.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class ResourceDeleteController : ApiController
    {
        // DELETE api/<controller>/5
        /// <summary>
        /// 移除资源
        /// </summary>
        /// <param name="ResourceIDs"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public class RemoveResource
        {
            public string ResourceIDs { get; set; }
            public string UserID { get; set; }
        }
        public bool Post([FromBody]RemoveResource removeRes)
        {
            using (var db = new fz_resourceEntities())
            {
                string fileID;
                if (removeRes.ResourceIDs.IndexOf(',') > -1)
                {
                    string[] resourceArray = removeRes.ResourceIDs.Split(',');
                    foreach (string resid in resourceArray)
                    {
                        r_resource resource = db.r_resource.Where(w => w.ResourceID == resid && w.ResourceCreaterID == removeRes.UserID).FirstOrDefault();
                        //////////用户自己上传的////////////
                        if (resource != null)
                        {
                            if (resource.ShareStauts != 2)
                            {
                                fileID = resource.FileID;
                                db.r_resource_approve.RemoveRange(db.r_resource_approve.Where(w => w.ResourceID == resid));                               
                                db.r_resource.Remove(db.r_resource.Find(resid));
                                db.r_files.Remove(db.r_files.Find(fileID));

                            }
                            else
                            {
                                resource.ResourceCreaterID = "shared";
                            }
                        }
                        /////////////用户收藏的资源////////////
                        else
                        {
                            r_resource_favorite resfavor = db.r_resource_favorite.Where(w => w.UId == removeRes.UserID && w.ResourceID == resid).FirstOrDefault();
                            if(resfavor != null)
                            {
                                db.r_resource_favorite.Remove(resfavor);
                            }                            
                        }
                    }
                }
                else
                {
                    r_resource resource = db.r_resource.Where(w => w.ResourceID == removeRes.ResourceIDs && w.ResourceCreaterID == removeRes.UserID).FirstOrDefault();
                    if (resource != null)
                    {
                        if (resource.ShareStauts != 2)
                        {
                             fileID = resource.FileID;
                            db.r_resource_approve.RemoveRange(db.r_resource_approve.Where(w => w.ResourceID == removeRes.ResourceIDs));
                            db.r_resource.Remove(db.r_resource.Find(removeRes.ResourceIDs));
                            db.r_files.Remove(db.r_files.Find(fileID));

                        }
                        else
                        {
                            resource.ResourceCreaterID = "shared";
                        }
                    }
                    /////////////用户收藏的资源////////////
                    else
                    {
                        r_resource_favorite resfavor = db.r_resource_favorite.Where(w => w.UId == removeRes.UserID && w.ResourceID == removeRes.ResourceIDs).FirstOrDefault();
                        db.r_resource_favorite.Remove(resfavor);

                    }

                }
                return db.SaveChanges() > 0;
            }
        }
    }
}