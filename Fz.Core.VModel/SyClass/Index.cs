using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fz.Core.VModel.SyClass
{
    public class Index
    {
        public string Key { get; set; }
        public int? GradeId { get; set; }
        public Dictionary<int, string> Grades { get; set; }
        public List<Grid> Grid { get; set; }
    }
}
