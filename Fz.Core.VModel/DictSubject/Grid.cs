using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.DictSubject
{
    public class Grid
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 是否是系统数据
        /// </summary>
        public bool IsSystem { get; set; }
    }
}
