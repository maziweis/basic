using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModel.SyClass
{
    public class Form
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 所属年级
        /// </summary>
        [Required(ErrorMessage = "所属年级不能为空")]
        [Display(Name = "所属年级")]
        public int? GradeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "班级名称不能为空")]
        [MaxLength(25, ErrorMessage = "请输入不超过25个字符的内容")]
        [Display(Name = "班级名称")]
        public string Name { get; set; }

        /// <summary>
        /// 排序值
        /// </summary>
        [Required(ErrorMessage = "排序值不能为空")]
        [RegularExpression(@"^([1-9]\d{0,4}|100000)$", ErrorMessage ="请输入1-100000的正整数")]
        [Display(Name = "排序值")]
        public int? Sort { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 学科与教师选择列表
        /// </summary>
        public List<TeacherSubjectGrid> TsGrid { get; set; }
    }

    public class TeacherSubjectGrid
    {
        /// <summary>
        /// 学科Id
        /// </summary>
        public int? SubjectId { get; set; }

        /// <summary>
        /// 教师Id
        /// </summary>
        public int? TeacherId { get; set; }
    }
}
