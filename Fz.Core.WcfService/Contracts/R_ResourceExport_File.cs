using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fz.Core.WcfService.Contracts
{
    /// <summary>
    /// 文件
    /// </summary>
    [DataContract]
    public class R_ResourceExport_File
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FileDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FileExtension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? FileSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FilePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? FileType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool? FinishStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? EncryptStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? ConvertStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? UploadTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? Height { get; set; }
    }
}