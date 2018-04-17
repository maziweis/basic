using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyRole
{
    public class RUser
    {
        public int id { get; set; }
        public Fz.Common.Model.PList<UserGrid> Grid { get; set; }
    }
    public class UserGrid
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public List<string> RoleNames { get; set; }

        public DateTime Time { get; set; }
    }
}
