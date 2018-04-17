using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyLogOperController : Controller
    {
        public ActionResult Index(string id, VModel.SyLogOper.Index m)
        {
            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyLogOper.Grid>();
                m.Grid.Pager = new Common.Model.Pager();
            }
            int total = 0;
            List<SyLogMonitorList> list = BigdataBll.SyLogOper_GetList(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, out total, m.Key);
            m.Grid.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, total);
            m.Grid.Data = new List<VModel.SyLogOper.Grid>();
            foreach (SyLogMonitorList log in list)
            {
                m.Grid.Data.Add(new VModel.SyLogOper.Grid
                {
                    HttpMethod = log.HttpMethod,
                    ActionPurpose = Common.Dict.ActionPurpose.GetVal(log.ControllerName, log.ActionName, log.HttpMethod),
                    CreateTime = log.CreateTime,
                    CreateAccount = log.CreateAccount == null ? "未知账号" : log.CreateAccount,
                    CreateIp = log.CreateIp
                });
            }
            return View(m);
        }
    }
}
