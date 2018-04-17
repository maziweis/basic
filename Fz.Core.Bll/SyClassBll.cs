using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class SyClassBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_class> GetList()
        {
            List<sy_class> list = Common.Caches.GetCache("sy_class") as List<sy_class>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_class.OrderBy(o => o.Sort).ToList();
                }
                Common.Caches.SetCache("sy_class", list);
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<VModel.SyClass.Grid> GetGrid(VModel.SyClass.Index m)
        {
            List<VModel.SyClass.Grid> list = new List<VModel.SyClass.Grid>();
            IQueryable<sy_class> dbList = null;

            using (var db = new fz_basicEntities())
            {
                dbList = db.sy_class.Where(w => w.sy_grade.IsEnabled == true && w.sy_grade.IsGraduate == false).OrderByDescending(o => o.sy_grade.Year).ThenBy(o => o.Sort);

                if (m.GradeId != null)
                {
                    dbList = dbList.Where(w => w.GradeId == m.GradeId);
                }
                if (!string.IsNullOrWhiteSpace(m.Key))
                {
                    IQueryable<int> tIds = db.sy_teacher.Where(w => w.Name.Contains(m.Key)).Select(s => s.Id);
                    IQueryable<int> cIds = db.sy_teacher_and_class_and_subject.Where(w => tIds.Contains(w.TeacherId)).Select(s => s.ClassId).Distinct();
                    dbList = dbList.Where(w => cIds.Contains(w.Id));
                }

                list = dbList.Select(s => new VModel.SyClass.Grid
                {
                    Id = s.Id,
                    Name = s.Name,
                    GradeName = s.sy_grade.Name,
                    Year = s.sy_grade.Year,
                    Sort = s.Sort,
                    StudentCount = s.sy_student.Where(w => w.UserId != null && w.sy_user.IsEnabled).Count(),
                    IsEnabled = s.IsEnabled,
                    _GridTCS = s.sy_teacher_and_class_and_subject.Select(s1 => new VModel.SyClass.GridTCS { Subject = s1.Subject, TeacherId = s1.TeacherId }).ToList()
                }).ToList();
            }

            return list;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Add(VModel.SyClass.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_class dbm;
                dbm = db.sy_class.Where(w => w.GradeId == m.GradeId && w.Name == m.Name && w.IsEnabled).FirstOrDefault();
                if (dbm != null)
                {
                    return -1;
                }
                dbm = new sy_class
                {
                    Name = m.Name,
                    GradeId = (int)m.GradeId,
                    Sort = m.Sort,
                    IsEnabled = m.IsEnabled
                };
                dbm.sy_teacher_and_class_and_subject.Clear();

                if (m.TsGrid != null && m.TsGrid.Count > 0)
                {
                    foreach (var item in m.TsGrid)
                    {
                        if (item.TeacherId != null)
                        {
                            dbm.sy_teacher_and_class_and_subject.Add(new sy_teacher_and_class_and_subject
                            {
                                dict_subject = db.dict_subject.Find(item.SubjectId),
                                sy_teacher = db.sy_teacher.Find(item.TeacherId)
                            });
                        }
                    }
                }

                db.sy_class.Add(dbm);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_class");

            return 200;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyClass.Form GetEdit(int id)
        {
            List<VModel.SyClass.TeacherSubjectGrid> list = new List<VModel.SyClass.TeacherSubjectGrid>();
            sy_class dbm = null;

            using (var db = new fz_basicEntities())
            {
                dbm = db.sy_class.Find(id);

                Dictionary<int, string> subjectDict = DictSubjectBll.GetSelect();
                foreach (var key in subjectDict.Keys)
                {
                    list.Add(new VModel.SyClass.TeacherSubjectGrid
                    {
                        SubjectId = key,
                        TeacherId = db.sy_teacher_and_class_and_subject.Where(w => w.Subject == key && w.ClassId == id).Select(s => s.TeacherId).FirstOrDefault()
                    });
                }
            }

            return new VModel.SyClass.Form
            {
                Id = dbm.Id,
                Name = dbm.Name,
                GradeId = dbm.GradeId,
                Sort = dbm.Sort,
                IsEnabled = dbm.IsEnabled,
                TsGrid = list
            };
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SyClass.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                if (!m.IsEnabled)
                {
                    if (db.sy_student.Where(w => w.Class == m.Id && w.sy_user.IsEnabled).Count() > 0)
                    {
                        return -1;
                    }
                }
                sy_class dbm;
                dbm = db.sy_class.Where(w => w.GradeId == m.GradeId && w.Name == m.Name && w.IsEnabled).FirstOrDefault();
                if (dbm != null)
                {
                    if (dbm.Name != m.Name) {
                        return 100;
                    }                  
                }
                dbm = db.sy_class.Find(m.Id);
                dbm.Name = m.Name;
                dbm.GradeId = (int)m.GradeId;
                dbm.Sort = m.Sort;
                dbm.IsEnabled = m.IsEnabled;
                dbm.sy_teacher_and_class_and_subject.Clear();

                if (m.TsGrid != null && m.TsGrid.Count > 0)
                {
                    foreach (var item in m.TsGrid)
                    {
                        if (item.TeacherId != null)
                        {
                            dbm.sy_teacher_and_class_and_subject.Add(new sy_teacher_and_class_and_subject
                            {
                                dict_subject = db.dict_subject.Find(item.SubjectId),
                                sy_teacher = db.sy_teacher.Find(item.TeacherId)
                            });
                        }
                    }
                }

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_class");

            return 200;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            using (var db = new fz_basicEntities())
            {

                if (db.sy_student.Where(w => w.Class == id && w.sy_user.IsEnabled).Count() > 0)
                {
                    return -1;//班级中存在学生不能删除
                }
                if (db.sy_teacher.Where(w => w.sy_teacher_and_class_and_subject.Any(a => a.ClassId == id) && w.sy_user.IsEnabled).Count() > 0)
                {
                    return -2;//班级中存在教师不能删除
                }
                ///////////学生账号禁用置空学生年级和班级///////////
                List<sy_student> stulist = db.sy_student.Where(w => w.Class == id && w.sy_user.IsEnabled == false).ToList();
                foreach (sy_student stu in stulist) {
                    stu.Grade = null;
                    stu.Class = null;
                }
                ///////////老师账号被禁用删除///////////
                List<sy_teacher_and_class_and_subject> tealist = db.sy_teacher_and_class_and_subject.Where(w =>w.ClassId == id && w.sy_teacher.sy_user.IsEnabled == false).ToList();
                foreach (sy_teacher_and_class_and_subject tea in tealist)
                {
                    db.sy_teacher_and_class_and_subject.Remove(db.sy_teacher_and_class_and_subject.Find(tea.TeacherId,tea.ClassId,tea.Subject));
                }
                db.sy_class.Remove(db.sy_class.Find(id));
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_class");
            return 200;
        }


        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetSelect(int gid)
        {
            return GetList().Where(w => w.GradeId == gid && w.IsEnabled == true).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int id)
        {
            sy_class m = GetList().Where(w => w.Id == id).FirstOrDefault();
            return m == null ? "" : m.Name;
        }
        /// <summary>
        /// 当前年级下班级是否存在
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public static bool IsExist(string gradeName ,string className)
        {
            using (var db = new fz_basicEntities())
            {
                sy_grade grade = db.sy_grade.Where(w => w.Name == gradeName && !w.IsGraduate && w.IsEnabled).FirstOrDefault();
                if(grade != null)
                {
                    sy_class cla = db.sy_class.Where(w => w.GradeId == grade.Id && w.Name == className && !w.IsGraduate && w.IsEnabled).FirstOrDefault();
                    if (cla != null) {
                        return true;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// 当前年级下班级是否存在
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public static sy_class GetClass(int grade, string className)
        {
            using (var db = new fz_basicEntities())
            {
               sy_class cla = db.sy_class.Where(w => w.GradeId == grade && w.Name == className && !w.IsGraduate && w.IsEnabled).FirstOrDefault();
                return cla; 
            }
        }
        
    }
}
