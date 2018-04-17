using Fz.Core.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Resource.Web.Controllers
{
    public class ResourceHomeController : BaseController
    {
        // GET: ResourceHome
        public ActionResult Index(VModel.ResourceHome.Form Resource)
        {
            string UserID = GetUserId();
            Resource = Bll.ResourceHomeBll.GetResourceTotal(UserID, GetUserSubjectId());
            return View(Resource);
        }
        /// <summary>
        /// 搜索资源
        /// </summary>
        /// <param name="SubjectID"></param>
        /// <param name="SearchKey"></param>
        /// <returns></returns>
        public ActionResult ResourceShow(int? SubjectID, string SearchKey) {
            VModel.SearchResource.Form Res = new VModel.SearchResource.Form();
            Res.SubjectID = SubjectID;
            Res.ResourceName = SearchKey;
            return RedirectToAction("Index", "ResourceSearch", Res);        
        }
        /// <summary>
        /// 学校资源统计
        /// </summary>
        /// <returns></returns>
        public JsonResult GetResourceStatic() {
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.ResourceHomeBll.ResourceStatic();
            return Json(jsondata);

        }
        /// <summary>
        /// 获取资源动态
        /// </summary>
        /// <param name="SubjectId"></param>
        /// <returns></returns>
        public JsonResult GetResourceDynamic(int SubjectId)
        {
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.ResourceDynamicBll.GetResourceDynamicBySubjectID(SubjectId);
            return Json(jsondata);
        }
    }
}