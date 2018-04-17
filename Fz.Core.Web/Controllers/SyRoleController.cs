using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyRoleController : BaseController
    {
        public ActionResult Index(VModel.SyRole.Index m)
        {
            m.Grid = Bll.SyRoleBll.GetGrid(m);
            return View(m);
        }

        public ActionResult Add()
        {
            ViewBag.ZtreeJson = string.Format("var zNodes  = {0};", Common.JsonHelper.EncodeJson(Bll.SyNavBll.GetZTree()));
            return View();
        }

        [HttpPost]
        public ActionResult Add(VModel.SyRole.Form m)
        {
            List<Common.Model.ZTree> nodes = Bll.SyNavBll.GetZTree();

            if (!string.IsNullOrWhiteSpace(m.navs))
            {
                string[] ns = m.navs.Split(',');
                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        if (ns.Contains(node.id.ToString()))
                        {
                            node.@checked = true;
                        }
                    }
                }
            }

            ViewBag.ZtreeJson = string.Format("var zNodes  = {0};", Common.JsonHelper.EncodeJson(nodes));

            if (ModelState.IsValid)
            {
                int r = Bll.SyRoleBll.Add(m);
                switch (r)
                {
                    case 200:
                        return RedirectToAction("Index");
                    case 100:
                        ModelState.AddModelError("Name", "当前角色名已存在。");
                        break;
                }
            }

            return View(m);
        }

        public ActionResult Edit(int id)
        {
            VModel.SyRole.Form m = Bll.SyRoleBll.GetEdit(id);
            if (m != null && m.navlist != null)
            {
                foreach (var a in m.navlist)
                {
                    m.navs += a.ToString() + ",";
                }
            }


            List<Common.Model.ZTree> nodes = Bll.SyNavBll.GetZTree();
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    if (m.navlist.Contains(node.id))
                    {
                        node.@checked = true;
                    }
                }
            }
            ViewBag.ZtreeJson = string.Format("var zNodes  = {0};", Common.JsonHelper.EncodeJson(nodes));

            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SyRole.Form m)
        {
            List<Common.Model.ZTree> nodes = Bll.SyNavBll.GetZTree();

            if (!string.IsNullOrWhiteSpace(m.navs))
            {
                string[] ns = m.navs.Split(',');
                if (nodes != null)
                {
                    foreach (var node in nodes)
                    {
                        if (ns.Contains(node.id.ToString()))
                        {
                            node.@checked = true;
                        }
                    }
                }
            }

            ViewBag.ZtreeJson = string.Format("var zNodes  = {0};", Common.JsonHelper.EncodeJson(nodes));

            if (ModelState.IsValid)
            {
                int r = Bll.SyRoleBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return RedirectToAction("Index");
                    case 100:
                        ModelState.AddModelError("Name", "当前角色名已存在。");
                        break;
                }
            }

            return View(m);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            int r = Bll.SyRoleBll.Delete(id);
            if (r == 200)
                return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
            else
                return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，该角色下拥有活跃的老师" });
        }

        [HttpPost]
        public JsonResult Start(int id)
        {
            Bll.SyRoleBll.Enable(id, true);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Stop(int id)
        {
            Bll.SyRoleBll.Enable(id, false);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        public ActionResult Users(VModel.SyRole.RUser m)
        {
            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyRole.UserGrid>();
                m.Grid.Pager = new Common.Model.Pager();
                m.Grid = Bll.SyRoleBll.GetUsers(m);
            }
            else
            {
                m.Grid = Bll.SyRoleBll.GetUsers(m);
                if (Request.IsAjaxRequest())
                    return PartialView("_UsersGrid", m);
            }
            return View(m);
        }

        public FileResult Export(string id)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();//创建Excel文件的对象
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");//添加一个sheet
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);//给sheet1添加第一行的头部标题
            row1.CreateCell(0).SetCellValue("角色");
            row1.CreateCell(1).SetCellValue("帐号");
            row1.CreateCell(2).SetCellValue("姓名");
            row1.CreateCell(3).SetCellValue("过期时间");
            row1.CreateCell(4).SetCellValue("状态");

            List<int> rids = new List<int>();
            string[] ids = id.Split('_');
            foreach (var d in ids)
            {
                if (!string.IsNullOrWhiteSpace(d))
                    rids.Add(int.Parse(d));
            }

            List<VModel.SyUserManager.Grid> list = Bll.SyUserBll.ExportByRoleIds(rids);
            int i = 1;
            foreach (var m in list)
            {
                NPOI.SS.UserModel.IRow r = sheet1.CreateRow(i);
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
                    r.CreateCell(0).SetCellValue(roleName);
                }
                else
                {
                    r.CreateCell(0).SetCellValue("");
                }
                r.CreateCell(1).SetCellValue(m.Account);
                r.CreateCell(2).SetCellValue(m.Name);
                r.CreateCell(3).SetCellValue(Common.Function.ConvertDate(m.ExpiresTime));
                r.CreateCell(4).SetCellValue(Common.Dict.UserState.GetVal(m.IsEnabled));
                i++;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();// 写入到客户端 
            book.Write(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);

            string fileName = "角色包含用户表.xls";
            return File(ms, "application/vnd.ms-excel", fileName);
        }
    }
}
