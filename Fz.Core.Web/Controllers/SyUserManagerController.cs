using Fz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyUserManagerController : BaseController
    {
        public ActionResult Index(VModel.SyUserManager.Index m, int id = 1)
        {
            m.Type = id;
            ViewBag.Type = id;

            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyUserManager.Grid>();
                m.Grid.Pager = new Common.Model.Pager();
            }

            m.Grid = Bll.SyUserBll.GetGrid(m);

            return View(m);
        }

        public ActionResult Add()
        {
            VModel.SyUserManager.Form m = new VModel.SyUserManager.Form();
            m.IsEnabled = true;
            m.RoleIds = new List<int>();
            m.RoleIds.Add(2);
            return View(m);
        }

        [HttpPost]
        public ActionResult Add(VModel.SyUserManager.Form m)
        {
            if (m.ExpiresTime != null && m.ExpiresTime <= DateTime.Now.Date)
            {
                ModelState.AddModelError("ExpiresTime", "过期时间必须大于当前日期。");
            }

            if (ModelState.IsValid)
            {
                int r = Bll.SyUserBll.AddManager(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Account", "帐号已存在。");
                        break;
                }
            }
            return View(m);
        }

        public ActionResult Edit(string id)
        {
            VModel.SyUserManager.Form m = Bll.SyUserBll.GetEditManager(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SyUserManager.Form m)
        {
            if (m.ExpiresTime != null && m.ExpiresTime <= DateTime.Now.Date)
            {
                ModelState.AddModelError("ExpiresTime", "过期时间必须大于当前日期。");
            }

            if (ModelState.IsValid)
            {
                int r = Bll.SyUserBll.EditManager(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Account", "帐号已存在。");
                        break;
                }
            }

            return View(m);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            Bll.SyUserBll.DeleteManager(id);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Deletes(string[] ids)
        {
            Bll.SyUserBll.DeleteManagers(ids);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Start(string id)
        {
            Bll.SyUserBll.Enable(id, true);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Starts(string[] ids)
        {
            Bll.SyUserBll.Enables(ids, true);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Stop(string id)
        {
            Bll.SyUserBll.Enable(id, false);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Stops(string[] ids)
        {
            Bll.SyUserBll.Enables(ids, false);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult ResetPwd(string id)
        {
            Bll.SyUserBll.ResetPwd(id);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        public FileResult Export(int id)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();//创建Excel文件的对象
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");//添加一个sheet
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);//给sheet1添加第一行的头部标题
            row1.CreateCell(0).SetCellValue("帐号");
            row1.CreateCell(1).SetCellValue("姓名");
            row1.CreateCell(2).SetCellValue("过期时间");
            row1.CreateCell(3).SetCellValue("状态");
            row1.CreateCell(4).SetCellValue("角色");

            bool enable = id == 1 ? true : false;
            List<VModel.SyUserManager.Grid> list = Bll.SyUserBll.ExportManager(enable);
            int i = 1;
            foreach (var m in list)
            {
                NPOI.SS.UserModel.IRow r = sheet1.CreateRow(i);
                r.CreateCell(0).SetCellValue(m.Account);
                r.CreateCell(1).SetCellValue(m.Name);
                r.CreateCell(2).SetCellValue(Common.Function.ConvertDate(m.ExpiresTime));
                r.CreateCell(3).SetCellValue(Common.Dict.UserState.GetVal(m.IsEnabled));
                if (m.RoleNames != null && m.RoleNames.Count > 0)
                {
                    string roleName = "";
                    foreach (var name in m.RoleNames)
                    {
                        roleName += name + "，";
                    }
                    if (roleName != "")
                    {
                        roleName = roleName.Substring(0, roleName.Length - 1);
                    }
                    r.CreateCell(4).SetCellValue(roleName);
                }
                else
                {
                    r.CreateCell(4).SetCellValue("");
                }
                i++;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();// 写入到客户端 
            book.Write(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);

            string fileName = enable == true ? "当前管理员用户.xls" : "历史管理员用户.xls";
            return File(ms, "application/vnd.ms-excel", UrlEcode.ToHexString(fileName));
        }
    }
}
