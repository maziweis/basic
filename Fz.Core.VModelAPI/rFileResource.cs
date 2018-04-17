using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
  public class rFileResource
    {
            public string FileID { get; set; }
            /// <summary>
            /// 文件ID
            /// </summary>
            public string UserID { get; set; }
            /// <summary>
            /// 文件ID
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 文件名称
            /// </summary>
            public string FileName { get; set; }
            /// <summary>
            /// 文件描述
            /// </summary>
            public string FileDescription { get; set; }
            /// <summary>
            /// 文件扩展
            /// </summary>
            public string FileExtension { get; set; }
            /// <summary>
            /// 文件大小
            /// </summary>
            public int FileSize { get; set; }
            /// <summary>
            ///x 文件路径
            /// </summary>
            public string FilePath { get; set; }
            /// <summary>
            /// 文件类型
            /// </summary>
            public int FileType { get; set; }
            /// <summary>
            /// 学科ID
            /// </summary>
            public int? SubjectID { get; set; }
            /// <summary>
            /// 年级ID
            /// </summary>
            public int? BookID { get; set; }
        /// <summary>
        /// 年级ID
        /// </summary>
        public int? GradeID { get; set; }
        /// <summary>
        /// 年级ID
        /// </summary>
        public int? EditionID { get; set; }
        /// <summary>
        /// 目录ID
        /// </summary>
        public int? Catalog { get; set; }
            /// <summary>
            /// 资源子类
            /// </summary>
            public int? ResourceStyle { get; set; }
    }
}
