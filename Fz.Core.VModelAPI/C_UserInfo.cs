using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
  public class C_UserInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 帐号类型：1-教职工，2-学生，3-家长，4-方直管理账号
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 主学科
        /// </summary>
        public int? Subject { get; set; }

        /// <summary>
        /// 用户所属年级班级列表
        /// </summary>
        public C_UserClass[] userClass { get; set; }
    }
}
