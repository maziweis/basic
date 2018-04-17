using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
    public class R_ResourceExport_Resource
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 学段
        /// </summary>
        public int? SchoolStage { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public int? Grade { get; set; }

        /// <summary>
        /// 学科
        /// </summary>
        public int? Subject { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int? Edition { get; set; }

        /// <summary>
        /// 册别
        /// </summary>
        public int? BookReel { get; set; }

        /// <summary>
        /// 目录
        /// </summary>
        public int? Catalog { get; set; }

        /// <summary>
        /// 资源类型 
        /// </summary>
        public int? ResourceType { get; set; }

        /// <summary>
        /// 资源级别
        /// </summary>
        public int? ResourceLevel { get; set; }

        /// <summary>
        /// 教学步骤
        /// </summary>
        public int? TeachingStep { get; set; }

        /// <summary>
        /// 教学模块
        /// </summary>
        public string TeachingModules { get; set; }

        /// <summary>
        /// 教学形式
        /// </summary>
        public int? TeachingStyle { get; set; }

        /// <summary>
        /// 适用对象
        /// </summary>
        public string Applicable { get; set; }

        /// <summary>
        /// 是否被审核过。0为否，1为是
        /// </summary>
        public int? IsVerify { get; set; }

        /// <summary>
        /// 是否删除了默认为0,1代表已经删除
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        public int? DownCounts { get; set; }

        /// <summary>
        /// 浏览数
        /// </summary>
        public int? ScanCounts { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public decimal ResourceSize { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public int? IsRecommend { get; set; }

        /// <summary>
        /// 访问权限
        /// </summary>
        public int? Purview { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? UploadDate { get; set; }

        /// <summary>
        /// 上传用户
        /// </summary>
        public string UploadUser { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 缩略图路径---URL地址
        /// </summary>
        public string BreviaryImgUrl { get; set; }

        /// <summary>
        /// 素材ID
        /// </summary>
        public string MaterialID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? Number { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 资源类型—2级
        /// </summary>
        public int? ResourceStyle { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }

        /// <summary>
        /// 文件ID外键
        /// </summary>

        public string FileID { get; set; }

        /// <summary>
        /// 描述
        /// </summary>

        public string Description { get; set; }

        /// <summary>
        /// 来源
        /// </summary>

        public string ComeFrom { get; set; }

        /// <summary>
        /// 评价量
        /// </summary>
        public int? AppraisedCounts { get; set; }

        /// <summary>
        /// 收藏量
        /// </summary>
        public int? CollectCounts { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        //
        /// <summary>
        /// </summary>
        public int? Copyrigh { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string CopyrighName { get; set; }
        /// <summary>
        /// 排序字段-2016-08-25添加
        /// </summary>
        public Int64 Sort { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        public int? TimeSpan { get; set; }

        /// <summary>
        /// 资源大类
        /// </summary>
        public int? ResourceClass { get; set; }
    }
}
