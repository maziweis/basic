using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyLogRoomOperController : Controller
    {
        public ActionResult Index(VModel.SyLogRoomOper.Index m)
        {
            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyLogRoomOper.Grid>();
                m.Grid.Pager = new Common.Model.Pager();
            }
            int total = 0;
            List<RoomLogList> list = BigdataBll.ClrLogMonitorWeb_GetList(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, out total, m.StartDate, m.EndDate);
            m.Grid.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, total);
            m.Grid.Data = new List<VModel.SyLogRoomOper.Grid>();
            foreach (RoomLogList log in list)
            {
                m.Grid.Data.Add(new VModel.SyLogRoomOper.Grid
                {
                    Account = Bll.SyUserBll.GetAccount(log.CreateUserId),
                    UserName = Bll.SyUserBll.GetName(log.CreateUserId),
                    RoleNames = Bll.SyRoleBll.GetRoleNamesByUserId(log.CreateUserId),
                    OperId = log.OperId,
                    CreateTime = log.CreateTime
                });
            }
            return View(m);
        }

        public FileResult Export()
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();//创建Excel文件的对象
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");//添加一个sheet
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);//给sheet1添加第一行的头部标题
            row1.CreateCell(0).SetCellValue("用户名");
            row1.CreateCell(1).SetCellValue("姓名");
            row1.CreateCell(2).SetCellValue("角色");
            row1.CreateCell(3).SetCellValue("操作");
            row1.CreateCell(4).SetCellValue("时间");

            List<RoomLogList> list = BigdataBll.ClrLogMonitorWeb_GetListAll(null, null);
            int i = 1;
            foreach (var log in list)
            {
                string roleNames = "";
                var roles = Bll.SyRoleBll.GetRoleNamesByUserId(log.CreateUserId);
                foreach (var role in roles)
                {
                    if (!string.IsNullOrWhiteSpace(role))
                        roleNames += role + "，";
                }
                if (roleNames != "")
                {
                    roleNames = roleNames.Substring(0, roleNames.Length - 1);
                }

                NPOI.SS.UserModel.IRow r = sheet1.CreateRow(i);
                r.CreateCell(0).SetCellValue(Bll.SyUserBll.GetAccount(log.CreateUserId));
                r.CreateCell(1).SetCellValue(Bll.SyUserBll.GetName(log.CreateUserId));
                r.CreateCell(2).SetCellValue(roleNames);
                r.CreateCell(3).SetCellValue(Common.Dict.RoomOperType.GetVal(log.OperId));
                r.CreateCell(4).SetCellValue(log.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                i++;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();// 写入到客户端 
            book.Write(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);

            return File(ms, "application/vnd.ms-excel", "互动课堂.xls");
        }
    }
}