using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class SySchoolBll
    {
        /// <summary>
        /// 获取编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static VModel.SySchool.Form GetEdit()
        {
            using (var db = new fz_basicEntities())
            {
                return db.sy_school.Select(s => new VModel.SySchool.Form
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Code,
                    Email = s.Email,
                    Address = s.Address,
                    Overview = s.Overview,
                    Principal = s.Principal,
                    Tel = s.Tel,
                    Webhome = s.Webhome
                }).FirstOrDefault();
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public static int Edit(VModel.SySchool.Form m)
        {
            using (var db = new fz_basicEntities())
            {
                sy_school dbm = db.sy_school.Find(m.Id);

                dbm.Name = m.Name;
                dbm.Code = m.Code;
                dbm.Email = m.Email;
                dbm.Address = m.Address;
                dbm.Overview = m.Overview;
                dbm.Principal = m.Principal;
                dbm.Tel = m.Tel;
                dbm.Webhome = m.Webhome;

                db.SaveChanges();
            }

            return 200;
        }
    }
}
