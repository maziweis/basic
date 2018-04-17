using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyLogRoomOper
{
    public class Index
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Fz.Common.Model.PList<Grid> Grid { get; set; }
    }
}
