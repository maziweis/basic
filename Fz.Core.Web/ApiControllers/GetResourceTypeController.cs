using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetResourceTypeController : ApiController
    {

        // GET api/<controller>/5
        /// <summary>
        ///获取资源类型
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> Get()
        {
            Dictionary<int, string> ResourceType = new Dictionary<int, string>();
            ResourceType.Add(27, "互动课件");
            ResourceType.Add(10, "课件");
            ResourceType.Add(12, "教案");
            ResourceType.Add(9, "试卷");
            ResourceType.Add(5, "音频");
            ResourceType.Add(4, "视频");
            ResourceType.Add(6, "动画");
            ResourceType.Add(28, "图片");
            ResourceType.Add(100, "其它");
            return ResourceType;
        }

    }
}