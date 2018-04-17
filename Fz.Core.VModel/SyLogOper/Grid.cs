using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyLogOper
{
    public class Grid
    {
        /// <summary>
        /// 请求方式
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Action用途
        /// </summary>
        public string ActionPurpose { get; set; }

        /// <summary>
        /// 访问IP
        /// </summary>
        public string CreateIp { get; set; }

        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 访问人账号
        /// </summary>
        public string CreateAccount { get; set; }
    }
}
