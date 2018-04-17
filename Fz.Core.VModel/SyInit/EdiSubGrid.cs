using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyInit
{
   public class EdiSubGrid
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public List<Edition> EdiList { get; set; }      
    }
}
