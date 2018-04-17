using Fz.Common;
using FzDatabase.Bigdata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class ClrLogMonitorWeb_AddController : ApiController
    {

        // POST api/<controller>
        /// <summary>
        /// 智慧教室写操作日志
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userType">用户类型</param>
        /// <param name="OperId">操作类型Id</param>
        /// <param name="content">内容</param>
        public class Operator
        {
            public string userId { get; set; }
            public int userType { get; set; }
            public int OperId { get; set; }
            public string content { get; set; }
        }
        public void Post([FromBody]Operator operatorInfo)
        {
            try
            {
                using (var db = new fz_bigdataEntities())
                {
                    data_room_log_operation roomlog = new data_room_log_operation();
                    roomlog.Id = Guid.NewGuid().ToString();
                    roomlog.CreateUserId = operatorInfo.userId;
                    roomlog.CreateUserType = operatorInfo.userType;
                    roomlog.OperId = operatorInfo.OperId;
                    roomlog.OperContent = operatorInfo.content;
                    roomlog.CreateTime = DateTime.Now;
                    db.data_room_log_operation.Add(roomlog);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                LogHelper.WriteLog(string.Format("{0}", DateTime.Now), e);
            }
        }

    }
}