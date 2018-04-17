using Fz.Core.Web.Controllers;
using Fz.Resource.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Resource.Web.Controllers
{
    public class ResourcePreviewController : BaseController
    {
        public ActionResult Index(string id)
        {
            VModel.ResourcePreview.Form m = Bll.ResourcePreviewBll.GetInfo(id);
            if (m != null)
            {
                ResourcePreviewBll.AddPreViewRecord(m.ResourceID);
                m.FileType = Common.Dict.FileType.GetVal(m.FileExtension.ToLower());
                if (string.IsNullOrEmpty(m.FileType))
                {
                    m.FileType = "default";
                }
                ViewBag.LocalUrl = string.Format("{0}/KingsunFiles/{1}/{2}.{3}", GetFileServer(), GetFilePath(m.FilePath), m.FileID, m.FileExtension);
                ViewBag.Url = string.Format("{0}/KingsunFiles/{1}/{2}.{3}", GetFileServerHttp(), GetFilePath(m.FilePath), m.FileID, m.FileExtension);
            }
            return View(m);
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
    }
}