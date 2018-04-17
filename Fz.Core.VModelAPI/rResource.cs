using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
    public class rResource
    {
            /// <summary>
            /// 资源ID
            /// </summary>
            public string ResourceID { get; set; }
            /// <summary>
            /// 资源名称
            /// </summary>
            public string ResourceName { get; set; }
            /// <summary>
            /// 文件ID
            /// </summary>
            public string FileID { get; set; }
            /// <summary>
            /// 资源描述
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// 资源资源细分
            /// </summary>
            public int? ResourceStyle { get; set; }
            /// <summary>
            /// 资源类型
            /// </summary>
            public int? ResourceType { get; set; }
            /// <summary>
            /// 资源大小
            /// </summary>
            public decimal? ResourceSize { get; set; }
            /// <summary>
            /// 学科ID
            /// </summary>
            public int? SubjectID { get; set; }
            /// <summary>
            /// 版本ID
            /// </summary>
            public int? EditionID { get; set; }
            /// <summary>
            /// 年级ID
            /// </summary>
            public int? GradeID { get; set; }
            /// <summary>
            /// 目录ID
            /// </summary>
            public int? Catalog { get; set; }
            /// <summary>
            /// 册别ID
            /// </summary>
            public int? BookReelID { get; set; }
            /// <summary>
            /// 学段
            /// </summary>
            public int? SchoolStage { get; set; }

            /// <summary>
            /// 关键字
            /// </summary>
            public string KeyWords { get; set; }
            /// <summary>
            /// 文件类型
            /// </summary>
            public string FileType { get; set; }
            /// <summary>
            /// 缩略图
            /// </summary>
            public string BreviaryImgUrl { get; set; }
            /// <summary>
            /// 资源添加人ID
            /// </summary>
            public string ResourceCreaterID { get; set; }
            /// <summary>
            /// 资源添加人姓名
            /// </summary>
            public string ResourceCreaterName { get; set; }
            /// <summary>
            /// 资源上传时间
            /// </summary>
            public DateTime? ResourceCreaterDate { get; set; }

        }
    }
