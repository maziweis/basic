using Fz.Common;
using Fz.Core.WcfService.Contracts;
using FzDatabase.Basic;
using FzDatabase.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// 基础平台服务
    /// </summary>
    public class BasicService : IBasicService
    {
        /// <summary>
        /// 验证帐号密码是否正确
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="password">密码</param>
        /// <returns>返回：【1】成功，【-1】帐号不存在，【-2】密码错误，【-3】帐号已停用</returns>
        public int CheckLogin(string account, string password)
        {
            int rv = 1;
            using (var db = new fz_basicEntities())
            {
                sy_user user = db.sy_user.Where(w => w.Account == account.Trim()).FirstOrDefault();

                if (user == null)
                {
                    rv = -1;//账号不存在
                }
                else if (user.Password.Trim() != MD5Encrypt(password.Trim()))
                {
                    rv = -2;//密码错误
                }
                else if (user.IsEnabled == false)
                {
                    rv = -3;//账号已停用
                }
                else
                {
                    db.SaveChanges();
                }
            }

            return rv;
        }

        /// <summary>
        /// 根据帐号获取用户信息
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        public C_UserInfo GetUserInfo(string account)
        {
            C_UserInfo userinfo = null;

            using (var db = new fz_basicEntities())
            {
                sy_user m = db.sy_user.Where(w => w.Account == account.Trim()).FirstOrDefault();
                int tid = db.sy_teacher.Where(w => w.UserId == m.Id).Select(s => s.Id).FirstOrDefault();
                if (m != null)
                {
                    userinfo = new C_UserInfo();
                    userinfo.Id = m.Id;
                    userinfo.Type = m.Type;
                    userinfo.Account = m.Account;
                    userinfo.Name = m.Name;
                    userinfo.Subject = 3;
                    userinfo.userClass = db.sy_class.Where(w => db.sy_teacher_and_class_and_subject.Any(a => a.TeacherId == tid && a.ClassId == w.Id)).Select(s => new C_UserClass
                    {
                        ClassId = s.Id,
                        ClassName = s.Name,
                        GradeId = s.sy_grade.Id,
                        GradeName = s.sy_grade.Name
                    }).ToArray();
                }
            }

            return userinfo;
        }

        /// <summary>
        /// 根据凭证获取帐号
        /// </summary>
        /// <param name="ticket">凭证</param>
        /// <param name="ip">IP地址</param>
        /// <returns>凭证无效返回null</returns>
        public string GetAccount(string ticket, string ip)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user_ticket m = db.sy_user_ticket.Find(ticket);
                if (m != null && m.IsDelete == false && m.Ip == ip)
                {
                    return m.Account;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 获取全部用户与学科
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetUserAndSubjectDict()
        {
            using (var db = new fz_basicEntities())
            {
                var list = db.sy_teacher.Join(db.dict_subject, a => a.Subject, b => b.Id, (a, b) => new { a.UserId, b.Name }).Where(w => w.UserId != null);
                return list == null ? null : list.ToDictionary(k => k.UserId, v => v.Name);
            }
        }

        /// <summary>
        /// 获取学科列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetSubjectDict()
        {
            using (var db = new fz_basicEntities())
            {
                return db.dict_subject.Where(w => w.IsEnabled == true).OrderBy(o => o.Sort).ToDictionary(k => k.Id, v => v.Name);
            }
        }

        /// <summary>
        /// 获取年级列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetGradeDict()
        {
            return Common.Dict.Grade.Get();
        }

        /// <summary>
        /// 根据版本获取年级列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetGradeDictByEdition(int edition)
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<int> gradeIds = db.dict_textbook.Where(w => w.Edition == edition).Select(s => s.Grade).Distinct();
                return Common.Dict.Grade.Get().ToList().Where(w => gradeIds.Contains(w.Key)).ToDictionary(k => k.Key, v => v.Value);
            }
        }
        /// <summary>
        /// 根据版本获取年级列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetGradeDictByEditions(string editions)
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<int> gradeIds = db.dict_textbook.Where(w => editions.Contains(w.Edition.ToString())).Select(s => s.Grade).Distinct();
                return Common.Dict.Grade.Get().ToList().Where(w => gradeIds.Contains(w.Key)).ToDictionary(k => k.Key, v => v.Value);
            }
        }
        /// <summary>
        /// 根据年级获取班级列表
        /// </summary>
        /// <param name="grade">年级</param>
        /// <returns></returns>
        public Dictionary<int, string> GetClassDict(int grade)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_class.Where(w => w.GradeId == grade).OrderBy(o => o.Sort).ToDictionary(k => k.Id, v => v.Name);
            }
        }

        /// <summary>
        /// 根据班级ID获取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetStudentByClassId(int classId)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_student.OrderBy(o => o.Name).Where(w => w.Class == classId && w.UserId != null).ToDictionary(k => k.sy_user.Account, v => v.Name);
            }
        }

        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public C_Textbook GetTextbookById(int id)
        {
            using (var db = new fz_basicEntities())
            {
                dict_textbook s = db.dict_textbook.Find(id);

                return new C_Textbook
                {
                    Id = s.Id,
                    BookName = s.BookName,
                    Stage = s.Stage,
                    Subject = s.Subject,
                    Grade = s.Grade,
                    Edition = s.Edition,
                    Booklet = s.Booklet,
                    BookCover = s.Cover,
                    BookConfig = s.ConfigFile
                };
            }
        }

        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="Stage">所属学段</param>
        /// <param name="Subject">所属学科</param>
        /// <param name="Grade">所属年级</param>
        /// <param name="Booklet">册别</param>
        /// <param name="Edition">版本</param>
        /// <returns></returns>
        public List<C_Textbook> GetTextbookDict(int? Stage, int? Subject, int? Grade, int? Booklet, int? Edition)
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<dict_textbook> query = db.dict_textbook.Where(w => w.Deleted == 0);

                if (Stage != null && Stage != 0) query = query.Where(w => w.Stage == Stage);
                if (Subject != null && Subject != 0) query = query.Where(w => w.Subject == Subject);
                if (Grade != null && Grade != 0) query = query.Where(w => w.Grade == Grade);
                if (Booklet != null && Booklet != 0) query = query.Where(w => w.Booklet == Booklet);
                if (Edition != null && Edition != 0) query = query.Where(w => w.Edition == Edition);

                return query.Select(s => new C_Textbook
                {
                    Id = s.Id,
                    BookName = s.BookName,
                    Stage = s.Stage,
                    Subject = s.Subject,
                    Grade = s.Grade,
                    Edition = s.Edition,
                    Booklet = s.Booklet,
                    BookCover = s.Cover,
                    BookConfig = s.ConfigFile
                }).ToList();
            }
        }

        /// <summary>
        /// 根据教材获取目录
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public List<C_TextbookCatalog> GetTextbookCatalogDict(int bookId)
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<dict_textbook_catalog> query = db.dict_textbook_catalog.Where(w => w.Deleted == 0 && w.BookId == bookId);
                return query.Select(s => new C_TextbookCatalog { Id = s.Id, PId = s.ParentId, Name = s.FolderName, PageStart = s.PageStart, PageEnd = s.PageEnd }).ToList();
            }
        }

        /// <summary>
        /// 根据教材目录获取页码
        /// </summary>
        /// <param name="CatalogId"></param>
        /// <returns></returns>
        public int[] GetTextbookPageDict(int CatalogId)
        {
            List<int> list = new List<int>();

            dict_textbook_catalog query = null;
            using (var db = new fz_basicEntities())
            {
                query = db.dict_textbook_catalog.Find(CatalogId);
            }
            if (query != null && query.PageStart != null && query.PageEnd != null)
            {
                for (int i = (int)query.PageStart; i <= (int)query.PageEnd; i++)
                {
                    list.Add(i);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// 保存教材资源
        /// </summary>
        /// <param name="bookId">教材id</param>
        /// <param name="page">页码</param>
        /// <param name="content">内容</param>
        public void SaveTextbookResource(int bookId, int page, string content)
        {
            using (var db = new fz_basicEntities())
            {
                dict_textbook_resource m = db.dict_textbook_resource.Find(bookId, page);
                if (m == null)
                {
                    db.dict_textbook_resource.Add(new dict_textbook_resource
                    {
                        BookId = bookId,
                        PageIndex = page,
                        Content = content
                    });
                }
                else
                {
                    m.Content = content;
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取教材资源（水滴）
        /// </summary>
        /// <param name="bookId">教材id</param>
        /// <param name="pages">页码（多个）</param>
        /// <returns></returns>
        public string[] GetTextbookResource(int bookId, int[] pages)
        {
            using (var db = new fz_basicEntities())
            {
                return db.dict_textbook_resource.Where(w => w.BookId == bookId && pages.Contains(w.PageIndex)).Select(s => s.Content).ToArray();
            }
        }

        /// <summary>
        /// 获取教材版本
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetEditionDict()
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<dict_edition> query = db.dict_edition.Where(w => w.IsEnabled == true);

                return query.ToDictionary(k => k.Id, v => v.Name);
            }
        }

        /// <summary>
        /// 根据学科获取教材版本
        /// </summary>
        /// <param name="subject">学科</param>
        /// <returns></returns>
        public Dictionary<int, string> GetEditionDictBySubject(int subject)
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<int> editions = db.dict_textbook.Where(w => db.dict_edition_and_subject.Where(w1=>w1.SubjectId == subject && w1.IsEnabled).Select(s1=>s1.EditionId).Contains(w.Edition)).Select(s => s.Edition);

                return db.dict_edition.Where(w => editions.Contains(w.Id)).ToDictionary(k => k.Id, v => v.Name);
            }
        }

        /// <summary>
        /// 根据上级节点Id获取资源类型
        /// </summary>
        /// <param name="pid">上级节点Id</param>
        /// <returns></returns>
        public Dictionary<int, string> GetResourceType(int pid)
        {
            Dictionary<int, string> ResourceType = new Dictionary<int, string>();
            ResourceType.Add(27, "互动课件");
            ResourceType.Add(10, "课件");
            ResourceType.Add(12, "教案");
            ResourceType.Add(9, "试卷");                    
            ResourceType.Add(5, "音频");
            ResourceType.Add(4, "视频");
            ResourceType.Add(6, "动画");
            ResourceType.Add(28, "图片");
            ResourceType.Add(100, "其它");
            return ResourceType;
        }

        /// <summary>
        /// 根据教材id更新教材配置文件与教材封面
        /// </summary>
        /// <param name="id">教材id</param>
        /// <param name="stage">教材所属学段</param>
        /// <param name="subject">教材所属学科</param>
        /// <param name="grade">教材所属年级</param>
        /// <param name="booklet">教材所属册别</param>
        /// <param name="edition">教材所属版本</param>
        /// <param name="bookName">教材名称</param>
        /// <param name="config">教材db.js路径</param>
        /// <param name="cover">教材封面路径</param>
        /// <param name="remark">备注</param>
        public void UpdateTextbook(int id, int stage, int subject, int grade, int booklet, int edition, string bookName, string config, string cover, string remark)
        {
            using (var db = new fz_basicEntities())
            {
                dict_textbook m = db.dict_textbook.Find(id);
                if (m == null)//没找到新增
                {
                    db.dict_textbook.Add(new dict_textbook
                    {
                        Id = id,
                        Stage = stage,
                        Subject = subject,
                        Grade = grade,
                        Booklet = booklet,
                        Edition = edition,
                        BookName = bookName,
                        ConfigFile = config,
                        Cover = cover,
                        Remark = remark,
                        Deleted = 0,
                        CreateDateTime = System.DateTime.Now
                    });
                }
                else//找到修改
                {
                    m.Stage = stage;
                    m.Subject = subject;
                    m.Grade = grade;
                    m.Booklet = booklet;
                    m.Edition = edition;
                    m.BookName = bookName;
                    m.ConfigFile = config;
                    m.Cover = cover;
                    m.Remark = remark;
                    m.Deleted = 0;
                }

                db.SaveChanges();
            }
        }



        /// <summary>
        /// 给一个字符串进行MD5加密
        /// </summary>
        /// <param name="strText">待加密字符串</param>
        /// <returns>加密后的字符串</returns>
        private string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.Default.GetString(result);
        }
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="CatalogIds">资源Ids序列</param>
        /// <param name="type">资源分类 默认null为同步资源</param>
        /// <returns></returns>
        public List<R_Resource> GetResourceByCatalogIds(string CatalogIds, int? type)
        {
            using (var db = new fz_resourceEntities())
            {
                List<R_Resource> resourceList = new List<R_Resource>();
                IQueryable<r_resource> queryResource;
                if (type == null || type == 1)
                {
                    queryResource = db.r_resource.Where(w => (w.ResourceClass == null || w.ResourceClass == 1) && (w.Copyright == 1 || w.Copyright == 2));
                }
                else
                {
                    queryResource = db.r_resource.Where(w => w.ResourceClass == type && (w.Copyright == 1 || w.Copyright == 2));
                }
                if (CatalogIds.IndexOf(',') > -1)
                {
                    string[] cataArray = CatalogIds.Split(',');
                    resourceList = queryResource.Where(w => cataArray.Contains(w.Catalog.ToString())).Select(s => new R_Resource
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
                        ResourceCreaterName = s.ResourceCreaterName

                    }).ToList();
                    resourceList.ForEach(f => f.BreviaryImgUrl = string.Format("http://192.168.3.190:8030/KingsunFiles/img/{0}.jpg", f.ResourceID));
                }
                else
                {
                    int CataId = int.Parse(CatalogIds);
                    resourceList = queryResource.Where(w => w.Catalog == CataId).Select(s => new R_Resource
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
                        ResourceCreaterName = s.ResourceCreaterName
                    }).ToList();
                    resourceList.ForEach(f => f.BreviaryImgUrl = string.Format("http://192.168.3.190:8030/KingsunFiles/img/{0}.jpg", f.ResourceID));
                }

                return resourceList;
            }
        }
        /// <summary>
        /// 模糊查询资源
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="SubjectID">学科</param>
        /// <returns></returns>
        public List<R_Resource> GetResourceByKey(string key, int SubjectID)
        {
            using (var db = new fz_resourceEntities())
            {
                List<R_Resource> resourceList = new List<R_Resource>();
                string tempkey = key.Trim();
                IQueryable<r_resource> queryList = db.r_resource.Where(w => w.SubjectID == SubjectID && (w.ResourceName.Contains(tempkey) || w.Description.Contains(tempkey) || w.KeyWords.Contains(tempkey)));
                resourceList = queryList.Select(s => new R_Resource
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
                    ResourceCreaterName = s.ResourceCreaterName
                }).ToList();
                return resourceList;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CatalogIds"></param>
        /// <returns></returns>
        public List<R_Resource> GetResourceByUserID(string UserID, string CatalogIds)
        {
            using (var db = new fz_resourceEntities())
            {
                if (CatalogIds.IndexOf(',') > -1)
                {
                    string[] cataArray = CatalogIds.Split(',');
                    return db.r_resource.Where(w => (w.ResourceCreaterID == UserID || db.r_resource_favorite.Where(w1 => w1.UId == UserID).Select(s => s.ResourceID).Contains(w.ResourceID)) && cataArray.Contains(w.Catalog.ToString())).Select(s => new R_Resource
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
                    return db.r_resource.Where(w => (w.ResourceCreaterID == UserID || db.r_resource_favorite.Where(w1 => w1.UId == UserID).Select(s => s.ResourceID).Contains(w.ResourceID)) && w.Catalog == CataId).Select(s => new R_Resource
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
        /// <summary>
        /// 移除资源
        /// </summary>
        /// <param name="ResourceIDs"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool RemoveResourceByResourceIDs(string ResourceIDs, string UserID)
        {
            using (var db = new fz_resourceEntities())
            {

                if (ResourceIDs.IndexOf(',') > -1)
                {
                    string[] resourceArray = ResourceIDs.Split(',');
                    foreach (string resid in resourceArray)
                    {
                        r_resource resource = db.r_resource.Where(w => w.ResourceID == resid && w.ResourceCreaterID == UserID).FirstOrDefault();
                        //////////用户自己上传的////////////
                        if (resource != null)
                        {
                            if (resource.ShareStauts != 2)
                            {
                                db.r_resource_approve.RemoveRange(db.r_resource_approve.Where(w => w.ResourceID == resid));
                                db.r_resource.Remove(db.r_resource.Find(resid));
                                db.r_files.Remove(db.r_files.Find(resource.FileID));

                            }
                            else
                            {
                                resource.ResourceCreaterID = "shared";
                            }
                        }
                        /////////////用户收藏的资源////////////
                        else
                        {
                            r_resource_favorite resfavor = db.r_resource_favorite.Where(w => w.UId == UserID && w.ResourceID == resid).FirstOrDefault();
                            db.r_resource_favorite.Remove(resfavor);

                        }
                    }
                }
                else
                {
                    r_resource resource = db.r_resource.Where(w => w.ResourceID == ResourceIDs && w.ResourceCreaterID == UserID).FirstOrDefault();
                    if (resource != null)
                    {
                        if (resource.ShareStauts != 2)
                        {
                            string fileID = resource.FileID;
                            db.r_resource_approve.RemoveRange(db.r_resource_approve.Where(w => w.ResourceID == ResourceIDs));
                            db.r_resource.Remove(db.r_resource.Find(ResourceIDs));
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
                        r_resource_favorite resfavor = db.r_resource_favorite.Where(w => w.UId == UserID && w.ResourceID == ResourceIDs).FirstOrDefault();
                        db.r_resource_favorite.Remove(resfavor);

                    }

                }
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 导入mod资源
        /// </summary>
        /// <param name="files"></param>
        /// <param name="resources"></param>
        /// <returns></returns>
        public string ImportModResource(string files, string resources)
        {
            try
            {
                List<R_ResourceExport_File> filelist = JsonHelper.JosnDeserializer<R_ResourceExport_File>(files);
                List<R_ResourceExport_Resource> resourcelist = JsonHelper.JosnDeserializer<R_ResourceExport_Resource>(resources);
                using (var dbcontext = new fz_resourceEntities())
                {
                    /////////////先增加文件信息//////////////
                    foreach (R_ResourceExport_File file in filelist)
                    {
                        r_files tempfile = dbcontext.r_files.Find(file.ID);
                        if(tempfile == null)
                        {
                            dbcontext.r_files.Add(new r_files {
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
                            dbcontext.r_resource.Add(new r_resource {
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
                    try {
                        dbcontext.SaveChanges();
                        return "ok";
                    } catch (Exception ex) {
                        return ex.Message;
                    }
                   
                }              
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}