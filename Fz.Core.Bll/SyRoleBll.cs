using FzDatabase.Basic;
using System.Collections.Generic;
using System.Linq;

namespace Fz.Core.Bll
{
    public class SyRoleBll
    {
        /// <summary>
        /// 获取全部并缓存
        /// </summary>
        /// <returns></returns>
        public static List<sy_role> GetList()
        {
            List<sy_role> list = Common.Caches.GetCache("sy_role") as List<sy_role>;
            if (list == null)
            {
                using (var db = new fz_basicEntities())
                {
                    list = db.sy_role.Include("sy_user_and_role").ToList();
                }
                Common.Caches.SetCache("sy_role", list);
            }
            return list;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<VModel.SyRole.Grid> GetGrid(VModel.SyRole.Index m)
        {
            using (var db = new fz_basicEntities())
            {
                IQueryable<sy_role> query = db.sy_role.Where(w => w.Id != 1);
                if (m.Type != null)
                {
                    query = query.Where(w => w.Type == m.Type);
                }
                if (!string.IsNullOrWhiteSpace(m.Name))
                {
                    query = query.Where(w => w.Name.Contains(m.Name));
                }

                return query.Select(s => new VModel.SyRole.Grid
                {
                  
                    Id = s.Id,
                    Name = s.Name,
                    Type = s.Type,
                    UserNumber = db.sy_user_and_role.Where(w=>w.sy_user.Id == w.UserId && w.sy_role.Id == s.Id && w.sy_user.IsEnabled).Count(),
                    APNumber = s.sy_nav.Count,
                    IsSystem = s.IsSystem,
                    IsEnabled = s.IsEnabled,
                    Remark = s.Remark
                }).ToList();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public static int Add(VModel.SyRole.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Name = m.Name.Trim();
                sy_role role = db.sy_role.Where(w => w.Name == m.Name).FirstOrDefault();
                if (role == null)
                {
                    sy_role dbm = new sy_role
                    {
                        Name = m.Name,
                        Type = (int)m.Type,
                        IsSystem = false,
                        IsEnabled = m.IsEnabled,
                        Remark = m.Remark
                    };

                    if (!string.IsNullOrWhiteSpace(m.navs))
                    {
                        string[] ns = m.navs.Split(',');
                        foreach (var item in ns)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                dbm.sy_nav.Add(db.sy_nav.Find(int.Parse(item)));
                            }
                        }
                    }

                    db.sy_role.Add(dbm);
                    db.SaveChanges();
                    Common.Caches.RemoveCache("sy_role");
                    return 200;
                }
                else
                {
                    return 100;
                }
            }
              
        }

        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SyRole.Form GetEdit(int id)
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_role.Where(w => w.Id == id).Select(s => new VModel.SyRole.Form
                {
                    Id = s.Id,
                    Name = s.Name,
                    Type = s.Type,
                    IsEnabled = s.IsEnabled,
                    Remark = s.Remark,
                    navlist = s.sy_nav.Select(s1 => s1.Id).ToList()
                }).FirstOrDefault();
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SyRole.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                m.Name = m.Name.Trim();
                sy_role role = db.sy_role.Where(w => w.Name == m.Name).FirstOrDefault();
                if (role == null || (role != null && m.Id == role.Id))
                {
                    sy_role dbm = db.sy_role.Find(m.Id);
                    dbm.Name = m.Name;
                    dbm.Type = (int)m.Type;
                    dbm.IsEnabled = m.IsEnabled;
                    dbm.Remark = m.Remark;
                    dbm.sy_nav.Clear();

                    if (!string.IsNullOrWhiteSpace(m.navs))
                    {
                        string[] ns = m.navs.Split(',');
                        foreach (var item in ns)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                dbm.sy_nav.Add(db.sy_nav.Find(int.Parse(item)));
                            }
                        }
                    }
                db.SaveChanges();
                Common.Caches.RemoveCache("sy_role");
                 return 200;
                }
                else
                {
                    return 100;
                }
        }
               
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
                sy_role m = db.sy_role.Find(id);

                if (m.sy_user_and_role.Count() > 0)
                {
                    return -1;//删除失败，该角色下拥有活跃的老师
                }

                m.sy_nav.Clear();
                m.sy_user_and_role.Clear();
                db.sy_role.Remove(m);
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_role");
            Common.Caches.RemoveCache("sy_user");

            return 200;
        }

        /// <summary>
        /// 启用或禁用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="enable"></param>
        public static void Enable(int id, bool enable)
        {
            using (var db = new fz_basicEntities())
            {
                sy_role dbm = db.sy_role.Find(id);
                dbm.IsEnabled = enable;
                db.SaveChanges();
            }

            Common.Caches.RemoveCache("sy_role");
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetName(int id)
        {
            return GetList().Where(w => w.Id == id).Select(s => s.Name).FirstOrDefault();
        }

        /// <summary>
        /// 获取管理员角色
        /// </summary>
        public static Dictionary<int, string> GetDictManager()
        {
            return GetList().Where(w => w.Type == 4 && w.IsEnabled == true && w.Id != 1).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 获取教师角色
        /// </summary>
        public static Dictionary<int, string> GetDictTeacher()
        {
            return GetList().Where(w => w.Type == 12 && w.IsEnabled == true).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 获取学生角色
        /// </summary>
        public static Dictionary<int, string> GetDictStudent()
        {
            return GetList().Where(w => w.Type == 26 && w.IsEnabled == true).ToDictionary(k => k.Id, v => v.Name);
        }

        /// <summary>
        /// 根据角色ID获取用户
        /// </summary>
        /// <returns></returns>
        public static Common.Model.PList<VModel.SyRole.UserGrid> GetUsers(VModel.SyRole.RUser m)
        {
            Common.Model.PList<VModel.SyRole.UserGrid> pl = new Common.Model.PList<VModel.SyRole.UserGrid>();
            pl.Data = new List<VModel.SyRole.UserGrid>();

            using (var db = new fz_basicEntities())
            {
                var query = db.sy_user.OrderBy(o => o.Account).Where(w => w.sy_user_and_role.Where(w1 => w1.RoleId == m.id).Select(s2 => s2.UserId).Contains(w.Id) && w.IsEnabled).AsQueryable();
                pl.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, query.Count());
                pl.Data = query.Skip((m.Grid.Pager.PageIndex - 1) * m.Grid.Pager.PageSize).Take(m.Grid.Pager.PageSize).Select(s => new VModel.SyRole.UserGrid
                {
                    Account = s.Account,
                    Name = s.Name,
                    RoleNames = s.sy_user_and_role.Select(s1 => s1.sy_role.Name).ToList(),
                    Time = s.sy_user_and_role.Select(s1 => s1.Time).FirstOrDefault()
                }).ToList();
            }

            return pl;
        }

        /// <summary>
        /// 根据用户id获取角色名称列表
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static List<string> GetRoleNamesByUserId(string uid)
        {
            return GetList().Where(w => w.sy_user_and_role.Any(a => a.UserId == uid)).Select(s => s.Name).ToList();
        }
    }
}
