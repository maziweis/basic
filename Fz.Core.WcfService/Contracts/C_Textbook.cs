using System.Runtime.Serialization;
using System.ServiceModel;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// 教材信息
    /// </summary>
    [DataContract]
    public class C_Textbook
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 学段
        /// </summary>
        [DataMember]
        public int Stage { get; set; }

        /// <summary>
        /// 学科
        /// </summary>
        [DataMember]
        public int Subject { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        [DataMember]
        public int Grade { get; set; }

        /// <summary>
        /// 册别
        /// </summary>
        [DataMember]
        public int Booklet { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [DataMember]
        public int Edition { get; set; }

        /// <summary>
        /// 教材名称
        /// </summary>
        [DataMember]
        public string BookName { get; set; }

        /// <summary>
        /// 教材配置文件
        /// </summary>
        [DataMember]
        public string BookConfig { get; set; }

        /// <summary>
        /// 教材封面
        /// </summary>
        [DataMember]
        public string BookCover { get; set; }
    }
}