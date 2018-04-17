using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.Common
{
    public class Nav
    {
        public int Id { get; set; }

        public int? PId { get; set; }

        /// <summary>
        /// 1-栏目，2-导航
        /// </summary>
        public int Type { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        /// <summary>
        /// 1-跳转，2-新窗口
        /// </summary>
        public int PageOpen { get; set; }

        public int Level { get; set; }
    }
}
