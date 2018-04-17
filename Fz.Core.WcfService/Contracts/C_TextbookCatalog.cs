using System.Runtime.Serialization;
using System.ServiceModel;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// 教材目录信息
    /// </summary>
    [DataContract]
    public class C_TextbookCatalog
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 父节点Id
        /// </summary>
        [DataMember]
        public int? PId { get; set; }

        /// <summary>
        /// 目录名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 起始页码
        /// </summary>
        [DataMember]
        public int? PageStart { get; set; }

        /// <summary>
        /// 结束页码
        /// </summary>
        [DataMember]
        public int? PageEnd { get; set; }
    }
}