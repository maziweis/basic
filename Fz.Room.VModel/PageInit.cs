using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Room.VModel
{
    public class PageInit
    {        
        public string UserID { get; set; }  //用户ID        
        public int? BookID { get; set; }//书籍ID
        public List<UnitInfo> UnitInfo { get; set; }//单元列表

        public string BookName { get; set; }//书名
        
    }
    public class UnitInfo
    {
        public int? UnitID { get; set; }//单元ID
        public string UnitName { get; set; }//单元名
    }
}
