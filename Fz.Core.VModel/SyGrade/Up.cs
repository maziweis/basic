using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyGrade
{
    public class Up
    {
        public int GradeCount { get; set; }

        public int ClassCount { get; set; }

        public int StudentCount { get; set; }

        public List<UpGrid> UpGrids { get; set; }
    }

    public class UpGrid
    {
        public string GradeName { get; set; }

        public List<string> ClassName { get; set; }

        public int StudentCount { get; set; }
    }
}
