using System.Runtime.Serialization;
using System.ServiceModel;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [DataContract]
    public class C_UserInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 帐号类型：1-教职工，2-学生，3-家长，4-方直管理账号
        /// </summary>
        [DataMember]
        public int Type { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [DataMember]
        public string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 主学科
        /// </summary>
        [DataMember]
        public int? Subject { get; set; }

        /// <summary>
        /// 用户所属年级班级列表
        /// </summary>
        [DataMember]
        public C_UserClass[] userClass { get; set; }
    }
}