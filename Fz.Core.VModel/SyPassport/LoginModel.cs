using System.ComponentModel.DataAnnotations;

namespace Fz.Core.VModel.SyPassport
{
    public class LoginModel
    {
        [Required(ErrorMessage = "请输入用户名！")]
        [Display(Name = "用户名")]
        public string Account { get; set; }

        [Required(ErrorMessage = "请输入密码！")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        public string pwd2 { get; set; }

        public bool ChkPwd { get; set; }

        public int? SId { get; set; }
    }

    public class LoginInfoModel
    {
        public string Account { get; set; }
        public string Ip { get; set; }
        public string Time { get; set; }
    }
}