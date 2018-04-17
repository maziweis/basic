using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyGradeController : BaseController
    {
        public ActionResult Index(VModel.SyGrade.Index m)
        {
            m.Grid = Bll.SyGradeBll.GetGrid(m);
            return View(m);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(VModel.SyGrade.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyGradeBll.Add(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Year", "入学年份已存在。");
                        break;
                    case -2:
                        ModelState.AddModelError("Name", "当前年级已存在。");
                        break;
                }
            }

            return View(m);
        }

        public ActionResult Edit(int id)
        {
            VModel.SyGrade.Form m = Bll.SyGradeBll.GetEdit(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SyGrade.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyGradeBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Year", "入学年份已存在。");
                        break;
                    case -2:
                        ModelState.AddModelError("Name", "当前年级已存在。");
                        break;
                }
            }

            return View(m);
        }

        public ActionResult EditSys(int id)
        {
            VModel.SyGrade.FormSys m = Bll.SyGradeBll.GetEditSys(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult EditSys(VModel.SyGrade.FormSys m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyGradeBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Year", "入学年份已存在。");
                        break;
                }
            }

            return View(m);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Common.Model.JsonData data = null;
            int r = Bll.SyGradeBll.Delete(id);
            switch (r)
            {
                case 200:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed };
                    break;
                case -1:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，年级中存在班级不能删除！" };
                    break;
            }

            return Json(data);
        }

        public ActionResult Graduate()
        {
            return View(Bll.SyGradeBll.GetGraduate());
        }

        [HttpPost]
        public ActionResult SaveGraduate()
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyGradeBll.SaveGraduate();
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("NotGraduate", "没有适合毕业的年级！");
                        break;
                    case -2:
                        ModelState.AddModelError("NotGraduate", "没有适合毕业的班级！");
                        break;
                    case -3:
                        ModelState.AddModelError("NotGraduate", "没有适合毕业的学生！");
                        break;
                }
            }

            return View("Graduate", Bll.SyGradeBll.GetGraduate());
        }

        public ActionResult Up()
        {
            return View(Bll.SyGradeBll.GetUp());
        }

        [HttpPost]
        public ActionResult SaveUp()
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyGradeBll.SaveUp();
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("NotGraduate", "尚有学生未毕业！");
                        break;
                    case -2:
                        ModelState.AddModelError("NotGraduate", "没有适合升级的年级！");
                        break;
                }
            }

            return View("Up", Bll.SyGradeBll.GetUp());
        }
    }
}