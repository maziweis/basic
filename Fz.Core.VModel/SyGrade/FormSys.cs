using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyGrade
{
    public class FormSys
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 入学年份
        /// </summary>
        [Required]
        [Display(Name = "入学年份")]
        public int? Year { get; set; }
    }
}
