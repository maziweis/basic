using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
    public class TextbookCatalog
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 父节点Id
        /// </summary>
        public int? PId { get; set; }

        /// <summary>
        /// 目录名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 起始页码
        /// </summary>
        public int? PageStart { get; set; }

        /// <summary>
        /// 结束页码
        /// </summary>
        public int? PageEnd { get; set; }
    }
}
