using Fz.Common;
using System.Web;
using System.Web.Http;
namespace Fz.Resource.Web.ApiControllers
{
 
    public class UploadController : ApiController
    {
        [System.Web.Http.HttpPost]
        public KingResponse Post()
        {
            string PrePath = System.Configuration.ConfigurationManager.AppSettings["FileAddress"]+ "/KingsunFiles/";        
            KingResponse response;      
            try
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;
                HttpPostedFile file = files[files.AllKeys[0]];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    response = Bll.FileUploadBll.UploadFile(file, PrePath);
                }
                else
                {
                    response = KingResponse.GetErrorResponse("没有选择文件！");
                }

            }
            catch
            {
                response = KingResponse.GetErrorResponse("处理过程中出现错误！");
                return response;
            }
            return response;
        }
    }
}