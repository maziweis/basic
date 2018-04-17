using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
    public class R_ResourceExport_File
    {
        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FileSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FileType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? FinishStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? EncryptStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ConvertStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? UploadTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Height { get; set; }
    }
}
