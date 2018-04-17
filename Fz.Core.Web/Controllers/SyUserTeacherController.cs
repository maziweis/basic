using Fz.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyUserTeacherController : BaseController
    {
        public ActionResult Index(VModel.SyUserTeacher.Index m, int id = 1)
        {
            m.Type = id;
            ViewBag.Type = id;

            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyUserTeacher.Grid>();
                m.Grid.Pager = new Common.Model.Pager();
            }

            m.Grid = Bll.SyUserBll.GetGrid(m);

            return View(m);
        }

        public ActionResult Add()
        {
            VModel.SyUserTeacher.Form m = new VModel.SyUserTeacher.Form();
            m.IsEnabled = true;
            m.RoleIds = new List<int>();
            m.RoleIds.Add(3);
            return View(m);
        }

        [HttpPost]
        public ActionResult Add(VModel.SyUserTeacher.Form m)
        {
            if (m.ExpiresTime != null && m.ExpiresTime <= DateTime.Now.Date)
            {
                ModelState.AddModelError("ExpiresTime", "过期时间必须大于当前日期。");
            }

            if (ModelState.IsValid)
            {
                int r = Bll.SyUserBll.AddTeacher(m);
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
            VModel.SyUserTeacher.Form m = Bll.SyUserBll.GetEditTeacher(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SyUserTeacher.Form m)
        {
            if (m.ExpiresTime != null && m.ExpiresTime <= DateTime.Now.Date)
            {
                ModelState.AddModelError("ExpiresTime", "过期时间必须大于当前日期。");
            }

            if (ModelState.IsValid)
            {
                int r = Bll.SyUserBll.EditTeacher(m);
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
            Bll.SyUserBll.DeleteTeacher(id);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Deletes(string[] ids)
        {
            Bll.SyUserBll.DeleteTeachers(ids);
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

        public FileResult Export(int id)
        {
            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();//创建Excel文件的对象
            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");//添加一个sheet
            NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(0);//给sheet1添加第一行的头部标题
            row1.CreateCell(0).SetCellValue("帐号");
            row1.CreateCell(1).SetCellValue("姓名");
            row1.CreateCell(2).SetCellValue("主学科");
            row1.CreateCell(3).SetCellValue("过期时间");
            row1.CreateCell(4).SetCellValue("状态");
            row1.CreateCell(5).SetCellValue("角色");

            bool enable = id == 1 ? true : false;
            List<VModel.SyUserTeacher.Grid> list = Bll.SyUserBll.ExportTeacher(enable);
            int i = 1;
            foreach (var m in list)
            {
                NPOI.SS.UserModel.IRow r = sheet1.CreateRow(i);
                r.CreateCell(0).SetCellValue(m.Account);
                r.CreateCell(1).SetCellValue(m.Name);
                r.CreateCell(2).SetCellValue(Bll.DictSubjectBll.GetName(m.Subject));
                r.CreateCell(3).SetCellValue(Common.Function.ConvertDate(m.ExpiresTime));
                r.CreateCell(4).SetCellValue(Common.Dict.UserState.GetVal(m.IsEnabled));
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
                    r.CreateCell(5).SetCellValue(roleName);
                }
                else
                {
                    r.CreateCell(5).SetCellValue("");
                }
                i++;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();// 写入到客户端 
            book.Write(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            string fileName = enable == true ? "当前教师用户.xls" : "历史教师用户.xls";
            return File(ms, "application/vnd.ms-excel", UrlEcode.ToHexString(fileName));
        }

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(VModel.SyUserTeacher.FormImport m)
        {
            if (ModelState.IsValid)
            {
                if (m.File.FileName.ToLower().IndexOf("xls") == -1) {
                    ModelState.AddModelError("File", string.Format("导入文件必须为Excel文件"));
                    return View(m);
                }
                NPOI.SS.UserModel.IWorkbook book = NPOI.SS.UserModel.WorkbookFactory.Create(m.File.InputStream);
                NPOI.SS.UserModel.ISheet sheet = book.GetSheetAt(0);

                if (sheet != null)
                {
                    List<VModel.SyUserTeacher.ImportData> list = new List<VModel.SyUserTeacher.ImportData>();
                    NPOI.SS.UserModel.IRow firstRow = sheet.GetRow(0);
                    int startRow = sheet.FirstRowNum + 2;
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        NPOI.SS.UserModel.IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        if (row.GetCell(0) == null || string.IsNullOrWhiteSpace(row.GetCell(0).ToString()))
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“用户名”不能为空", i + 1));
                            return View(m);
                        }else if (Bll.SyTeacherBll.IsExist(row.GetCell(0).ToString(),null))
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“用户名”已经存在", i + 1));
                            return View(m);
                        }
                        else if (row.GetCell(0).ToString().Length > 20)
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“用户名”最大长度不超过20个字符的内容", i + 1));
                            return View(m);
                        }
                        else if (row.GetCell(1) == null || string.IsNullOrWhiteSpace(row.GetCell(1).ToString()))
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“姓名”不能为空", i + 1));
                            return View(m);
                        }
                        //else if (Bll.SyTeacherBll.IsExist(null,row.GetCell(1).ToString()))
                        //{
                        //    ModelState.AddModelError("File", string.Format("第{0}行“姓名”已经存在", i + 1));
                        //    return View(m);
                        //}
                        else if (row.GetCell(1).ToString().Length > 20)
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“姓名”最大长度不超过20个字符的内容", i + 1));
                            return View(m);
                        }
                        else if (row.GetCell(2) == null || string.IsNullOrWhiteSpace(row.GetCell(2).ToString()))
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“学科”不能为空", i + 1));
                            return View(m);
                        }
                        else if (Bll.DictSubjectBll.IsExist(row.GetCell(2).ToString()) == false)
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“学科”不存在", i + 1));
                            return View(m);
                        }

                        VModel.SyUserTeacher.ImportData data = new VModel.SyUserTeacher.ImportData();
                        data.Account = row.GetCell(0).ToString();
                        data.Name = row.GetCell(1).ToString();
                        data.SubjectName = row.GetCell(2).ToString();
                        list.Add(data);
                    }

                    int r = Bll.SyUserBll.ImportTeacher(list);
                    switch (r)
                    {
                        case 200:
                            return RedirectToAction("Index");
                    }
                }
            }

            return View(m);
        }

        [HttpPost]
        public JsonResult ResetPwd(string id)
        {
            Bll.SyUserBll.ResetPwd(id);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }
    }
}