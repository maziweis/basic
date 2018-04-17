using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SySystem
{
    public class Form
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 所属平台
        /// </summary>
        [Required(ErrorMessage = "所属平台不能为空")]
        [Display(Name = "所属平台")]
        public int? PId { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        [Required(ErrorMessage = "系统名称不能为空")]
        [MaxLength(20, ErrorMessage = "请输入不超过20个字符的内容！")]
        [Display(Name = "系统名称")]
        public string Name { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [MaxLength(700, ErrorMessage = "请输入不超过700个字符的内容！")]
        [Display(Name = "链接地址")]
        public string Url { get; set; }

        /// <summary>
        /// 页面打开方式:1-跳转，2-新窗口
        /// </summary>
        [Display(Name = "打开方式")]
        public int PageOpen { get; set; }

        /// <summary>
        /// 是否包含左侧导航
        /// </summary>
        [Display(Name = "包含左侧")]
        public bool IsNav { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Required(ErrorMessage ="排序值不能为空")]
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