using Fz.Core.Bll;
using Fz.Core.VModel.SyInit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyInitController : BaseController
    {
        // GET: SyInit
        public ActionResult Index()
        {
            InitForm initform = new InitForm();
            initform = SysInitBll.GetInitForm();
            return View(initform);
        }
        public ActionResult Edit()
        {
            InitForm initform = new InitForm();
            initform = SysInitBll.GetInitForm();
            return View(initform);
        }
        [HttpPost]
        public ActionResult Edit(InitForm initform)
        {
            if (ModelState.IsValid)
            {
                if(initform.File != null && !string.IsNullOrEmpty(initform.File.FileName)){
                    string path = Server.MapPath("/") + "favicon.ico";
                    initform.File.SaveAs(path);
                }
             
                bool flag = SysInitBll.SaveInitForm(initform);
                if (flag)
                {
                   return RedirectToAction("Index", "SyInit");
                }

            }
            else {
                initform = SysInitBll.GetInitForm();
            }
            return View(initform);
        }
    }
}