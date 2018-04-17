using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.DictSubject
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
        [Required(ErrorMessage = "名称不能为空")]
        [MaxLength(20, ErrorMessage = "请输入不超过20个字符的内容")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [RegularExpression(@"^([1-9]\d{0,4}|100000)$", ErrorMessage = "请输入1-100000的正整数")]
        [Display(Name = "排序值")]
        public int? Sort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public bool IsEnabled { get; set; }
    }
}
