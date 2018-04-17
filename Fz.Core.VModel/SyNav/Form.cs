using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyNav
{
    public class Form
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 系统Id
        /// </summary>
        public int SId { get; set; }

        /// <summary>
        /// 上级导航
        /// </summary>
        [Display(Name = "上级导航")]
        public int? PId { get; set; }

        /// <summary>
        /// 导航名称
        /// </summary>
        [Required(ErrorMessage = "导航名称不能为空")]
        [MaxLength(20, ErrorMessage = "请输入不超过20个字符的内容！")]
        [Display(Name = "导航名称")]
        public string Name { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [MaxLength(500, ErrorMessage = "请输入不超过500个字符的内容！")]
        [Display(Name = "链接地址")]
        public string Url { get; set; }

        /// <summary>
        /// 页面打开方式:1-跳转，2-新窗口
        /// </summary>
        [Display(Name = "打开方式")]
        public int PageOpen { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(50,ErrorMessage = "请输入不超过50个字符的内容！")]
        [Display(Name = "图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Required(ErrorMessage = "排序值不能为空")]
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