using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Fz.Core.VModel.SyUserManager
{
    public class Grid
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否系统角色
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? ExpiresTime { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        public bool IsExpires { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 角色名称列表
        /// </summary>
        public List<string> RoleNames { get; set; }
    }
}
