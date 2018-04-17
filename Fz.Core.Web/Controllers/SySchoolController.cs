using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SySchoolController : BaseController
    {
        public ActionResult Index()
        {
            return View(Bll.SySchoolBll.GetEdit());
        }

        public ActionResult Edit()
        {
            VModel.SySchool.Form m = Bll.SySchoolBll.GetEdit();
            return View(m);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(VModel.SySchool.Form m)
        {
            if (ModelState.IsValid)
            {
                int r = Bll.SySchoolBll.Edit(m);
                switch (r)
                {
                    case 200:
                        return RedirectToAction("Index");
                }
            }

            return View(m);
        }
    }
}