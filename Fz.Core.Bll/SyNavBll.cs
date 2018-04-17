using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class SyNavBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_nav> GetList()
        {
            List<sy_nav> list = Common.Caches.GetCache("sy_nav") as List<sy_nav>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_nav.OrderBy(o => o.Sort).ToList();
                }
                Common.Caches.SetCache("sy_nav", list);
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<VModel.SyNav.Grid> GetGrid(VModel.SyNav.Index m)
        {
            List<VModel.SyNav.Grid> list = new List<VModel.SyNav.Grid>();

            using (var db = new fz_basicEntities())
            {
                var query = db.sy_nav.Where(w => w.SId == m.SId && w.Level == 1 && w.Type != 3).OrderBy(o => o.Sort);
                foreach (var f in query)
                {
                    list.Add(new VModel.SyNav.Grid
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Url = f.Url,
                        PageOpen = f.PageOpen,
                        Icon = f.Icon,
                        Level = f.Level,
                        Sort = f.Sort,
                        IsEnabled = f.IsEnabled
                    });
                    var query2 = db.sy_nav.Where(w => w.PId == f.Id).OrderBy(o => o.Sort);
                    foreach (var f2 in query2)
                    {
                        list.Add(new VModel.SyNav.Grid
                        {
                            Id = f2.Id,
                            Name = f2.Name,
                            Url = f2.Url,
                            PageOpen = f2.PageOpen,
                            Icon = f2.Icon,
                            Level = f2.Level,
                            Sort = f2.Sort,
                            IsEnabled = f2.IsEnabled
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Add(VModel.SyNav.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                if (db.sy_nav.Where(w => w.SId == m.SId && w.Name == m.Name.Trim()).Count() > 0)
                {
                    return -1;//导航已存在
                }

                sy_nav dbm = new sy_nav
                {
                    PId = m.PId == null ? db.sy_nav.Where(w => w.Type == 3 && w.SId == m.SId).Select(s => s.Id).FirstOrDefault() : m.PId,
                    Type = m.PId == null ? 1 : 2,
                    Name = m.Name,
                    SId = m.SId,
                    Url = m.Url,
                    PageOpen = m.PageOpen,
                    Icon = m.Icon,
                    Level = m.PId == null ? 1 : 2,
                    Sort = m.Sort,
                    IsEnabled = m.IsEnabled,
                    IsSystem = true
                };

                db.sy_nav.Add(dbm);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_nav");

            return 200;
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyNav.Form GetEdit(int id)
        {
            return GetList().Where(w => w.Id == id).Select(s => new VModel.SyNav.Form
            {
                Id = s.Id,
                Type = s.Type,
                PId = s.PId,
                SId = s.SId,
                Name = s.Name,
                Url = s.Url,
                PageOpen = s.PageOpen,
                Icon = s.Icon,
                Sort = s.Sort,
                IsEnabled = s.IsEnabled
            }).FirstOrDefault();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SyNav.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_nav dbm = db.sy_nav.Find(m.Id);
                if (dbm.Name.Trim() != m.Name.Trim() && db.sy_nav.Where(w => w.SId == m.SId && w.Name == m.Name.Trim()).Count() > 0)
                {
                    return -1;//导航已存在
                }

                dbm.PId = m.PId == null ? db.sy_nav.Where(w => w.Type == 3 && w.SId == m.SId).Select(s => s.Id).FirstOrDefault() : m.PId;
                dbm.Name = m.Name;
                //dbm.Type = m.PId == null ? 1 : 2;
                dbm.Url = m.Url;
                dbm.PageOpen = m.PageOpen;
                //dbm.Level = m.PId == null ? 1 : 2;
                dbm.Icon = m.Icon;
                dbm.Sort = m.Sort;
                dbm.IsEnabled = m.IsEnabled;

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_nav");

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
                if (db.sy_nav.Where(w => w.PId == id).Count() > 0)
                {
                    return -1;//存在子节点不能删除
                }
                else if (db.sy_role.Where(w => w.sy_nav.Any(nav => nav.Id == id)).Count() > 0)
                {
                    return -2;//该导航已被角色引用不能删除
                }

                db.sy_nav.Remove(db.sy_nav.Find(id));
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_nav");

            return 200;
        }

        /// <summary>
        /// 根据用系统获取上级导航
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetParentNavs(int sid)
        {
            return GetList().Where(w => w.IsEnabled == true && w.SId == sid && w.Type == 1).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 根据用系统导航取导航
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="ids">用户当前拥有菜单</param>
        /// <returns></returns>
        public static List<VModel.Common.Nav> GetNavs(int sid, int[] ids)
        {
            return GetList().Where(w => w.IsEnabled == true && w.SId == sid && w.Type != 3 && ids.Contains(w.Id)).Select(s => new VModel.Common.Nav
            {
                Id = s.Id,
                PId = s.PId,
                Type = s.Type,
                Name = s.Name,
                Url = s.Url,
                Icon = s.Icon,
                PageOpen = s.PageOpen,
                Level = s.Level
            }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Common.Model.ZTree> GetZTree()
        {
            List<Common.Model.ZTree> rlist = new List<Common.Model.ZTree>();
            List<sy_nav> list = GetList().Where(w => w.IsEnabled == true).ToList();
            List<sy_nav> list1 = list.Where(w => w.Type != 2).ToList();
            foreach (var m in list1)
            {
                rlist.Add(new Common.Model.ZTree
                {
                    id = m.Id,
                    pId = m.PId,
                    name = m.Name,
                    open = true,
                    @checked = false
                });
                if (m.Type != 3)
                {
                    List<sy_nav> list2 = list.Where(w => w.PId == m.Id).ToList();
                    if (list2 != null && list2.Count > 0)
                    {
                        foreach (var m2 in list2)
                        {
                            rlist.Add(new Common.Model.ZTree
                            {
                                id = m2.Id,
                                pId = m2.PId,
                                name = m2.Name,
                                open = true,
                                @checked = false
                            });
                        }
                    }
                }
            }
            return rlist;
        }
    }
}
