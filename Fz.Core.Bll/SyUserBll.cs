using Fz.Resource.Bll;
using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class SyUserBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_user> GetList()
        {
            List<sy_user> list = Common.Caches.GetCache("sy_user") as List<sy_user>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_user.OrderBy(o => o.Account).ToList();
                }
                Common.Caches.SetCache("sy_user", list);
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static Common.Model.PList<VModel.SyUserManager.Grid> GetGrid(VModel.SyUserManager.Index m)
        {
            Common.Model.PList<VModel.SyUserManager.Grid> pl = new Common.Model.PList<VModel.SyUserManager.Grid>();
            pl.Data = new List<VModel.SyUserManager.Grid>();
            using (var db = new fz_basicEntities())
            {
                IQueryable<sy_user> dbList = db.sy_user.Where(w => w.Type == 4 && w.Id != "92E0AF7A-4C21-456C-82E8-B27E51CC3EDB").OrderBy(o => o.Account);
                switch (m.Type)
                {
                    case 1:
                        dbList = dbList.Where(w => w.IsExpires == false && w.IsEnabled == true);
                        break;
                    case 2:
                        dbList = dbList.Where(w => w.IsExpires == true || w.IsEnabled == false);
                        break;
                }
                if (!string.IsNullOrWhiteSpace(m.Key))
                {
                    dbList = dbList.Where(w => w.Account.Contains(m.Key) || w.Name.Contains(m.Key));
                }

                pl.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, dbList.Count());
                pl.Data = dbList.Skip((m.Grid.Pager.PageIndex - 1) * m.Grid.Pager.PageSize).Take(m.Grid.Pager.PageSize).Select(s => new VModel.SyUserManager.Grid
                {
                    Id = s.Id,
                    Account = s.Account,
                    Name = s.Name,
                    IsSystem = s.IsSystem,
                    ExpiresTime = s.ExpiresTime,
                    IsExpires = s.IsExpires,
                    IsEnabled = s.IsEnabled,
                    RoleNames = s.sy_user_and_role.Where(w1 => w1.sy_role.IsEnabled == true).Select(s1 => s1.sy_role.Name).ToList()
                }).ToList();
            }

            return pl;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int AddManager(VModel.SyUserManager.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Account = m.Account.Trim();       
                if (db.sy_user.Where(w => w.Account == m.Account).Count() > 0)
                {
                    return -1;//帐号已存在
                }
                sy_user dbm = new sy_user
                {
                    Id = Guid.NewGuid().ToString(),
                    Account = m.Account,
                    Name = m.Name.Trim(),
                    ExpiresTime = m.ExpiresTime,
                    IsEnabled = m.IsEnabled,
                    Password = Common.Function.MD5Encrypt("123456"),
                    IsSystem = false,
                    IsExpires = false,
                    Type = 4,
                    CreateTime = DateTime.Now
                };

                if (m.RoleIds != null)
                {
                    foreach (int item in m.RoleIds)
                    {
                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = item,
                            Time = DateTime.Now
                        });
                    }
                }

                db.sy_user.Add(dbm);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");

            return 200;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyUserManager.Form GetEditManager(string id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user dbm = db.sy_user.Find(id);

                return new VModel.SyUserManager.Form
                {
                    Id = dbm.Id,
                    Account = dbm.Account,
                    Name = dbm.Name,
                    ExpiresTime = dbm.ExpiresTime,
                    IsEnabled = dbm.IsEnabled,
                    RoleIds = dbm.sy_user_and_role.Select(s => s.sy_role.Id).ToList()
                };
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int EditManager(VModel.SyUserManager.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Account = m.Account.Trim();
                sy_user dbm = db.sy_user.Find(m.Id);
                if (dbm.Account != m.Account && db.sy_user.Where(w => w.Account == m.Account).Count() > 0)
                {
                    return -1;//帐号已存在
                }
                dbm.Account = m.Account;
                dbm.Name = m.Name.Trim();
                dbm.ExpiresTime = m.ExpiresTime;
                dbm.IsEnabled = m.IsEnabled;
                dbm.sy_user_and_role.Clear();

                if (m.RoleIds != null)
                {
                    foreach (int item in m.RoleIds)
                    {
                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = item,
                            Time = DateTime.Now
                        });
                    }
                }

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");

            return 200;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteManager(string id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user m = db.sy_user.Find(id);
                m.sy_user_and_role.Clear();
                db.sy_user.Remove(m);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
        }

        /// <summary>
        /// 删除多个
        /// </summary>
        public static void DeleteManagers(string[] ids)
        {
            using (var db = new fz_basicEntities())
            {
                IEnumerable<sy_user> list = db.sy_user.Where(w => ids.Contains(w.Id));
                foreach (var m in list)
                {
                    m.sy_user_and_role.Clear();
                    db.sy_user.Remove(m);
                }
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
        }

        /// <summary>
        /// 导出管理员用户
        /// </summary>
        public static List<VModel.SyUserManager.Grid> ExportManager(bool enable)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_user.Where(w => w.Type == 4 && w.IsEnabled == enable && w.Id != "92E0AF7A-4C21-456C-82E8-B27E51CC3EDB").OrderBy(o => o.Account).Select(s => new VModel.SyUserManager.Grid
                {
                    Id = s.Id,
                    Account = s.Account,
                    Name = s.Name,
                    ExpiresTime = s.ExpiresTime,
                    IsEnabled = s.IsEnabled,
                    RoleNames = s.sy_user_and_role.Select(s1 => s1.sy_role.Name).ToList()
                }).ToList();
            }
        }





        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static Common.Model.PList<VModel.SyUserTeacher.Grid> GetGrid(VModel.SyUserTeacher.Index m)
        {
            Common.Model.PList<VModel.SyUserTeacher.Grid> pl = new Common.Model.PList<VModel.SyUserTeacher.Grid>();
            pl.Data = new List<VModel.SyUserTeacher.Grid>();

            using (var db = new fz_basicEntities())
            {
                IQueryable<sy_user> dbList = db.sy_user.Where(w => w.Type == 12).OrderBy(o => o.Account);
                switch (m.Type)
                {
                    case 1:
                        dbList = dbList.Where(w => w.IsExpires == false && w.IsEnabled == true);
                        break;
                    case 2:
                        dbList = dbList.Where(w => w.IsExpires == true || w.IsEnabled == false);
                        break;
                }
                if (m.Subject != null)
                {
                    List<string> UserIds = SyTeacherBll.GetList().Where(w => w.Subject == m.Subject && w.UserId != null).Select(s => s.UserId).ToList();
                    dbList = dbList.Where(w => UserIds.Contains(w.Id));
                }
                if (!string.IsNullOrWhiteSpace(m.Key))
                {
                    dbList = dbList.Where(w => w.Account.Contains(m.Key) || w.Name.Contains(m.Key));
                }

                pl.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, dbList.Count());
                pl.Data = dbList.Skip((m.Grid.Pager.PageIndex - 1) * m.Grid.Pager.PageSize).Take(m.Grid.Pager.PageSize).Select(s => new VModel.SyUserTeacher.Grid
                {
                    Id = s.Id,
                    Account = s.Account,
                    Name = s.Name,
                    Subject = s.sy_teacher.Select(s2 => s2.Subject).FirstOrDefault(),
                    IsSystem = s.IsSystem,
                    ExpiresTime = s.ExpiresTime,
                    IsExpires = s.IsExpires,
                    IsEnabled = s.IsEnabled,
                    RoleNames = s.sy_user_and_role.Where(w1 => w1.sy_role.IsEnabled == true).Select(s1 => s1.sy_role.Name).ToList()
                }).ToList();
            }

            return pl;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int AddTeacher(VModel.SyUserTeacher.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Account = m.Account.Trim();
                if (db.sy_user.Where(w => w.Account == m.Account).Count() > 0)
                {
                    return -1;//帐号已存在
                }

                sy_user dbm = new sy_user
                {
                    Id = Guid.NewGuid().ToString(),
                    Account = m.Account,
                    Name = m.Name.Trim(),
                    ExpiresTime = m.ExpiresTime,
                    IsEnabled = m.IsEnabled,
                    Password = Common.Function.MD5Encrypt("123456"),
                    IsSystem = false,
                    IsExpires = false,
                    Type = 12,
                    CreateTime = DateTime.Now
                };

                if (m.RoleIds != null)
                {
                    foreach (int item in m.RoleIds)
                    {
                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = item,
                            Time = DateTime.Now
                        });
                    }
                }

                sy_teacher dbm2 = new sy_teacher
                {
                    UserId = dbm.Id,
                    Name = dbm.Name,
                    Subject = m.Subject
                };

                db.sy_user.Add(dbm);
                db.sy_teacher.Add(dbm2);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_teacher");

            return 200;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyUserTeacher.Form GetEditTeacher(string id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user dbm = db.sy_user.Find(id);

                return new VModel.SyUserTeacher.Form
                {
                    Id = dbm.Id,
                    Account = dbm.Account,
                    Name = dbm.Name,
                    Subject = dbm.sy_teacher.Select(s2 => s2.Subject).FirstOrDefault(),
                    ExpiresTime = dbm.ExpiresTime,
                    IsEnabled = dbm.IsEnabled,
                    RoleIds = dbm.sy_user_and_role.Select(s => s.sy_role.Id).ToList()
                };
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int EditTeacher(VModel.SyUserTeacher.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Account = m.Account.Trim();
                sy_user dbm = db.sy_user.Find(m.Id);
                if (dbm.Account != m.Account && db.sy_user.Where(w => w.Account == m.Account).Count() > 0)
                {
                    return -1;//帐号已存在
                }

                dbm.Account = m.Account;
                dbm.Name = m.Name.Trim();
                dbm.ExpiresTime = m.ExpiresTime;
                dbm.IsEnabled = m.IsEnabled;
                dbm.sy_user_and_role.Clear();

                if (m.RoleIds != null)
                {
                    foreach (int item in m.RoleIds)
                    {
                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = item,
                            Time = DateTime.Now
                        });
                    }
                }

                sy_teacher dbm1 = db.sy_teacher.FirstOrDefault(w => w.UserId == m.Id);
                if (dbm1 != null)
                {
                    dbm1.Name = m.Name;
                    dbm1.Subject = m.Subject;
                }

                db.SaveChanges();
            }
            Task excetion =  MyResourceBll.UpdateResourceCreaterName(m.Id, m.Name);
            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_teacher");

            return 200;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteTeacher(string id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user m = db.sy_user.Find(id);
                m.sy_user_and_role.Clear();
                db.sy_user.Remove(m);

                sy_teacher m1 = db.sy_teacher.FirstOrDefault(w => w.UserId == id);
                if (m1 != null)
                    m1.UserId = null;

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_teacher");
        }

        /// <summary>
        /// 删除多个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteTeachers(string[] ids)
        {
            using (var db = new fz_basicEntities())
            {
                IEnumerable<sy_user> list = db.sy_user.Where(w => ids.Contains(w.Id));
                foreach (var m in list)
                {
                    m.sy_user_and_role.Clear();
                    db.sy_user.Remove(m);

                    sy_teacher m1 = db.sy_teacher.FirstOrDefault(w => w.UserId == m.Id);
                    if (m1 != null)
                        m1.UserId = null;
                }

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_teacher");
        }

        /// <summary>
        /// 导出教职工用户
        /// </summary>
        public static List<VModel.SyUserTeacher.Grid> ExportTeacher(bool enable)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_user.Where(w => w.Type == 12 && w.IsEnabled == enable).OrderBy(o => o.Account).Select(s => new VModel.SyUserTeacher.Grid
                {
                    Id = s.Id,
                    Account = s.Account,
                    Name = s.Name,
                    Subject = s.sy_teacher.Select(s2 => s2.Subject).FirstOrDefault(),
                    ExpiresTime = s.ExpiresTime,
                    IsEnabled = s.IsEnabled,
                    RoleNames = s.sy_user_and_role.Select(s1 => s1.sy_role.Name).ToList()
                }).ToList();
            }
        }

        /// <summary>
        /// 导入教职工用户
        /// </summary>
        public static int ImportTeacher(List<VModel.SyUserTeacher.ImportData> list)
        {
            using (var db = new fz_basicEntities())
            {
                foreach (var m in list)
                {
                    sy_user user = db.sy_user.Where(w => w.Account == m.Account).FirstOrDefault();
                    if (user == null)
                    {
                        sy_user dbm = new sy_user
                        {
                            Id = Guid.NewGuid().ToString(),
                            Account = m.Account,
                            Name = m.Name,
                            IsEnabled = true,
                            Password = Common.Function.MD5Encrypt("123456"),
                            IsSystem = false,
                            IsExpires = false,
                            Type = 12,
                            CreateTime = DateTime.Now
                        };

                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = 3,
                            Time = DateTime.Now
                        });

                        sy_teacher dbm2 = new sy_teacher
                        {
                            UserId = dbm.Id,
                            Name = dbm.Name,
                            Subject = db.dict_subject.Where(w => w.Name == m.SubjectName).Select(s => s.Id).FirstOrDefault()
                        };

                        db.sy_user.Add(dbm);
                        db.sy_teacher.Add(dbm2);
                        db.SaveChanges();
                    }
                }
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_teacher");

            return 200;
        }

        /// <summary>
        /// 导入学生用户
        /// </summary>
        public static int ImportStudent(List<VModel.SyUserStudent.ImportData> list)
        {
            using (var db = new fz_basicEntities())
            {
                foreach (var m in list)
                {
                    sy_user user = db.sy_user.Where(w => w.Account == m.Account).FirstOrDefault();
                    if (user == null)
                    {
                        sy_user dbm = new sy_user
                        {
                            Id = Guid.NewGuid().ToString(),
                            Account = m.Account,
                            Name = m.Name,
                            IsEnabled = true,
                            Password = Common.Function.MD5Encrypt("123456"),
                            IsSystem = false,
                            IsExpires = false,
                            Type = 26,
                            CreateTime = DateTime.Now
                        };

                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = 4,
                            Time = DateTime.Now
                        });
                        int grade = Bll.SyGradeBll.GetGrade(m.Grade).Id;
                        int cla = Bll.SyClassBll.GetClass(grade, m.Class).Id;
                        sy_student dbm2 = new sy_student
                        {
                            UserId = dbm.Id,
                            Name = dbm.Name,
                            Sex = m.Sex,
                            Grade = grade,
                            Class = cla
                        };
                        db.sy_user.Add(dbm);
                        db.sy_student.Add(dbm2);
                        db.SaveChanges();
                    }
                }
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_student");

            return 200;
        }
        



        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static Common.Model.PList<VModel.SyUserStudent.Grid> GetGrid(VModel.SyUserStudent.Index m)
        {
            Common.Model.PList<VModel.SyUserStudent.Grid> pl = new Common.Model.PList<VModel.SyUserStudent.Grid>();
            pl.Data = new List<VModel.SyUserStudent.Grid>();

            using (var db = new fz_basicEntities())
            {
                IQueryable<sy_user> dbList = db.sy_user.Where(w => w.Type == 26).OrderBy(o => o.Account);
                switch (m.Type)
                {
                    case 1:
                        dbList = dbList.Where(w => w.IsExpires == false && w.IsEnabled == true && w.sy_student.Any(a => a.IsGraduate == false));
                        break;
                    case 2:
                        dbList = dbList.Where(w => w.IsExpires == true || w.IsEnabled == false || w.sy_student.Any(a => a.IsGraduate == true));
                        break;
                }
                if (m.IndexGrade != null)
                {
                    List<string> UserIds = SyStudentBll.GetList().Where(w => w.Grade == m.IndexGrade && w.UserId != null).Select(s => s.UserId).ToList();
                    dbList = dbList.Where(w => UserIds.Contains(w.Id));

                    if (m.IndexClass != null)
                    {
                        UserIds = SyStudentBll.GetList().Where(w => w.Class == m.IndexClass && w.UserId != null).Select(s => s.UserId).ToList();
                        dbList = dbList.Where(w => UserIds.Contains(w.Id));
                    }
                }
                if (!string.IsNullOrWhiteSpace(m.Key))
                {
                    dbList = dbList.Where(w => w.Account.Contains(m.Key) || w.Name.Contains(m.Key));
                }

                pl.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, dbList.Count());
                pl.Data = dbList.Skip((m.Grid.Pager.PageIndex - 1) * m.Grid.Pager.PageSize).Take(m.Grid.Pager.PageSize).Select(s => new VModel.SyUserStudent.Grid
                {
                    Id = s.Id,
                    Account = s.Account,
                    Name = s.Name,
                    Sex = s.sy_student.Select(s2 => s2.Sex).FirstOrDefault(),
                    Grade = s.sy_student.Select(s2 => s2.Grade).FirstOrDefault(),
                    Class = s.sy_student.Select(s2 => s2.Class).FirstOrDefault(),
                    IsSystem = s.IsSystem,
                    ExpiresTime = s.ExpiresTime,
                    IsExpires = s.IsExpires,
                    IsEnabled = s.IsEnabled,
                    RoleNames = s.sy_user_and_role.Where(w1 => w1.sy_role.IsEnabled == true).Select(s1 => s1.sy_role.Name).ToList()
                }).ToList();
            }
            return pl;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int AddStudent(VModel.SyUserStudent.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Account = m.Account.Trim();
                if (db.sy_user.Where(w => w.Account == m.Account).Count() > 0)
                {
                    return -1;//帐号已存在
                }

                sy_user dbm = new sy_user
                {
                    Id = Guid.NewGuid().ToString(),
                    Account = m.Account,
                    Name = m.Name.Trim(),
                    ExpiresTime = m.ExpiresTime,
                    IsEnabled = m.IsEnabled,
                    Password = Common.Function.MD5Encrypt("123456"),
                    IsSystem = false,
                    IsExpires = false,
                    Type = 26,
                    CreateTime = DateTime.Now
                };

                if (m.RoleIds != null)
                {
                    foreach (int item in m.RoleIds)
                    {
                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = item,
                            Time = DateTime.Now
                        });
                    }
                }

                sy_student dbm2 = new sy_student
                {
                    UserId = dbm.Id,
                    Name = dbm.Name,
                    Sex = m.Sex,
                    Grade = m.Grade,
                    Class = m.Class
                };

                db.sy_user.Add(dbm);
                db.sy_student.Add(dbm2);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_student");

            return 200;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyUserStudent.Form GetEditStudent(string id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user dbm = db.sy_user.Find(id);

                return new VModel.SyUserStudent.Form
                {
                    Id = dbm.Id,
                    Account = dbm.Account,
                    Name = dbm.Name,
                    Sex = dbm.sy_student.Select(s2 => s2.Sex).FirstOrDefault(),
                    Grade = dbm.sy_student.Select(s2 => s2.Grade).FirstOrDefault(),
                    Class = dbm.sy_student.Select(s2 => s2.Class).FirstOrDefault(),
                    ExpiresTime = dbm.ExpiresTime,
                    IsEnabled = dbm.IsEnabled,
                    RoleIds = dbm.sy_user_and_role.Select(s => s.sy_role.Id).ToList()
                };
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int EditStudent(VModel.SyUserStudent.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Account = m.Account.Trim();
                sy_user dbm = db.sy_user.Find(m.Id);
                if (dbm.Account != m.Account && db.sy_user.Where(w => w.Account == m.Account).Count() > 0)
                {
                    return -1;//帐号已存在
                }

                dbm.Account = m.Account;
                dbm.Name = m.Name.Trim();
                dbm.ExpiresTime = m.ExpiresTime;
                dbm.IsEnabled = m.IsEnabled;
                dbm.sy_user_and_role.Clear();

                if (m.RoleIds != null)
                {
                    foreach (int item in m.RoleIds)
                    {
                        dbm.sy_user_and_role.Add(new sy_user_and_role
                        {
                            UserId = dbm.Id,
                            RoleId = item,
                            Time = DateTime.Now
                        });
                    }
                }

                sy_student dbm1 = db.sy_student.FirstOrDefault(w => w.UserId == m.Id);
                if (dbm1 != null)
                {
                    dbm1.Name = m.Name;
                    dbm1.Sex = m.Sex;
                    dbm1.Grade = m.Grade;
                    dbm1.Class = m.Class;
                }

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_student");

            return 200;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteStudent(string id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user m = db.sy_user.Find(id);
                m.sy_user_and_role.Clear();
                db.sy_user.Remove(m);
                db.sy_student.Remove(db.sy_student.FirstOrDefault(w => w.UserId == id));
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_student");
        }

        /// <summary>
        /// 删除多个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void DeleteStudents(string[] ids)
        {
            using (var db = new fz_basicEntities())
            {
                IEnumerable<sy_user> list = db.sy_user.Where(w => ids.Contains(w.Id));
                foreach (var m in list)
                {
                    m.sy_user_and_role.Clear();
                    db.sy_user.Remove(m);
                    db.sy_student.Remove(db.sy_student.FirstOrDefault(w => w.UserId == m.Id));
                }

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
            Common.Caches.RemoveCache("sy_student");
        }

        /// <summary>
        /// 导出学生用户
        /// </summary>
        public static List<VModel.SyUserStudent.Grid> ExportStudent(bool enable)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_user.Where(w => w.Type == 26 && w.IsEnabled == enable).OrderBy(o => o.Account).Select(s => new VModel.SyUserStudent.Grid
                {
                    Account = s.Account,
                    Name = s.Name,
                    Sex = s.sy_student.Select(s2 => s2.Sex).FirstOrDefault(),
                    Grade = s.sy_student.Select(s2 => s2.Grade).FirstOrDefault(),
                    Class = s.sy_student.Select(s2 => s2.Class).FirstOrDefault(),
                    ExpiresTime = s.ExpiresTime,
                    IsEnabled = s.IsEnabled,
                    RoleNames = s.sy_user_and_role.Select(s1 => s1.sy_role.Name).ToList()
                }).ToList();
            }
        }





        /// <summary>
        /// 启用或禁用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enable"></param>
        public static void Enable(string id, bool enable)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user dbm = db.sy_user.Find(id);
                dbm.IsEnabled = enable;
                if (enable == true)
                {
                    dbm.ExpiresTime = null;
                    dbm.IsExpires = false;
                }
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
        }

        /// <summary>
        /// 启用或禁用多个
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="enable"></param>
        public static void Enables(string[] ids, bool enable)
        {
            using (var db = new fz_basicEntities())
            {
                IEnumerable<sy_user> list = db.sy_user.Where(w => ids.Contains(w.Id));
                foreach (var m in list)
                {
                    m.IsEnabled = enable;
                    if (enable == true)
                    {
                        m.ExpiresTime = null;
                        m.IsExpires = false;
                    }
                }
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_user");
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id"></param>
        public static void ResetPwd(string id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user user = db.sy_user.Find(id);
                user.Password = Common.Function.MD5Encrypt("123456");
                db.SaveChanges();
            }
            Common.Caches.RemoveCache("sy_user");
        }

        /// <summary>
        /// 根据用户id获取用户帐号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetAccount(string id)
        {
            return GetList().Where(w => w.Id == id).Select(s => s.Account).FirstOrDefault();
        }

        /// <summary>
        /// 根据用户id获取用户姓名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(string id)
        {
            return GetList().Where(w => w.Id == id).Select(s => s.Name).FirstOrDefault();
        }

        /// <summary>
        /// 根据角色ID导出用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<VModel.SyUserManager.Grid> ExportByRoleIds(List<int> ids)
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<string> uids = db.sy_user_and_role.Where(w => ids.Contains(w.RoleId)).OrderBy(o => o.RoleId).Select(s => s.UserId).Distinct();
                return db.sy_user.Where(w => uids.Contains(w.Id)).Select(s => new VModel.SyUserManager.Grid
                {
                    Account = s.Account,
                    Name = s.Name,
                    ExpiresTime = s.ExpiresTime,
                    IsEnabled = s.IsEnabled,
                    RoleNames = s.sy_user_and_role.Select(s1 => s1.sy_role.Name).ToList()
                }).ToList();
            }
        }

    }
}