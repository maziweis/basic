using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class DictSubjectController : BaseController
    {
        public ActionResult Index(VModel.DictSubject.Index m)
        {
            m.Grid = Bll.DictSubjectBll.GetGrid(m);
            return View(m);
        }

        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(VModel.DictSubject.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.DictSubjectBll.Add(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                }
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            VModel.DictSubject.Form m = Bll.DictSubjectBll.GetEdit(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.DictSubject.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.DictSubjectBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                }
            }
            return View(m);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            int rv = Bll.DictSubjectBll.Delete(id);
            if (rv == 200)
            {
                return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed });
            }
            else
            {
                return Json(new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，该科目下存在活跃的老师！" });
            }
        }
    }
}