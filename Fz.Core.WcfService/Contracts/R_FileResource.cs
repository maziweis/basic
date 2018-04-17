using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fz.Core.WcfService.Contracts
{
    /// <summary>
    /// R_FileResource
    /// </summary>
    [DataContract]
    public class R_FileResource
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        [DataMember]
        public string FileID { get; set; }
        /// <summary>
        /// 文件ID
        /// </summary>
        [DataMember]
        public string UserID { get; set; }
        /// <summary>
        /// 文件ID
        /// </summary>
        [DataMember]
        public string UserName { get; set; }        
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
        ///x 文件路径
        /// </summary>
        [DataMember]
        public string FilePath { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [DataMember]
        public int FileType { get; set; }
        /// <summary>
        /// 学科ID
        /// </summary>
        [DataMember]
        public int? SubjectID { get; set; }
        /// <summary>
        /// 版本ID
        /// </summary>
        [DataMember]
        public int? EditionID { get; set; }
        /// <summary>
        /// 年级ID
        /// </summary>
        [DataMember]
        public int? GradeID { get; set; }
        /// <summary>
        /// 目录ID
        /// </summary>
        [DataMember]
        public int? Catalog { get; set; }
        /// <summary>
        /// 册别ID
        /// </summary>
        [DataMember]
        public int? BookReelID { get; set; }
        /// <summary>
        /// 资源子类
        /// </summary>
        [DataMember]
        public int? ResourceStyle { get; set; }
    }
}