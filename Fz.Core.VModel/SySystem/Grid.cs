using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SySystem
{
    public class Grid
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 类型：1-栏目，2-导航
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 导航名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 页面打开方式:1-跳转，2-新窗口
        /// </summary>
        public int PageOpen { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 包含菜单
        /// </summary>
        public bool IsNav { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}