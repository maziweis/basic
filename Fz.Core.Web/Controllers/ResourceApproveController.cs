using Fz.Core.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Resource.Web.Controllers
{
    public class ResourceApproveController : BaseController
    {
        // GET: ResourceApprove
        public ActionResult Index(VModel.ResourceApprove.Form formList, int? id)
        {
            string UserID = GetUserId();

            if (id == null)
            {
                ViewBag.PageTypeId = formList.SubjectID;
            }
            else
            {
                ViewBag.PageTypeId = id;//左侧菜单选中用
            }
            if (formList.SubjectID == null)
            {
                formList.SubjectID = id;
            }

           if (formList.GridList == null)
            {
                formList.GridList = new Common.Model.PList<VModel.ResourceApprove.Grid>();
                formList.GridList.Pager = new Common.Model.Pager();
            }
            formList.GridList = Bll.ResourceApproveBll.GetApproveResource(formList);          
            return View(formList);
        }
        /// <summary>
        /// 资源审批通过
        /// </summary>
        /// <returns></returns>
        public JsonResult ResApproveAgree(string Resids)
        {
            string UserID = GetUserId();
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.ResourceApproveBll.ResApproveAgree(Resids, UserID);
            return Json(jsondata);

        }
        /// <summary>
        /// 资源审批通过
        /// </summary>
        /// <returns></returns>
        public JsonResult ResApproveDisAgree(string Resids)
        {
            string UserID = GetUserId();
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.ResourceApproveBll.ResApproveDisAgree(Resids, UserID);
            return Json(jsondata);

        }
    }
}