using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fz.Core.VModel.SyUserStudent
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
        public string Sex { get; set; }
        public string Grade { get; set; }
        public string Class { get; set; }
    }
}
