using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyGrade
{
    public class Form
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "年级名称不能为空")]
        [Display(Name = "年级名称")]
        public int? Name { get; set; }

        /// <summary>
        /// 入学年份
        /// </summary>
        [Required(ErrorMessage = "入学年份不能为空")]
        [Display(Name = "入学年份")]
        public int? Year { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [RegularExpression(@"^([1-9]\d{0,4}|100000)$", ErrorMessage = "请输入1-100000的正整数")]
        [Display(Name = "排序值")]
        public int? Sort { get; set; }
    }
}
