using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Room.VModel
{
    public class Student
    {
       
        public int Id { get; set; }
        public string UserID { get; set; }
        /// <summary>
        /// 帐号类型：1-教职工，2-学生，3-家长，4-方直管理账号
        /// </summary>
        public int Type { get; set; }
        public bool IsGraduate { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        public string Account { get; set; }
        public string Sex { get; set; }
        public int? year { get; set; }
        public string Avatar { get; set; }
    }
}
