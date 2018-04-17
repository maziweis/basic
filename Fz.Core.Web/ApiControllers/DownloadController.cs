using Fz.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Fz.Resource.Web.ApiControllers
{
    /// <summary>
    /// 下载
    /// </summary>
    public class DownloadController : BaseApiController
    {
        public HttpResponseMessage Get(string id)
        {
            VModel.ResourcePreview.Form m = Bll.ResourcePreviewBll.GetInfo(id);

            string path = string.Format("{0}/KingsunFiles/{1}/{2}.{3}", GetFileServer(), GetFilePath(m.FilePath), m.FileID, m.FileExtension);

            if (!File.Exists(path))
            {
               throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var stream = new FileStream(path, FileMode.Open);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new StreamContent(stream);

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = UrlEcode.ToHexString(m.ResourceName + "." + m.FileExtension) };
            return response;
        }
    }
}
