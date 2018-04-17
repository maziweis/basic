using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class SyGradeBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_grade> GetList()
        {
            List<sy_grade> list = Common.Caches.GetCache("sy_grade") as List<sy_grade>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_grade.OrderBy(o => o.Sort).ToList();
                }
                Common.Caches.SetCache("sy_grade", list);
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<VModel.SyGrade.Grid> GetGrid(VModel.SyGrade.Index m)
        {
            using (var db = new fz_basicEntities())
            {
                List<VModel.SyGrade.Grid> gradelist = db.sy_grade.Where(w => w.IsGraduate == false).OrderByDescending(o => o.Year).Select(s => new VModel.SyGrade.Grid
                {
                    Id = s.Id,
                    Name = s.Name,
                    Year = s.Year,
                    Sort = s.Sort,
                    ClassCount = s.sy_class.Where(w=>w.IsEnabled).Count(),
                    StudentCount = s.sy_student.Where(w=>w.sy_user.IsEnabled).Count()
                }).ToList();
                return gradelist;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Add(VModel.SyGrade.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                if (db.sy_grade.Where(w => w.Year == m.Year).Count() > 0)
                {
                    return -1;//入学年份已存在
                }
                if (db.sy_grade.Where(w => w.IsGraduate == false && w.SGradeId == m.Name).Count() > 0)
                {
                    return -2;//当前年级已存在
                }

                db.sy_grade.Add(new sy_grade
                {
                    SGradeId = (int)m.Name,
                    Name = Common.Dict.Grade.GetVal((int)m.Name),
                    Year = (int)m.Year,
                  //  Sort = m.Sort,
                    IsEnabled = true,
                    IsGraduate = false
                });

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_grade");

            return 200;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyGrade.Form GetEdit(int id)
        {
            using (var db = new fz_basicEntities())
            {
                sy_grade dbm = db.sy_grade.Find(id);

                return new VModel.SyGrade.Form
                {
                    Id = dbm.Id,
                    Name = dbm.SGradeId,
                    Year = dbm.Year,
                    //Sort = dbm.Sort
                };
            }
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyGrade.FormSys GetEditSys(int id)
        {
            sy_grade dbm = GetList().Where(w => w.Id == id).FirstOrDefault();

            return new VModel.SyGrade.FormSys
            {
                Id = dbm.Id,
                Year = dbm.Year
            };
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SyGrade.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_grade dbm = db.sy_grade.Find(m.Id);

                if (dbm.Year != m.Year && db.sy_grade.Where(w => w.Year == m.Year).Count() > 0)
                {
                    return -1;//入学年份已存在
                }
                if (dbm.SGradeId != m.Name && db.sy_grade.Where(w => w.IsGraduate == false && w.SGradeId == m.Name).Count() > 0)
                {
                    return -2;//当前年级已存在
                }

                dbm.SGradeId = (int)m.Name;
                dbm.Name = Common.Dict.Grade.GetVal((int)m.Name);
                dbm.Year = (int)m.Year;
              //  dbm.Sort = m.Sort;

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_grade");

            return 200;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SyGrade.FormSys m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_grade dbm = db.sy_grade.Find(m.Id);

                if (dbm.Year != m.Year && db.sy_grade.Where(w => w.Year == m.Year).Count() > 0)
                {
                    return -1;//入学年份已存在
                }

                dbm.Year = (int)m.Year;

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_grade");

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
                if (db.sy_class.Where(w => w.GradeId == id).Count() > 0)
                {
                    return -1;//年级中存在班级不能删除
                }

                db.sy_class.RemoveRange(db.sy_class.Where(w => w.GradeId == id));
                db.sy_grade.Remove(db.sy_grade.Find(id));
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_class");
            Common.Caches.RemoveCache("sy_grade");
            return 200;
        }

        /// <summary>
        /// 获取毕业数据
        /// </summary>
        public static VModel.SyGrade.Graduate GetGraduate()
        {
            VModel.SyGrade.Graduate m = new VModel.SyGrade.Graduate();
            using (var db = new fz_basicEntities())
            {
                m.GraduateGrids = db.sy_class.Where(w => w.IsEnabled && w.GradeId == db.sy_grade.Where(w1 => w1.IsGraduate == false).OrderByDescending(o=>o.SGradeId).Select(s1 => s1.Id).FirstOrDefault()).Select(s => new VModel.SyGrade.GraduateGrid
                {
                    GradeName = s.sy_grade.Name,
                    ClassName = s.Name,
                    StudentCount = s.sy_student.Where(w=>w.sy_user.IsEnabled).Count()
                }).ToList();
                m.GradeName = m.GraduateGrids.Select(s => s.GradeName).FirstOrDefault();
                m.ClassCount = m.GraduateGrids.Count;
                m.StudentCount = m.GraduateGrids.Select(s => s.StudentCount).Sum();
            }

            return m;
        }

        /// <summary>
        /// 保存毕业数据
        /// </summary>
        public static int SaveGraduate()
        {
            using (var db = new fz_basicEntities())
            {
                var query = db.sy_grade.Where(w => w.IsGraduate == false);

                if (query.Count() <= 0)
                {
                    return -1;//没有适合毕业的年级
                }

                int min_year = query.Select(s => s.Year).Min();
                sy_grade grade = db.sy_grade.Where(w => w.Year == min_year).FirstOrDefault();

                if (grade == null || grade.Year == 0)
                {
                    return -1;//没有适合毕业的年级
                }
                //else if (db.sy_class.Where(w => w.GradeId == grade.Id).Count() <= 0)
                //{
                //    return -2;//没有适合毕业的班级
                //}
                //else if (db.sy_student.Where(w => w.Grade == grade.Id).Count() <= 0)
                //{
                //    return -3;//没有适合毕业的学生
                //}


                grade.IsGraduate = true;

                IQueryable<sy_class> classs = db.sy_class.Where(w => w.GradeId == grade.Id);
                foreach (var m in classs)
                {
                    m.IsGraduate = true;
                }

                IQueryable<sy_student> students = db.sy_student.Where(w => w.Grade == grade.Id);
                foreach (var m in students)
                {
                    m.IsGraduate = true;
                    m.sy_user.IsEnabled = false;
                }

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_grade");
            Common.Caches.RemoveCache("sy_class");
            Common.Caches.RemoveCache("sy_student");

            return 200;
        }

        /// <summary>
        /// 获取升级数据
        /// </summary>
        public static VModel.SyGrade.Up GetUp()
        {
            VModel.SyGrade.Up m = new VModel.SyGrade.Up();
            using (var db = new fz_basicEntities())
            {
                //m.UpGrids = db.sy_grade.Where(w => w.IsEnabled == true && w.IsGraduate == false && w.Id != db.sy_grade.Where(w1 => w1.IsEnabled == true).Select(s1 => s1.Id).Max()).Select(s => new VModel.SyGrade.UpGrid
                //{
                //    GradeName = s.Name,
                //    ClassName = s.sy_class.Select(s2 => s2.Name).ToList(),
                //    StudentCount = s.sy_student.Count
                //}).ToList();
                m.UpGrids = db.sy_grade.OrderBy(o => o.SGradeId).ThenBy(t=>t.Sort).Where(w => w.IsEnabled == true && w.IsGraduate == false && w.SGradeId != 7).Select(s => new VModel.SyGrade.UpGrid
                {
                    GradeName = s.Name,
                    ClassName = s.sy_class.Where(w=>w.IsEnabled).Select(s2 => s2.Name).ToList(),
                    StudentCount = s.sy_student.Where(w => w.sy_user.IsEnabled).Count()
                }).ToList();
                m.GradeCount = m.UpGrids.Count;
                m.ClassCount = m.UpGrids.Select(s3 => s3.ClassName.Count).Sum();
                m.StudentCount = m.UpGrids.Select(s => s.StudentCount).Sum();
            }

            return m;
        }

        /// <summary>
        /// 保存升级数据
        /// </summary>
        public static int SaveUp()
        {
            using (var db = new fz_basicEntities())
            {
                var query = db.sy_grade.Where(w => w.IsGraduate == false);
                if (query.Count() <= 0)
                {
                    return -2;//没有适合升级的年级
                }

                int min_year = query.Select(s => s.Year).Min();
                sy_grade grade = db.sy_grade.Where(w => w.Year == min_year).FirstOrDefault();
                if (grade != null)
                {
                    if (grade.SGradeId == 7)
                    {
                        return -1;//尚有学生未毕业！
                    }
                    else
                    {
                        IQueryable<sy_grade> grades = db.sy_grade.Where(w => w.IsGraduate == false);
                        foreach (var m in grades)
                        {
                            m.SGradeId = m.SGradeId + 1;
                            m.Name = Common.Dict.Grade.GetVal(m.SGradeId);
                        }
                        db.SaveChanges();
                    }
                }
            }

            Common.Caches.RemoveCache("sy_grade");
            Common.Caches.RemoveCache("sy_class");
            Common.Caches.RemoveCache("sy_student");

            return 200;
        }


        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetSelect()
        {
            return GetList().Where(w => w.IsEnabled == true && w.IsGraduate == false).OrderBy(o=>o.SGradeId).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int id)
        {
            sy_grade m = GetList().Where(w => w.Id == id).FirstOrDefault();
            return m == null ? "" : m.Name;
        }

        /// <summary>
        /// 获取入学年份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetYear(int id)
        {
            sy_grade m = GetList().Where(w => w.Id == id).FirstOrDefault();
            return m == null ? 0 : m.Year;
        }

        /// <summary>
        /// 获取入学年份列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetYears()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < 15; i++)
            {
                int y = DateTime.Now.Year - i;
                dict.Add(y, string.Format("{0}年", y));
            }
            return dict;
        }
        /// <summary>
        /// 年是否存在
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public static bool IsExist(string GradeName)
        {
            using (var db = new fz_basicEntities())
            {
                sy_grade grade = db.sy_grade.Where(w => w.Name == GradeName && !w.IsGraduate && w.IsEnabled).FirstOrDefault();
                if (grade != null) {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        ///  返回年级信息
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public static sy_grade GetGrade(string GradeName)
        {
            using (var db = new fz_basicEntities())
            {
                sy_grade grade = db.sy_grade.Where(w => w.Name == GradeName && !w.IsGraduate && w.IsEnabled).FirstOrDefault();
                return grade;
            }
        }
        
    }
}
