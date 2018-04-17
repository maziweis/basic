using Fz.Core.Web.Controllers;
using Fz.Resource.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Resource.Web.Controllers
{
    public class ResourceDynamicController : BaseController
    {
        // GET: ResourceDynamic
        public ActionResult Index(int id)
        {            
            ViewBag.PageTypeId = id;//左侧菜单选中用
            string UserID = GetUserId();
            List<VModel.ResourceDynamic.From> ResDynamicList = ResourceDynamicBll.GetResourceDynamicBySubjectID(id);
            return View(ResDynamicList);
        }      
    }
}