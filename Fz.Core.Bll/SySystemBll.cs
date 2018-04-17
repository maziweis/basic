using FzDatabase.Basic;
using System.Collections.Generic;
using System.Linq;

namespace Fz.Core.Bll
{
    public class SySystemBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_system> GetList()
        {
            List<sy_system> list = Common.Caches.GetCache("sy_system") as List<sy_system>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_system.OrderBy(o => o.Sort).ToList();
                }
                Common.Caches.SetCache("sy_system", list);
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<VModel.SySystem.Grid> GetGrid(VModel.SySystem.Index m)
        {
            List<VModel.SySystem.Grid> list = new List<VModel.SySystem.Grid>();

            using (var db = new fz_basicEntities())
            {
                var query = db.sy_system.Where(w => w.Type == 1).OrderBy(o => o.Sort);
                foreach (var f in query)
                {
                    list.Add(new VModel.SySystem.Grid
                    {
                        Id = f.Id,
                        Type = f.Type,
                        Name = f.Name,
                        Url = f.Url,
                        PageOpen = f.PageOpen,
                        Icon = f.Icon,
                        IsNav = f.IsNav,
                        Level = f.Level,
                        Sort = f.Sort,
                        IsEnabled = f.IsEnabled
                    });
                    var query2 = db.sy_system.Where(w => w.PId == f.Id).OrderBy(o => o.Sort);
                    foreach (var f2 in query2)
                    {
                        list.Add(new VModel.SySystem.Grid
                        {
                            Id = f2.Id,
                            Type = f2.Type,
                            Name = f2.Name,
                            Url = f2.Url,
                            PageOpen = f2.PageOpen,
                            Icon = f2.Icon,
                            IsNav = f2.IsNav,
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
        public static int Add(VModel.SySystem.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_system dbm = new sy_system
                {
                    PId = m.PId,
                    Type = 2,
                    Name = m.Name,
                    IsNav = m.IsNav,
                    Url = m.Url,
                    PageOpen = m.PageOpen,
                    Level = 2,
                    Sort = m.Sort,
                    IsEnabled = m.IsEnabled,
                    IsSystem = true
                };
                sy_nav dbnav = new sy_nav
                {
                    SId = dbm.Id,
                     Type = 3,
                     Name = dbm.Name,
                     PageOpen = dbm.PageOpen,
                     Level = 1,
                     Sort = dbm.Sort,
                     IsEnabled = dbm.IsEnabled,
                     IsSystem = dbm.IsSystem
                };
                db.sy_system.Add(dbm);
                db.sy_nav.Add(dbnav);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_system");

            return 200;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Add(VModel.SySystem.FormCatalog m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_system dbm = new sy_system
                {
                    Type = 1,
                    Name = m.Name,
                    IsNav = false,
                    PageOpen = 1,
                    Level = 1,
                    Sort = m.Sort,
                    IsEnabled = m.IsEnabled,
                    IsSystem = true
                };

                db.sy_system.Add(dbm);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_system");

            return 200;
        }


        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SySystem.Form GetEdit(int id)
        {
            return GetList().Where(w => w.Id == id).Select(s => new VModel.SySystem.Form
            {
                Id = s.Id,
                PId = s.PId,
                Name = s.Name,
                Url = s.Url,
                PageOpen = s.PageOpen,
                IsNav = s.IsNav,
                Sort = s.Sort,
                IsEnabled = s.IsEnabled
            }).FirstOrDefault();
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SySystem.FormCatalog GetEditCatalog(int id)
        {
            return GetList().Where(w => w.Id == id).Select(s => new VModel.SySystem.FormCatalog
            {
                Id = s.Id,
                Name = s.Name,
                Sort = s.Sort,
                IsEnabled = s.IsEnabled
            }).FirstOrDefault();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SySystem.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_system dbm = db.sy_system.Find(m.Id);

                dbm.PId = m.PId;
                dbm.Name = m.Name;
                dbm.Url = m.Url;
                dbm.PageOpen = m.PageOpen;
                dbm.IsNav = m.IsNav;
                dbm.Sort = m.Sort;
                dbm.IsEnabled = m.IsEnabled;

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_system");

            return 200;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SySystem.FormCatalog m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_system dbm = db.sy_system.Find(m.Id);

                dbm.Name = m.Name;
                dbm.Sort = m.Sort;
                dbm.IsEnabled = m.IsEnabled;

                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_system");

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
                if (db.sy_system.Where(w => w.PId == id).Count() > 0)
                {
                    return -1;//存在子节点不能删除
                }
                else if (db.sy_system.Where(w => w.sy_nav.Any(nav => nav.SId == id)).Count() > 0)
                {
                    return -2;//该系统还拥有左侧导航不能删除
                }

                db.sy_system.Remove(db.sy_system.Find(id));
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_system");

            return 200;
        }

        /// <summary>
        /// 根据用系统获取上级导航
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetParentNavs()
        {
            return GetList().Where(w => w.IsEnabled == true && w.Type == 1).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> GetDictByIsNavs()
        {
            return GetList().Where(w => w.IsEnabled == true && w.IsNav == true && w.Type == 2).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 根据用途获取导航
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<VModel.Common.Nav> GetNavs(int[] ids)
        {
            return GetList().Where(w => w.IsEnabled == true && ids.Contains(w.Id)).Select(s => new VModel.Common.Nav
            {
                Id = s.Id,
                PId = s.PId,
                Type = s.Type,
                Name = s.Name,
                Url = s.Url,
                Icon = s.Icon,
                PageOpen = s.PageOpen
            }).ToList();
        }
    }
}
