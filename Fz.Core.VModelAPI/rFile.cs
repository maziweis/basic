using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
    public class rFile
    {
        public string ID { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public decimal? FileSize { get; set; }

        public int FileType { get; set; }
        public string FilePath { get; set; }
    }
}
