using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyClass
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
        /// 名称
        /// </summary>
        public string GradeName { get; set; }

        /// <summary>
        /// 入学年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 学生数量
        /// </summary>
        public int StudentCount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<GridTCS> _GridTCS { get; set; }
    }

    public class GridTCS
    {
        public int TeacherId { get; set; }
        public int Subject { get; set; }
    }
}
