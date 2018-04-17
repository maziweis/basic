using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyRole
{
    public class Form
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [MaxLength(25, ErrorMessage = "请输入不超过25个字符的内容！")]
        [Display(Name = "角色名称")]
        public string Name { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        [Required(ErrorMessage = "角色类型不能为空")]
        [Display(Name = "角色类型")]
        public int? Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(150, ErrorMessage = "请输入不超过150个字符的内容！")]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 选中权限
        /// </summary>
        public string navs { get; set; }


        public List<int> navlist { get; set; }
    }
}