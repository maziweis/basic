using Fz.Core.Bll;
using Fz.Core.VModel.BigData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web.Controllers
{
    public class SyLogPerfController : Controller
    {
        public ActionResult Index(VModel.SyLogPerf.Index m)
        {
            Dictionary<double, string> dict = new Dictionary<double, string>();
            dict.Add(1, "综合时间大于1秒");
            dict.Add(2, "综合时间大于2秒");
            dict.Add(3, "综合时间大于3秒");
            dict.Add(4, "综合时间大于4秒");
            dict.Add(5, "综合时间大于5秒");

            m.TotalTimes = dict;

            if (m.Grid == null)
            {
                m.Grid = new Common.Model.PList<VModel.SyLogPerf.Grid>();
                m.Grid.Pager = new Common.Model.Pager();
            }
            int total = 0;
            List<SyLogMonitorList> list = BigdataBll.SyLogMonitor_GetList(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, out total, Convert.ToDecimal(m.TotalTime), m.ControllerName);
            m.Grid.Pager = new Common.Model.Pager(m.Grid.Pager.PageIndex, m.Grid.Pager.PageSize, total);
            m.Grid.Data = new List<VModel.SyLogPerf.Grid>();
            foreach (SyLogMonitorList log in list)
            {
                m.Grid.Data.Add(new VModel.SyLogPerf.Grid
                {
                    Id = log.Id,
                    ActionType = Common.Dict.ActionType.GetVal(log.DType),
                    ControllerName = log.ControllerName,
                    ActionName = log.ActionName,
                    HttpMethod = log.HttpMethod,
                    Url = log.Url,
                    CreateIp = log.CreateIp,
                    CreateTime = log.CreateTime,
                    CreateUserName = log.CreateUserName,
                    ResponseTime = log.ResponseTime,
                    RenderTime = log.RenderTime,
                    TotalTime = log.TotalTime
                });
            }
            return View(m);
        }

    }
}
