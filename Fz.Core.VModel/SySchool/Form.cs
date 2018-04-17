using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SySchool
{
    public class Form
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        [Required(ErrorMessage = "学校名称不能为空")]
        [MaxLength(50, ErrorMessage = "请输入不超过50个字符的内容！")]
        [Display(Name = "学校名称")]
        public string Name { get; set; }

        /// <summary>
        /// 机构代码
        /// </summary>
        [Display(Name = "机构代码")]
        [MaxLength(10, ErrorMessage = "请输入不超过10个字符的内容！")]
        public string Code { get; set; }

        /// <summary>
        /// 校长
        /// </summary>
        [Display(Name = "校长")]
        [MaxLength(15, ErrorMessage = "请输入不超过15个字符的内容！")]
        public string Principal { get; set; }

        /// <summary>
        /// 校园主页
        /// </summary>
        [Display(Name = "校园主页")]
        [MaxLength(200, ErrorMessage = "请输入不超过200个字符的内容！")]
        public string Webhome { get; set; }

        /// <summary>
        /// 学校概况
        /// </summary>
        [Display(Name = "学校概况")]
        [MaxLength(2000, ErrorMessage = "请输入不超过2000个字符的内容！")]
        public string Overview { get; set; }

        /// <summary>
        /// 校园地址
        /// </summary>
        [Display(Name = "校园地址")]
        [MaxLength(200, ErrorMessage = "请输入不超过200个字符的内容！")]
        public string Address { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "E-mail")]
        [MaxLength(50, ErrorMessage = "请输入不超过50个字符的内容！")]
        public string Email { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        [MaxLength(13, ErrorMessage = "请输入不超过13个字符的内容！")]
        public string Tel { get; set; }
    }
}