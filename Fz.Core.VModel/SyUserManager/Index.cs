using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fz.Core.VModel.SyUserManager
{
    public class Index
    {
        public int Type { get; set; }
        public string Key { get; set; }
        public Fz.Common.Model.PList<Grid> Grid { get; set; }
    }
}
