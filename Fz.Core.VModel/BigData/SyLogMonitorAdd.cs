using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.BigData
{
    public class SyLogMonitorAdd
    {
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

        /// <summary>
        /// 访问人Id
        /// </summary>
        public string CreateUserId { get; set; }

        /// <summary>
        /// 访问人账号
        /// </summary>
        public string CreateAccount { get; set; }
    }
}
