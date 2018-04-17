using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyNavSystemController : BaseController
    {
        public ActionResult Index(VModel.SySystem.Index m)
        {
            m.Grid = Bll.SySystemBll.GetGrid(m);
            return View(m);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(VModel.SySystem.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SySystemBll.Add(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                }
            }

            return View(m);
        }

        public ActionResult AddCatalog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCatalog(VModel.SySystem.FormCatalog m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SySystemBll.Add(m);
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
            VModel.SySystem.Form m = Bll.SySystemBll.GetEdit(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(VModel.SySystem.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SySystemBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return Json(new { success = true });
                }
            }

            return View(m);
        }

        public ActionResult EditCatalog(int id)
        {
            VModel.SySystem.FormCatalog m = Bll.SySystemBll.GetEditCatalog(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult EditCatalog(VModel.SySystem.FormCatalog m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SySystemBll.Edit(m);
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
            Common.Model.JsonData data = null;
            int r = Bll.SySystemBll.Delete(id);
            switch (r)
            {
                case 200:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.Succeed };
                    break;
                case -1:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，该节点下包含子节点不能删除！" };
                    break;
                case -2:
                    data = new Common.Model.JsonData { flag = Common.Model.JsonDataFlag.ValidFailed, msg = "删除失败，该系统还拥有左侧导航不能删除！" };
                    break;
            }

            return Json(data);
        }
    }
}