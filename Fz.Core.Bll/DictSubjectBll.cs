using FzDatabase.Basic;
using System.Collections.Generic;
using System.Linq;

namespace Fz.Core.Bll
{
    public class DictSubjectBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<dict_subject> GetList()
        {
            List<dict_subject> list = Common.Caches.GetCache("dict_subject") as List<dict_subject>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.dict_subject.OrderBy(o => o.Sort).ToList();
                }
                Common.Caches.SetCache("dict_subject", list);
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<VModel.DictSubject.Grid> GetGrid(VModel.DictSubject.Index m)
        {
            using (var db = new fz_basicEntities())
            {
                return db.dict_subject.OrderByDescending(o => o.IsEnabled).ThenBy(o => o.Sort).Select(s => new VModel.DictSubject.Grid
                {
                    Id = s.Id,
                    Name = s.Name,
                    Sort = s.Sort,
                    IsEnabled = s.IsEnabled,
                    IsSystem = s.IsSystem
                }).ToList();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Add(VModel.DictSubject.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                db.dict_subject.Add(new dict_subject
                {
                    Name = m.Name,
                    Sort = m.Sort,
                    IsEnabled = m.IsEnabled,
                    IsSystem = false
                });

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("dict_subject");

            return 200;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.DictSubject.Form GetEdit(int id)
        {
            dict_subject dbm = GetList().Where(w => w.Id == id).FirstOrDefault();

            return new VModel.DictSubject.Form
            {
                Id = dbm.Id,
                Name = dbm.Name,
                Sort = dbm.Sort,
                IsEnabled = dbm.IsEnabled
            };
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.DictSubject.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                dict_subject dbm = db.dict_subject.Find(m.Id);

                dbm.Name = m.Name;
                dbm.Sort = m.Sort;
                dbm.IsEnabled = m.IsEnabled;

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("dict_subject");

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
                if (db.sy_teacher.Where(w => w.UserId != null && w.Subject == id).Count() > 0)
                {
                    return -1;//删除失败，该科目下存在活跃的老师！
                }

                db.dict_subject.Remove(db.dict_subject.Find(id));
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("dict_subject");
            return 200;
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetSelect()
        {
            return GetList().Where(w => w.IsEnabled == true).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int? id)
        {
            dict_subject m = GetList().Where(w => w.Id == id).FirstOrDefault();
            return m == null ? "" : m.Name;
        }

        /// <summary>
        /// 根据名称判断是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsExist(string name)
        {
            int count = GetList().Where(w => w.Name.Trim() == name.Trim()).Count();
            return count > 0 ? true : false;
        }
    }
}
