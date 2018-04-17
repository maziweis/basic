using Fz.Common;
using Fz.Core.VModelAPI;
using FzDatabase.Resource;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class ImportResourceController : ApiController
    {

        // POST api/<controller>
        /// <summary>
        /// 导入mod资源
        /// </summary>
        /// <param name="files"></param>
        /// <param name="resources"></param>
        /// <returns></returns>
        public class FileResource
        {
            public string files { get; set; }
            public string resources { get; set; }
        }
        public string Post([FromBody]JObject fileresjson)
        {
                try
                {
                    FileResource fileres = JsonHelper.DecodeJson<FileResource>(fileresjson.ToString());
                    List<R_ResourceExport_File> filelist = JsonHelper.JosnDeserializer<R_ResourceExport_File>(fileres.files);
                    List<R_ResourceExport_Resource> resourcelist = JsonHelper.JosnDeserializer<R_ResourceExport_Resource>(fileres.resources);
                    using (var dbcontext = new fz_resourceEntities())
                    {
                        /////////////先增加文件信息//////////////
                        foreach (R_ResourceExport_File file in filelist)
                        {
                            r_files tempfile = dbcontext.r_files.Find(file.ID);
                            if (tempfile == null)
                            {
                                dbcontext.r_files.Add(new r_files
                                {
                                    Id = file.ID,
                                    FileName = file.FileName,
                                    ConvertStatus = file.ConvertStatus == null ? 0 : (int)file.ConvertStatus,
                                    EncryptStatus = file.EncryptStatus == null ? 0 : (int)file.EncryptStatus,
                                    FileDescription = file.FileDescription,
                                    FileExtension = file.FileExtension,
                                    FilePath = file.FilePath,
                                    FileSize = file.FileSize == null ? 0 : (int)file.FileSize,
                                    FileType = file.FileType == null ? 0 : (int)file.FileType,
                                    FinishStatus = (bool)file.FinishStatus,
                                    Height = file.Height == null ? 0 : (int)file.Height,
                                    UploadTime = file.UploadTime,
                                    Width = file.Width == null ? 0 : (int)file.Width
                                });
                            }

                        }
                        ////////////后增加资源信息//////////////////
                        foreach (R_ResourceExport_Resource resource in resourcelist)
                        {
                            r_resource tempresource = dbcontext.r_resource.Find(resource.ID);
                            if (tempresource == null)
                            {
                                dbcontext.r_resource.Add(new r_resource
                                {
                                    ResourceID = resource.ID,
                                    Applicable = resource.Applicable,
                                    AppraisedCounts = resource.AppraisedCounts,
                                    BookReelID = resource.BookReel,
                                    BreviaryImgUrl = resource.BreviaryImgUrl,
                                    Catalog = resource.Catalog,
                                    CollectCounts = resource.CollectCounts,
                                    ComeFrom = resource.ComeFrom,
                                    Copyright = resource.Copyrigh,
                                    CopyrightName = resource.CopyrighName,
                                    Description = resource.Description,
                                    EditionID = resource.Edition,
                                    FileID = resource.FileID,
                                    FileType = resource.FileType,
                                    GradeID = resource.Grade,
                                    IsDelete = resource.IsDelete,
                                    IsRecommend = resource.IsRecommend,
                                    IsVerify = resource.IsVerify,
                                    KeyWords = resource.KeyWords,
                                    MaterialID = resource.MaterialID == null ? null : resource.MaterialID,
                                    ModifyDate = resource.ModifyDate,
                                    Number = resource.Number,
                                    Purview = resource.Purview,
                                    Sort = (int)resource.Sort,
                                    SubjectID = resource.Subject,
                                    ResourceClass = resource.ResourceClass,
                                    ResourceLevel = resource.ResourceLevel,
                                    ResourceName = resource.Title,
                                    ResourceScanNum = resource.ScanCounts,
                                    ResourceSize = resource.ResourceSize,
                                    ResourceStyle = resource.ResourceStyle,
                                    ResourceType = resource.ResourceType,
                                    SchoolStage = resource.SchoolStage,
                                    TeachingModules = resource.TeachingModules,
                                    TeachingStep = resource.TeachingStep,
                                    TeachingStyle = resource.TeachingStyle,
                                    TimeSpan = resource.TimeSpan,
                                    ResourceDowLoadNum = resource.DownCounts,
                                    ResourceCreateDate = System.DateTime.Now,
                                    ResourceCollectNum = 0,
                                    ResourceCreaterID = "",
                                    ResourceCreaterName = "方直",
                                    ShareStauts = null
                                });
                            }

                        }
                        try
                        {
                            dbcontext.SaveChanges();
                            return "ok";
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }

                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }           
        }
    }
}