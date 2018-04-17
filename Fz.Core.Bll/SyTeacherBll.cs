using FzDatabase.Basic;
using System.Collections.Generic;
using System.Linq;

namespace Fz.Core.Bll
{
    public class SyTeacherBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_teacher> GetList()
        {
            List<sy_teacher> list = Common.Caches.GetCache("sy_teacher") as List<sy_teacher>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_teacher.ToList();
                }
                Common.Caches.SetCache("sy_teacher", list);
            }
            return list;
        }

        /// <summary>
        /// 根据用户主键获取数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static sy_teacher GetModelByUserId(string userId)
        {
            return GetList().Where(w => w.UserId == userId).FirstOrDefault();
        }

        /// <summary>
        /// 获取科组
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int? GetSubject(string userId)
        {
            sy_teacher m = GetModelByUserId(userId);
            return m == null ? null : m.Subject;
        }

        /// <summary>
        /// 根据教师Id获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int? id)
        {
            sy_teacher m = GetList().Where(w => w.Id == id).FirstOrDefault();
            return m == null ? "" : m.Name;
        }

        /// <summary>
        /// 根据学科获取教师列表
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDict(int subjectId)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_teacher.Where(w => w.Subject == subjectId && w.UserId != null && w.sy_user.IsEnabled == true).ToDictionary(k => k.Id, v => v.Name);
            }
        }
        /// <summary>
        /// 判断用户名和姓名是否存在
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public static bool IsExist(string Account, string Name)
        {
            using (var db = new fz_basicEntities())
            {
                sy_user user = new sy_user();
                if (Name == null)
                {
                    user = db.sy_user.Where(w => w.Account == Account).FirstOrDefault();
                }
                if(Account == null)
                {
                    user = db.sy_user.Where(w => w.Name == Name).FirstOrDefault();
                }
                if(user != null)
                {
                    return true;
                }              
                 return false;                              
            }
        }
    }
}
