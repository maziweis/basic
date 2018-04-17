using Fz.Core.Web.Controllers;
using Fz.Resource.VModel.MyResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Resource.Web.Controllers
{
    public class ResourceController : BaseController
    {
        public ActionResult Index(VModel.MyResource.Form Reslist, int id)
        {                   
            ViewBag.PageTypeId = id;//左侧菜单选中用
            string UserID = GetUserId();
            Reslist.ResBelong = id;
            if (Reslist.SubjectID == null)
            {
                Reslist.SubjectID = GetUserSubjectId();
                if(Reslist.SubjectID == null)
                {
                    Reslist.SubjectID = 3;
                }                            
            }       
            if (Reslist.ResourceStyle == null)
            {
                Reslist.ResourceStyle = 0;
            }
            if (Reslist.OrderBy == null)
            {
                Reslist.OrderBy = 1;
            }
            if (Reslist.GridList == null)
            {
                Reslist.GridList = new Common.Model.PList<VModel.MyResource.Grid>();
                Reslist.GridList.Pager = new Common.Model.Pager();
            }

            switch (id)
            {
                case 0:
                    Reslist.GridList = Bll.MyResourceBll.GetMyResourceAll(Reslist, UserID);
                    break;
                case 1:
                    Reslist.GridList = Bll.MyResourceBll.GetMyResourceFavorite(Reslist, UserID);
                    break;
                case 2:
                    Reslist.GridList = Bll.MyResourceBll.GetMyResourceUp(Reslist, UserID);
                    break;
            }
            ViewBag.MyResource = Bll.SearchResourceBll.GetMyResource(UserID);
            ViewBag.UserID = UserID;
            return View(Reslist);
        }

        /// <summary>
        /// 通过资源ID获取资源信息
        /// </summary>
        /// <param name="ResId"></param>
        /// <returns></returns>
        public JsonResult GetResourceById(string ResId)
        {
            string UserId = GetUserId(); 
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.SearchResourceBll.GetResourceById(ResId, UserId);
            return Json(jsondata);
        }

        /// <summary>
        /// 资源分享
        /// </summary>
        /// <param name="Resid"></param>
        /// <returns></returns>
        public JsonResult ResourceShare(string Resids)
        {
            string UserID = GetUserId();
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.MyResourceBll.ResourceShare(Resids, UserID);
            return Json(jsondata);

        }

        /// <summary>
        /// 我的资源（全部资源、上传资源、收藏资源）
        /// </summary>
        /// <param name="Reslist"></param>
        /// <returns></returns>
        public JsonResult GetMyResource(VModel.MyResource.Form Reslist)
        {
            string UserID = GetUserId();
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;

            switch (Reslist.ResBelong)
            {
                case 0:
                    jsondata.data = Bll.MyResourceBll.GetMyResourceAll(Reslist, UserID);
                    break;
                case 1:
                    jsondata.data = Bll.MyResourceBll.GetMyResourceFavorite(Reslist, UserID);
                    break;
                case 2:
                    jsondata.data = Bll.MyResourceBll.GetMyResourceUp(Reslist, UserID);
                    break;
            }

            return Json(jsondata);

        }
    }
}