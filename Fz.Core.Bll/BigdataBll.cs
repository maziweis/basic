using Fz.Common;
using Fz.Core.VModel.BigData;
using FzDatabase.Bigdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.Bll
{
    public class BigdataBll
    {
        /// <summary>
        /// 写监控
        /// </summary>
        /// <param name="m"></param>
        public static void SyLogMonitorWeb_Add(SyLogMonitorAdd m)
        {
            Task excetion = SyLogMonitor_Add(m, 1);          
        }

        /// <summary>
        /// 写监控
        /// </summary>
        /// <param name="m"></param>
        public static void SyLogMonitorApi_Add(SyLogMonitorAdd m)
        {
            Task excetion = SyLogMonitor_Add(m, 2);
        }

        /// <summary>
        /// 写监控
        /// </summary>
        /// <param name="m"></param>
        /// <param name="dtype"></param>
        private static async Task SyLogMonitor_Add(SyLogMonitorAdd m, int dtype)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var db = new fz_bigdataEntities())
                    {
                        db.log_operation.Add(new log_operation
                        {
                            Id = Guid.NewGuid().ToString(),
                            Type = dtype,
                            ControllerName = m.ControllerName,
                            ActionName = m.ActionName,
                            HttpMethod = m.HttpMethod,
                            Url = m.Url,
                            ResponseTime = m.ResponseTime,
                            RenderTime = m.RenderTime,
                            TotalTime = m.ResponseTime + m.RenderTime,
                            CreateIp = m.CreateIp,
                            CreateUserId = m.CreateUserId,
                            CreateUserName = m.CreateUserName,
                            CreateAccount = m.CreateAccount,
                            CreateTime = DateTime.Now
                        });

                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    LogHelper.WriteLog(string.Format("{0}", DateTime.Now), e);
                }
            });                
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="w_totalTime"></param>
        /// <returns></returns>
        public static List<SyLogMonitorList> SyLogMonitor_GetList(int pageIndex, int pageSize, out int total, decimal? w_totalTime, string controller)
        {
            total = 0;
            using (var db = new fz_bigdataEntities())
            {
                IQueryable<log_operation> dbList = db.log_operation.OrderByDescending(o => o.CreateTime).AsQueryable();
                if (!string.IsNullOrWhiteSpace(controller))
                {
                    dbList = dbList.Where(w => w.ControllerName == controller);
                }
                if (w_totalTime != null)
                {
                    dbList = dbList.Where(w => w.TotalTime > w_totalTime);
                }
                total = dbList.Count();
                return dbList.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(s => new SyLogMonitorList
                {
                    Id = s.Id,
                    DType = s.Type,
                    ControllerName = s.ControllerName,
                    ActionName = s.ActionName,
                    HttpMethod = s.HttpMethod,
                    Url = s.Url,
                    ResponseTime = s.ResponseTime,
                    RenderTime = s.RenderTime,
                    TotalTime = s.TotalTime,
                    CreateIp = s.CreateIp,
                    CreateTime = s.CreateTime,
                    CreateUserId = s.CreateUserId,
                    CreateUserName = s.CreateUserName,
                    CreateAccount = s.CreateAccount
                }).ToList();
            }
        }

        /// <summary>
        /// 获取操作日志列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static List<SyLogMonitorList> SyLogOper_GetList(int pageIndex, int pageSize, out int total, string account)
        {
            total = 0;
            using (var db = new fz_bigdataEntities())
            {
                IQueryable<log_operation> dbList = db.log_operation.OrderByDescending(o => o.CreateTime).AsQueryable();
                if (!string.IsNullOrWhiteSpace(account))
                {
                    dbList = dbList.Where(w => w.CreateAccount.Contains(account));
                }
                total = dbList.Count();
                return dbList.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(s => new SyLogMonitorList
                {
                    Id = s.Id,
                    DType = s.Type,
                    ControllerName = s.ControllerName,
                    ActionName = s.ActionName,
                    HttpMethod = s.HttpMethod,
                    Url = s.Url,
                    ResponseTime = s.ResponseTime,
                    RenderTime = s.RenderTime,
                    TotalTime = s.TotalTime,
                    CreateIp = s.CreateIp,
                    CreateTime = s.CreateTime,
                    CreateUserId = s.CreateUserId,
                    CreateUserName = s.CreateUserName,
                    CreateAccount = s.CreateAccount
                }).ToList();
            }
        }

        /// <summary>
        /// 写异常
        /// </summary>
        /// <param name="m"></param>
        public static void SyLogErrorWeb_Add(SyLogErrorAdd m)
        {
            Task excetion = SyLogError_Add(m, 1);
        }

        /// <summary>
        /// 写异常
        /// </summary>
        /// <param name="m"></param>
        public static void SyLogErrorApi_Add(SyLogErrorAdd m)
        {
            Task excetion = SyLogError_Add(m, 2);          
        }

        /// <summary>
        /// 写异常
        /// </summary>
        /// <param name="m"></param>
        /// <param name="dtype"></param>
        private static async Task SyLogError_Add(SyLogErrorAdd m, int dtype)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var db = new fz_bigdataEntities())
                    {
                        db.log_error.Add(new log_error
                        {
                            Id = Guid.NewGuid().ToString(),
                            Type = dtype,
                            ControllerName = m.ControllerName,
                            ActionName = m.ActionName,
                            HttpMethod = m.HttpMethod,
                            Url = m.Url,
                            Message = m.Message,
                            CreateIp = m.CreateIp,
                            CreateUserId = m.CreateUserId,
                            CreateUserName = m.CreateUserName,
                            CreateAccount = m.CreateAccount,
                            CreateTime = DateTime.Now
                        });

                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    LogHelper.WriteLog(string.Format("{0}", DateTime.Now), e);
                }
            });                       
        }

        /// <summary>
        /// 获取Error数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static List<SyLogErrorList> SyLogError_GetList(int pageIndex, int pageSize, out int total, string controller)
        {
            total = 0;
            using (var db = new fz_bigdataEntities())
            {
                IQueryable<log_error> dbList = db.log_error.OrderByDescending(o => o.CreateTime);
                if (!string.IsNullOrWhiteSpace(controller))
                {
                    dbList = dbList.Where(w => w.ControllerName == controller);
                }
                total = dbList.Count();
                return dbList.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(s => new SyLogErrorList
                {
                    Id = s.Id,
                    DType = s.Type,
                    ControllerName = s.ControllerName,
                    ActionName = s.ActionName,
                    HttpMethod = s.HttpMethod,
                    Url = s.Url,
                    Message = s.Message,
                    CreateIp = s.CreateIp,
                    CreateTime = s.CreateTime,
                    CreateUserId = s.CreateUserId,
                    CreateUserName = s.CreateUserName,
                    CreateAccount = s.CreateAccount
                }).ToList();
            }
        }       
        /// <summary>
        /// 获取智慧校园操作日志
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        public static List<RoomLogList> ClrLogMonitorWeb_GetList(int pageIndex, int pageSize, out int total, DateTime? sdate, DateTime? edate)
        {
            total = 0;
            DateTime _sdate = DateTime.Parse("1900-01-01");
            DateTime _edate = DateTime.Parse("1900-01-01");
            if (sdate != null)
            {
                _sdate = ((DateTime)sdate).Date;
            }
            if (edate != null)
            {
                _edate = ((DateTime)edate).Date;
            }
            using (var db = new fz_bigdataEntities())
            {
                IQueryable<data_room_log_operation> dbList = db.data_room_log_operation.OrderByDescending(o => o.CreateTime);
                if (sdate != null)
                {
                    dbList = dbList.Where(w => System.Data.Entity.DbFunctions.TruncateTime(w.CreateTime) >= _sdate);
                }
                if (edate != null)
                {
                    dbList = dbList.Where(w => System.Data.Entity.DbFunctions.TruncateTime(w.CreateTime) <= _edate);
                }
                total = dbList.Count();
                return dbList.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(s => new RoomLogList
                {
                    Id = s.Id,
                    CreateTime = s.CreateTime,
                    CreateUserId = s.CreateUserId,
                    CreateUserType = s.CreateUserType,
                    OperId = s.OperId,
                    OperContent = s.OperContent
                }).ToList();
            }
        }

        /// <summary>
        /// 获取智慧校园操作日志
        /// </summary>
        /// <param name="sdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        public static List<RoomLogList> ClrLogMonitorWeb_GetListAll(DateTime? sdate, DateTime? edate)
        {
            DateTime _sdate = DateTime.Parse("1900-01-01");
            DateTime _edate = DateTime.Parse("1900-01-01");
            if (sdate != null)
            {
                _sdate = ((DateTime)sdate).Date;
            }
            if (edate != null)
            {
                _edate = ((DateTime)edate).Date;
            }
            using (var db = new fz_bigdataEntities())
            {
                IQueryable<data_room_log_operation> dbList = db.data_room_log_operation.OrderByDescending(o => o.CreateTime);
                if (sdate != null)
                {
                    dbList = dbList.Where(w => System.Data.Entity.DbFunctions.TruncateTime(w.CreateTime) >= _sdate);
                }
                if (edate != null)
                {
                    dbList = dbList.Where(w => System.Data.Entity.DbFunctions.TruncateTime(w.CreateTime) <= _edate);
                }
                return dbList.Select(s => new RoomLogList
                {
                    Id = s.Id,
                    CreateTime = s.CreateTime,
                    CreateUserId = s.CreateUserId,
                    CreateUserType = s.CreateUserType,
                    OperId = s.OperId,
                    OperContent = s.OperContent
                }).ToList();
            }
        }
    }
}
