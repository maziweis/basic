using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fz.Core.VModel.SyInit
{
    public class InitForm
    {
        [Required(ErrorMessage = "学校名称不能为空")]
        [MaxLength(50,ErrorMessage = "请输入不超过50个字符的内容！")]
        //[RegularExpression(@"[\u4e00-\u9fa5]", ErrorMessage = "不能包含中文！")]
        [Display(Name = "学校名称")]
        public string SchoolName { get; set; }
        [Required(ErrorMessage = "授权信息不能为空")]
        [MaxLength(200, ErrorMessage = "请输入不超过200个字符的内容！")]
        [Display(Name = "授权信息")]
        public string AuthMessage { get; set; }
        public string[] chooseEdis1 { get; set; }
        public string[] chooseEdis2 { get; set; }
        public string[] chooseEdis3 { get; set; }
        public HttpPostedFileBase File { get; set; }
        public List<EdiSubGrid> choEdi { get; set; }
    }
}
