using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fz.Core.VModel.SyLogPerf
{
    public class Index
    {
        public string ControllerName { get; set; }
        public double? TotalTime { get; set; }
        public Dictionary<double, string> TotalTimes { get; set; }
        public Fz.Common.Model.PList<Grid> Grid { get; set; }
    }
}
