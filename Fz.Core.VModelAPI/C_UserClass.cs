using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
   public class C_UserClass
    {
        /// <summary>
        /// 年级Id
        /// </summary>
        public int GradeId { get; set; }

        /// <summary>
        /// 年级名称
        /// </summary>
        public string GradeName { get; set; }

        /// <summary>
        /// 班级Id
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
