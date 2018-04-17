using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Fz.Core.VModel.SyUserTeacher
{
    public class FormImport
    {
        [Required(ErrorMessage = "未选择导入文件")]
        [Display(Name = "选择导入Excel")]
        public HttpPostedFileBase File { get; set; }
    }

    public class ImportData
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public string SubjectName { get; set; }
    }
}
