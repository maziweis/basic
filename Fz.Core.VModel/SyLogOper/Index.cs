using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyLogOper
{
    public class Index
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public Fz.Common.Model.PList<Grid> Grid { get; set; }
    }
}
