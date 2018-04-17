using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fz.Core.WcfService.Contracts
{
    /// <summary>
    /// 资源
    /// </summary>
    [DataContract]
    public class R_ResourceExport_Resource
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 学段
        /// </summary>
        [DataMember]
        public int? SchoolStage { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        [DataMember]
        public int? Grade { get; set; }

        /// <summary>
        /// 学科
        /// </summary>
        [DataMember]
        public int? Subject { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [DataMember]
        public int? Edition { get; set; }

        /// <summary>
        /// 册别
        /// </summary>
        [DataMember]
        public int? BookReel { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        [DataMember]
        public int? Catalog { get; set; }

        /// <summary>
        /// 资源类型 
        /// </summary>
        [DataMember]
        public int? ResourceType { get; set; }

        /// <summary>
        /// 资源级别
        /// </summary>
        [DataMember]
        public int? ResourceLevel { get; set; }

        /// <summary>
        /// 教学步骤
        /// </summary>
        [DataMember]
        public int? TeachingStep { get; set; }

        /// <summary>
        /// 教学模块
        /// </summary>
        [DataMember]
        public string TeachingModules { get; set; }

        /// <summary>
        /// 教学形式
        /// </summary>
        [DataMember]
        public int? TeachingStyle { get; set; }

        /// <summary>
        /// 适用对象
        /// </summary>
        [DataMember]
        public string Applicable { get; set; }

        /// <summary>
        /// 是否被审核过。0为否，1为是
        /// </summary>
        [DataMember]
        public int? IsVerify { get; set; }

        /// <summary>
        /// 是否删除了默认为0,1代表已经删除
        /// </summary>
        [DataMember]
        public int? IsDelete { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        [DataMember]
        public int? DownCounts { get; set; }

        /// <summary>
        /// 浏览数
        /// </summary>
        [DataMember]
        public int? ScanCounts { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [DataMember]
        public decimal ResourceSize { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        [DataMember]
        public int? IsRecommend { get; set; }

        /// <summary>
        /// 访问权限
        /// </summary>
        [DataMember]
        public int? Purview { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        [DataMember]
        public DateTime? UploadDate { get; set; }

        /// <summary>
        /// 上传用户
        /// </summary>
        [DataMember]
        public string UploadUser { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [DataMember]
        public string FileType { get; set; }

        /// <summary>
        /// 缩略图路径---URL地址
        /// </summary>
        [DataMember]
        public string BreviaryImgUrl { get; set; }

        /// <summary>
        /// 素材ID
        /// </summary>
        [DataMember]
        public string MaterialID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public double? Number { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 资源类型—2级
        /// </summary>
        [DataMember]
        public int? ResourceStyle { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KeyWords { get; set; }

        /// <summary>
        /// 文件ID外键
        /// </summary>
        [DataMember]

        public string FileID { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]

        public string Description { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [DataMember]

        public string ComeFrom { get; set; }

        /// <summary>
        /// 评价量
        /// </summary>
        [DataMember]
        public int? AppraisedCounts { get; set; }

        /// <summary>
        /// 收藏量
        /// </summary>
        [DataMember]
        public int? CollectCounts { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        public DateTime? ModifyDate { get; set; }
        //
        /// <summary>
        /// </summary>
        [DataMember]
        public int? Copyrigh { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [DataMember]
        public string CopyrighName { get; set; }
        /// <summary>
        /// 排序字段-2016-08-25添加
        /// </summary>
        [DataMember]
        public Int64 Sort { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        [DataMember]
        public int? TimeSpan { get; set; }

        /// <summary>
        /// 资源大类
        /// </summary>
        [DataMember]
        public int? ResourceClass { get; set; }
    }
}