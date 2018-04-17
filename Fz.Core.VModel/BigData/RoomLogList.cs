using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.BigData
{
    public class RoomLogList
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>
        public string CreateUserId { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int CreateUserType { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public int OperId { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string OperContent { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
