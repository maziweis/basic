using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyNavController : BaseController
    {
        public ActionResult Index(VModel.SyNav.Index m, int id = 2)
        {
            m.SId = id;
            m.Grid = Bll.SyNavBll.GetGrid(m);
            return View(m);
        }

        public ActionResult Add(int SId)
        {
            VModel.SyNav.Form m = new VModel.SyNav.Form();
            m.SId = SId;
            m.IsEnabled = true;
            return View(m);
        }

        [HttpPost]
        public ActionResult Add(VModel.SyNav.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyNavBll.Add(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Name", "导航已存在。");
                        break;
                }
            }

            return View(m);
        }

        public ActionResult Edit(int id)
        {
            VModel.SyNav.Form m = Bll.SyNavBll.GetEdit(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SyNav.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SyNavBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                    case -1:
                        ModelState.AddModelError("Name", "导航已存在。");
                        break;
                }
            }

            return View(m);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Common.Model.JsonData data = null;
            int r = Bll.SyNavBll.Delete(id);
            switch (r)
            {
                case 200:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed };
                    break;
                case -1:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，该节点下包含子节点不能删除！" };
                    break;
                case -2:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，该导航已被角色引用不能删除！" };
                    break;
            }

            return Json(data);
        }
    }
}
