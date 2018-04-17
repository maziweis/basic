using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyClassController : BaseController
    {
        public ActionResult Index(VModel.SyClass.Index m)
        {
            m.Grades = Bll.SyGradeBll.GetSelect();
            m.Grid = Bll.SyClassBll.GetGrid(m);
            return View(m);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(VModel.SyClass.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyClassBll.Add(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Name", "当前年级下班级名重复");
                       break;
                }
            }

            return View(m);
        }

        public ActionResult Edit(int id)
        {
            VModel.SyClass.Form m = Bll.SyClassBll.GetEdit(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SyClass.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyClassBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case 100:
                        ModelState.AddModelError("Name", "当前年级下的班级名重复");
                        break;
                    case -1:
                        ModelState.AddModelError("IsEnabled", "该班级还有学生不能被停用。");
                        break;                 
                }
            }

            return View(m);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Common.Model.JsonData data = null;
            int r = Bll.SyClassBll.Delete(id);
            switch (r)
            {
                case 200:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed };
                    break;
                case -1:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，班级中存在学生不能删除！" };
                    break;
                case -2:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，班级中存在教师不能删除！" };
                    break;
            }

            return Json(data);
        }
        /// <summary>
        /// Ajax根据年级获取班级列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSelect(int gradeId)
        {
            return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed, data = new SelectList(Bll.SyClassBll.GetSelect(gradeId), "key", "value") });
        }
    }
}