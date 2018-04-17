using FzDatabase.Basic;
using System.Collections.Generic;
using System.Linq;

namespace Fz.Core.Bll
{
    public class SyStudentBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_student> GetList()
        {
            List<sy_student> list = Common.Caches.GetCache("sy_student") as List<sy_student>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_student.ToList();
                }
                Common.Caches.SetCache("sy_student", list);
            }
            return list;
        }

        /// <summary>
        /// 根据用户主键获取数据
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static sy_student GetModelByUserId(string userId)
        {
            return GetList().Where(w => w.UserId == userId).FirstOrDefault();
        }

        /// <summary>
        /// 获取性别
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetSex(string userId)
        {
            return GetModelByUserId(userId).Sex;
        }

        /// <summary>
        /// 获取年级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int? GetGrade(string userId)
        {
            return GetModelByUserId(userId).Grade;
        }

        /// <summary>
        /// 获取班级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int? GetClass(string userId)
        {
            return GetModelByUserId(userId).Class;
        }
    }
}
