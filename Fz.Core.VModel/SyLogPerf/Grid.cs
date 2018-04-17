using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fz.Core.VModel.SyLogPerf
{
    public class Grid
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Action类型
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// ControllerName
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// ActionName
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Action用途
        /// </summary>
        public string ActionPurpose { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 相应时间
        /// </summary>
        public decimal? ResponseTime { get; set; }

        /// <summary>
        /// 渲染时间
        /// </summary>
        public decimal? RenderTime { get; set; }

        /// <summary>
        /// 总用时
        /// </summary>
        public decimal? TotalTime { get; set; }

        /// <summary>
        /// 访问IP
        /// </summary>
        public string CreateIp { get; set; }

        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 访问人
        /// </summary>
        public string CreateUserName { get; set; }
    }
}
