using System.Web;
using System.Web.Mvc;

namespace Fz.Core.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthAttribute());
            filters.Add(new MonitorAttribute());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ErrAttribute());
        }
    }
}
