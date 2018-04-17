using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Files.Web.Model
{
    public class FileType
    {
        public enum filetype {
            /// <summary>
            /// 其它
            /// </summary>
            Other = 0,
            /// <summary>
            /// 文本
            /// </summary>
            TXT = 1,
            /// <summary>
            /// world文档
            /// </summary>
            DOC = 2,
            /// <summary>
            /// Excel文件
            /// </summary>
            XLS = 3,
            /// <summary>
            /// ppt文件
            /// </summary>
            PPT = 4,
            /// <summary>
            /// pdf文件
            /// </summary>
            PDF =5,
            /// <summary>
            /// 小于6说明都需要转换格式
            /// </summary>
            ConvetWatershed = 6,
            /// <summary>
            /// 图片格式
            /// </summary>
            Image =7,
            /// <summary>
            /// 视频格式
            /// </summary>
            Video = 8,
            /// <summary>
            /// 音频格式
            /// </summary>
            Audio = 9,
           /// <summary>
           /// 压缩包
           /// </summary>
            RAR = 10,
            /// <summary>
            /// flash文件
            /// </summary>
            Flash  =11


        }
    }
}