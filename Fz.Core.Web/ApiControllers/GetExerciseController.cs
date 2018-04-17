using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FzDatabase.Basic;
using Fz.Room.VModel;
using FzDatabase.Room;

namespace Fz.Core.Web.ApiControllers
{
    public class GetExerciseController : ApiController
    {        
        /// <summary>
        /// 老师获取（课堂练习）自然拼读
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Exercises Get(string id)
          {
            using (var db = new fz_wisdomcampusEntities())
            {
                return db.clr_exercises.Where(w => w.UserID== id).Select(s => new Exercises
                {
                    Resources = s.Resources
                }).FirstOrDefault();
            }
        }
    }
}
