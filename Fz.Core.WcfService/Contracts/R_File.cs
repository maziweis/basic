using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fz.Core.WcfService.Contracts
{
    /// <summary>
    /// R_File
    /// </summary>
     [DataContract]
    public class R_File
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        [DataMember]
        public string FileName { get; set; }
        /// <summary>
        /// 文件描述
        /// </summary>
        [DataMember]
        public string FileDescription { get; set; }
        /// <summary>
        /// 文件扩展
        /// </summary>
        [DataMember]
        public string FileExtension { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [DataMember]
        public int FileSize { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        [DataMember]
        public string FilePath { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [DataMember]
        public int FileType { get; set; }
        /// <summary>
        /// 宽
        /// </summary>
        [DataMember]
        public int Width { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        [DataMember]
        public int Height { get; set; }
    }
}