using System;
using System.Collections.Generic;

namespace Fz.Core.VModel.SyPassport
{
    public class UserInfo
    {
        /// <summary>
        /// Id
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
        /// 用户类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 系统导航
        /// </summary>
        public int[] SysNavs { get; set; }

        /// <summary>
        /// 左侧导航
        /// </summary>
        public int[] Navs { get; set; }

        /// <summary>
        /// 凭证
        /// </summary>
        public string ticket { get; set; }
    }
}
