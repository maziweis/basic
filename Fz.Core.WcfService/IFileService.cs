using Fz.Core.WcfService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// IFileService
    /// </summary>
    [ServiceContract]
    public interface IFileService
    {
        /// <summary>
        /// 通过文件ID获取文件
        /// </summary>
        /// <param name="FileID">文件ID</param>
        /// <returns></returns>
        [OperationContract]
        R_File GetFileByFileID(string FileID);
        /// <summary>
        /// 修改文件宽高
        /// </summary>
        /// <param name="file"></param>
        [OperationContract]
        void UpdateFileWH(R_File file);
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool UploadFileFromClassRoom(string Filedata);
          
    }
}
