using Fz.Core.VModelAPI;
using Fz.Core.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Resource.Web.Controllers
{
    public class ResourceSearchController : BaseController
    {
        // GET: ResourceSearch
        public ActionResult Index(VModel.SearchResource.Form Reslist, int? id)
        {
            if(id == null)
            {
                ViewBag.PageTypeId = Reslist.SubjectID;
            }
            else
            {
                ViewBag.PageTypeId = id;//左侧菜单选中用
            }        
            string UserID = GetUserId();
            if (Reslist.SubjectID == null)
            {
                Reslist.SubjectID = id;
            }     
            if(Reslist.OrderBy == null)
            {
                Reslist.OrderBy = 1;
            }      
            if (Reslist.GridList == null)
            {
                Reslist.GridList = new Common.Model.PList<VModel.SearchResource.Grid>();
                Reslist.GridList.Pager = new Common.Model.Pager();
            }
            ////////////没有版本设置默认版本
           // ViewBag.Editions = Bll.ResourceUploadBll.GetSelectEditionsBySubjectId((int)Reslist.SubjectID);
            //if (Reslist.EditionID == null)
            //{               
            //    if (ViewBag.Editions != null && ((Dictionary<int, string>)ViewBag.Editions).Count > 0)
            //    {
            //        Reslist.EditionID = ((Dictionary<int, string>)ViewBag.Editions).ToList()[0].Key;
            //    }
            //}
            ////////////没有年级设置默认年级
           // ViewBag.Grades = Bll.ResourceUploadBll.GetSelectAllGradeID((int)Reslist.SubjectID);
            //if (Reslist.GradeID == null)
            //{
            //    if (ViewBag.Grades != null && ((List<VModel.Common.CommonModel<int>>)ViewBag.Grades).Count > 0)
            //    {
            //        Reslist.GradeID = ((List<VModel.Common.CommonModel<int>>)ViewBag.Grades)[0].ID;
            //    }
            //}
            Reslist.GridList = Bll.SearchResourceBll.GetLocalSchoolResource(Reslist);
            ViewBag.MyResource = Bll.SearchResourceBll.GetMyResource(UserID);
            ViewBag.UserID = UserID;
            return View(Reslist);
        }
        public ActionResult GetSchoolResource(VModel.SearchResource.Form Res)
        {
            if (Res.GridList == null)
            {
                Res.GridList = new Common.Model.PList<VModel.SearchResource.Grid>();
                Res.GridList.Pager = new Common.Model.Pager();
            }
            Res.GridList = Bll.SearchResourceBll.GetLocalSchoolResource(Res);
            return View(Res);

        }
        /// <summary>
        /// 根据学科取得版本
        /// </summary>
        /// <param name="SubjectId"></param>
        /// <returns></returns>
        public JsonResult GetSelectEditionID(int SubjectId)
        {
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            List<VModel.Common.CommonModel<int>> EditionList = new List<VModel.Common.CommonModel<int>>();
            Dictionary<int, string> editions = Bll.ResourceUploadBll.GetSelectEditionsBySubjectId(SubjectId);
            foreach (var key in editions.Keys)
            {
                VModel.Common.CommonModel<int> EditionMode = new VModel.Common.CommonModel<int>();
                EditionMode.ID = key;
                EditionMode.CodeName = editions[key];
                EditionList.Add(EditionMode);
            }
            jsondata.data = EditionList;
            return Json(jsondata);
        }
        /// <summary>
        /// 获取所有学科
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSelectAllGradeID(int Subject) {
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            List<VModel.Common.CommonModel<int>> EditionList = new List<VModel.Common.CommonModel<int>>();
            Dictionary<int, string> editions = Bll.ResourceUploadBll.GetSelectAllGradeID(Subject);
            foreach (var key in editions.Keys)
            {
                VModel.Common.CommonModel<int> EditionMode = new VModel.Common.CommonModel<int>();
                EditionMode.ID = key;
                EditionMode.CodeName = editions[key];
                EditionList.Add(EditionMode);
            }
            jsondata.data = EditionList;
            return Json(jsondata);
        }
        /// <summary>
        /// 资源收藏
        /// </summary>
        /// <returns></returns>
        public JsonResult ResourceCollect(string Resids)
        {
            string UserID = GetUserId();
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.SearchResourceBll.ResourceCollect(Resids, UserID);
            return Json(jsondata);
        }
        /// <summary>
        /// 取消收藏操作
        /// </summary>
        /// <param name="ResId"></param>
        /// <returns></returns>
        public JsonResult ResourceCancelCollect(string ResId)
        {
            string UserID = GetUserId();
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.SearchResourceBll.ResourceCancelCollect(ResId, UserID);
            return Json(jsondata);
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
        /// 获取教材
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public JsonResult GetSelectBookID(int? subjectId, int? gradeId, int? editionId)
        {
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            Dictionary<int, C_TextbookCatalog[]> dirBook = Bll.SearchResourceBll.GetSelectBookID(subjectId, gradeId, editionId);
            List<VModel.Common.CommonBook<C_TextbookCatalog[]>> BookList = new List<VModel.Common.CommonBook<C_TextbookCatalog[]>>();
            foreach (int key in dirBook.Keys)
            {
                VModel.Common.CommonBook<C_TextbookCatalog[]> catalog = new VModel.Common.CommonBook<C_TextbookCatalog[]>();
                catalog.ID = key;
                catalog.Book = dirBook[key];
                BookList.Add(catalog);
            }
            jsondata.data = BookList;
            return Json(jsondata);
        }

        public JsonResult GetSelectGradeID(int editionId)
        {
            Common.Model.JsonData jsondata = new Common.Model.JsonData();
            jsondata.flag = Common.Model.JsonDataFlag.Succeed;
            jsondata.data = Bll.SearchResourceBll.GetSelectGradeID(editionId);
            return Json(jsondata);
        }

    }
}