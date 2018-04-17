using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyLogBugController : Controller
    {
        public ActionResult Index(VModel.SyLogBug.Index m)
        {
            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyLogBug.Grid>();
                m.Grid.Pager = new Common.Model.Pager();
            }
            int total = 0;
            List<SyLogErrorList> list = BigdataBll.SyLogError_GetList(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, out total, m.ControllerName);
            m.Grid.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, total);
            m.Grid.Data = new List<VModel.SyLogBug.Grid>();
            foreach (SyLogErrorList log in list)
            {
                m.Grid.Data.Add(new VModel.SyLogBug.Grid
                {
                    Id = log.Id,
                    DType = Common.Dict.ActionType.GetVal(log.DType),
                    ControllerName = log.ControllerName,
                    ActionName = log.ActionName,
                    HttpMethod = log.HttpMethod,
                    Url = log.Url,
                    Message = log.Message,
                    CreateIp = log.CreateIp,
                    CreateTime = log.CreateTime,
                    CreateUserName = log.CreateUserName,
                    ActionPurpose = ""
                });
            }
            return View(m);
        }
    }
}