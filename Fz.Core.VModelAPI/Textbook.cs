using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
    public class Textbook
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 学段
        /// </summary>
        public int Stage { get; set; }

        /// <summary>
        /// 学科
        /// </summary>
        public int Subject { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 册别
        /// </summary>
        public int Booklet { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Edition { get; set; }

        /// <summary>
        /// 教材名称
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 教材配置文件
        /// </summary>
        public string BookConfig { get; set; }

        /// <summary>
        /// 教材封面
        /// </summary>
        public string BookCover { get; set; }
    }
}
