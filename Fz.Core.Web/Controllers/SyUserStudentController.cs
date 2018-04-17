using Fz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyUserStudentController : BaseController
    {     
        public ActionResult Index(VModel.SyUserStudent.Index m, int id = 1)
        {
            m.Type = id;
            ViewBag.Type = id;

            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyUserStudent.Grid>();
                m.Grid.Pager = new Common.Model.Pager();
            }

            m.Grid = Bll.SyUserBll.GetGrid(m);

            return View(m);
        }

        public ActionResult Add()
        {
            VModel.SyUserStudent.Form m = new VModel.SyUserStudent.Form();
            m.IsEnabled = true;
            m.RoleIds = new List<int>();
            m.RoleIds.Add(4);
            return View(m);
        }

        [HttpPost]
        public ActionResult Add(VModel.SyUserStudent.Form m)
        {
            if (m.ExpiresTime != null && m.ExpiresTime <= DateTime.Now.Date)
            {
                ModelState.AddModelError("ExpiresTime", "过期时间必须大于当前日期。");
            }

            if (ModelState.IsValid)
            {
                int r = Bll.SyUserBll.AddStudent(m);
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
            VModel.SyUserStudent.Form m = Bll.SyUserBll.GetEditStudent(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SyUserStudent.Form m)
        {
            if (m.ExpiresTime != null && m.ExpiresTime <= DateTime.Now.Date)
            {
                ModelState.AddModelError("ExpiresTime", "过期时间必须大于当前日期。");
            }

            if (ModelState.IsValid)
            {
                int r = Bll.SyUserBll.EditStudent(m);
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
            Bll.SyUserBll.DeleteStudent(id);
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
        }

        [HttpPost]
        public JsonResult Deletes(string[] ids)
        {
            Bll.SyUserBll.DeleteStudents(ids);
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
            row1.CreateCell(2).SetCellValue("性别");
            row1.CreateCell(3).SetCellValue("所属年级");
            row1.CreateCell(4).SetCellValue("所属班级");
            row1.CreateCell(5).SetCellValue("过期时间");
            row1.CreateCell(6).SetCellValue("状态");
            row1.CreateCell(7).SetCellValue("角色");

            bool enable = id == 1 ? true : false;
            List<VModel.SyUserStudent.Grid> list = Bll.SyUserBll.ExportStudent(enable);
            int i = 1;
            foreach (var m in list)
            {
                NPOI.SS.UserModel.IRow r = sheet1.CreateRow(i);
                r.CreateCell(0).SetCellValue(m.Account);
                r.CreateCell(1).SetCellValue(m.Name);
                r.CreateCell(2).SetCellValue(m.Sex);
                if (m.Grade != null)
                    r.CreateCell(3).SetCellValue(Bll.SyGradeBll.GetName((int)m.Grade));
                if (m.Class != null)
                    r.CreateCell(4).SetCellValue(Bll.SyClassBll.GetName((int)m.Class));
                r.CreateCell(5).SetCellValue(Common.Function.ConvertDate(m.ExpiresTime));
                r.CreateCell(6).SetCellValue(Common.Dict.UserState.GetVal(m.IsEnabled));
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
                    r.CreateCell(7).SetCellValue(roleName);
                }
                else
                {
                    r.CreateCell(7).SetCellValue("");
                }
                i++;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();// 写入到客户端 
            book.Write(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            string fileName = enable == true ? "当前学生用户.xls" : "历史学生用户.xls";
            return File(ms, "application/vnd.ms-excel", UrlEcode.ToHexString(fileName));
        }
        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(VModel.SyUserStudent.FormImport m)
        {
            if (ModelState.IsValid)
            {
                if (m.File.FileName.ToLower().IndexOf("xls") == -1)
                {
                    ModelState.AddModelError("File", string.Format("导入文件必须为Excel文件"));
                    return View(m);
                }
                NPOI.SS.UserModel.IWorkbook book = NPOI.SS.UserModel.WorkbookFactory.Create(m.File.InputStream);
                NPOI.SS.UserModel.ISheet sheet = book.GetSheetAt(0);

                if (sheet != null)
                {
                    List<VModel.SyUserStudent.ImportData> list = new List<VModel.SyUserStudent.ImportData>();
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
                        }
                        else if (Bll.SyTeacherBll.IsExist(row.GetCell(0).ToString(), null))
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
                        //else if (Bll.SyTeacherBll.IsExist(null, row.GetCell(1).ToString()))
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
                            ModelState.AddModelError("File", string.Format("第{0}行“性别”不能为空", i + 1));
                            return View(m);
                        }
                        else if (row.GetCell(3) == null || string.IsNullOrWhiteSpace(row.GetCell(3).ToString()))
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“年级”不能为空", i + 1));
                            return View(m);
                        }
                        else if (Bll.SyGradeBll.IsExist(row.GetCell(3).ToString()) == false)
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“年级”不存在", i + 1));
                            return View(m);
                        }
                        else if (row.GetCell(4) == null || string.IsNullOrWhiteSpace(row.GetCell(4).ToString()))
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“班级”不能为空", i + 1));
                            return View(m);
                        }
                        else if (Bll.SyClassBll.IsExist(row.GetCell(3).ToString(),row.GetCell(4).ToString()) == false)
                        {
                            ModelState.AddModelError("File", string.Format("第{0}行“班级”不存在", i + 1));
                            return View(m);
                        }

                        VModel.SyUserStudent.ImportData data = new VModel.SyUserStudent.ImportData();
                        data.Account = row.GetCell(0).ToString();
                        data.Name = row.GetCell(1).ToString();
                        data.Sex = row.GetCell(2).ToString();
                        data.Grade = row.GetCell(3).ToString();
                        data.Class = row.GetCell(4).ToString();
                        list.Add(data);
                    }

                    int r = Bll.SyUserBll.ImportStudent(list);
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