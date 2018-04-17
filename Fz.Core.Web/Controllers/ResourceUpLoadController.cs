using Fz.Core.Web.Controllers;
using Fz.Resource.VModel.ResourceUpLoad;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Fz.Resource.Web.Controllers
{
    public class ResourceUpLoadController : BaseController
    {
        // GET: ResourceUpLoad
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Add() {
            string resourcelist = Request.QueryString["ResourceList"];
            Form ResForm = new Form();
            ResForm.SubjectID = 3;
            ResForm.ResGrid = Common.JsonHelper.JosnDeserializer<Grid>(Server.UrlDecode(resourcelist));
            Bll.ResourceUploadBll.SaveFile(ResForm.ResGrid);
            return View(ResForm);
        }
        [HttpPost]
        public ActionResult Add(Form formlist)
        {
            int State = 0;
            string UserID = GetUserId();
            string UserName = GetUserName();
            if (ModelState.IsValid)
            {               
                if (formlist != null && formlist.ResGrid != null && formlist.ResGrid.Count > 0)
                {
                    State = Bll.ResourceUploadBll.SaveResource(formlist.ResGrid, UserID, UserName);
                    if (State > 0)
                    {
                        return RedirectToAction("Index", "Resource", new { id = 2 ,SubjectID= formlist.ResGrid[0].SubjectID });
                    }
                    else
                    {
                        ModelState.AddModelError("Add", "上传资源失败！");
                    }
                }
            }         
            return View(formlist);
        }              
    }
}