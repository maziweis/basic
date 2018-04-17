using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fz.Core.VModel.SyLogBug
{
    public class Grid
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 数据类型:1-Web应用，2-WebApi，3-WebServices，4-WCF
        /// </summary>
        public string DType { get; set; }

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
        /// 异常内容
        /// </summary>
        public string Message { get; set; }

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
