using Fz.Common;
using Fz.Core.WcfService.Contracts;
using FzDatabase.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// FileService服务
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// 获取文件详细信息
        /// </summary>
        /// <param name="FileID">文件ID</param>
        /// <returns></returns>
        public R_File GetFileByFileID(string FileID)
        {
            using (var db = new fz_resourceEntities())
            {
                R_File file = new R_File();
                file = db.r_files.Where(w => w.Id == FileID).Select(s => new R_File
                {
                    Id = s.Id,
                    FileDescription = s.FileDescription,
                    FileExtension = s.FileExtension,
                    FileName = s.FileName,
                    FilePath = s.FilePath,
                    FileSize = s.FileSize,
                    FileType = s.FileType,
                    Height = s.Height,
                    Width = s.Width
                }).FirstOrDefault();
                return file;
            }

        }
        /// <summary>
        /// 修改文件宽高
        /// </summary>
        /// <param name="file">文件对象</param>
        public void UpdateFileWH(R_File file)
        {
            using (var db = new fz_resourceEntities()) {
                r_files rfile = db.r_files.Where(w => w.Id == file.Id).FirstOrDefault();
                rfile.Width = file.Width;
                rfile.Height = file.Height;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// 智慧教室上传文件
        /// </summary>
        /// <param name="Filedata">文件数据</param>
        /// <returns></returns>
        public bool UploadFileFromClassRoom(string Filedata)
        {
            using (var db = new fz_resourceEntities())
            {
                List<R_FileResource> fileresList = JsonHelper.JosnDeserializer<R_FileResource>(Filedata);
                foreach (R_FileResource fr in fileresList)
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
                    r_resource resource = db.r_resource.Where(w=>w.FileID == file.Id).FirstOrDefault();
                    if(resource == null)
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
