using System;
using FzDatabase.Basic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class DictEditionBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<dict_edition> GetList()
        {
            List<dict_edition> list = Common.Caches.GetCache("dict_edition") as List<dict_edition>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.dict_edition.OrderBy(o => o.Sort).ToList();
                }
                Common.Caches.SetCache("dict_edition", list);
            }
            return list;
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetSelect()
        {
            return GetList().Where(w => w.IsEnabled == true).ToDictionary(k => k.Id, v => v.Name);
        }
    }
}
