using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyRole
{
    public class Grid
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 用户数量
        /// </summary>
        public int UserNumber { get; set; }

        /// <summary>
        /// 权限点数量
        /// </summary>
        public int APNumber { get; set; }

        /// <summary>
        /// 是否系统角色
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}