using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fz.Core.WcfService.Contracts
{
    /// <summary>
    /// 资源列表
    /// </summary>
    [DataContract]
    public class R_Resource
    {
        /// <summary>
        /// 资源ID
        /// </summary>
        [DataMember]
        public string ResourceID { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        [DataMember]
        public string ResourceName { get; set; }
        /// <summary>
        /// 文件ID
        /// </summary>
        [DataMember]
        public string FileID { get; set; }
        /// <summary>
        /// 资源描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }
        /// <summary>
        /// 资源资源细分
        /// </summary>
        [DataMember]
        public int? ResourceStyle { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        [DataMember]
        public int? ResourceType { get; set; }
        /// <summary>
        /// 资源大小
        /// </summary>
        [DataMember]
        public decimal? ResourceSize { get; set; }
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
        /// 学段
        /// </summary>
        [DataMember]
        public int? SchoolStage { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KeyWords { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [DataMember]
        public string FileType { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        [DataMember]
        public string BreviaryImgUrl { get; set; }
        /// <summary>
        /// 资源添加人ID
        /// </summary>
        [DataMember]
        public string ResourceCreaterID { get; set; }
        /// <summary>
        /// 资源添加人姓名
        /// </summary>
        [DataMember]
        public string ResourceCreaterName { get; set; }
        /// <summary>
        /// 资源上传时间
        /// </summary>
        [DataMember]
        public DateTime? ResourceCreaterDate { get; set; }

    }
}