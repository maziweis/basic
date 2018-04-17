using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyUserTeacher
{
    public class Form
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [Required(ErrorMessage = "帐号不能为空")]
        //[RegularExpression("^[a-zA-Z][a-zA-Z0-9_]{0,15}$",ErrorMessage ="账号只能由字母、数字和下划线组成,并且第一个字符必须是字母")]
        [MaxLength(20, ErrorMessage = "请输入不超过20个字符的内容！")]
        [Display(Name = "帐号")]
        public string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "姓名不能为空")]
        [MaxLength(20, ErrorMessage = "请输入不超过20个字符的内容！")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 所属科组
        /// </summary>
        [Required(ErrorMessage = "主学科不能为空")]
        [Display(Name = "主学科")]
        public int? Subject { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [Display(Name = "过期时间")]
        public DateTime? ExpiresTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 拥有角色
        /// </summary>
        [Display(Name = "拥有角色")]
        public List<int> RoleIds { get; set; }
    }
}