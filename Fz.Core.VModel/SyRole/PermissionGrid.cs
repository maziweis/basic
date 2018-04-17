using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyRole
{
    public class PermissionGrid
    {
        public string CatalogName { get; set; }

        public List<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
