using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyGrade
{
    public class Graduate
    {
        public string GradeName { get; set; }

        public int ClassCount { get; set; }

        public int StudentCount { get; set; }

        public List<GraduateGrid> GraduateGrids { get; set; }
    }

    public class GraduateGrid
    {
        public string GradeName { get; set; }

        public string ClassName { get; set; }

        public int StudentCount { get; set; }
    }
}
