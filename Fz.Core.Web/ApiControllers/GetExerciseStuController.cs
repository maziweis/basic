using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fz.Room.VModel;
using FzDatabase.Room;
namespace Fz.Core.Web.ApiControllers
{
    public class GetExerciseStuController : ApiController
    {
        /// <summary>
        /// 学生获取（课堂练习）自然拼读
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<Exercises> Get(string UserID,int SubjectID)
        {
            string tid = "";
            int? grade = null;
            using (var db1 = new FzDatabase.Basic.fz_basicEntities())
            {
                var stu = db1.sy_student.Where(w => w.UserId == UserID).FirstOrDefault();
                grade = stu.sy_grade.SGradeId;
                tid = db1.sy_teacher_and_class_and_subject.Where(w => w.ClassId == stu.Class && w.Subject == SubjectID).Select(s => s.sy_teacher.UserId).FirstOrDefault();
            }
            using (var db = new fz_wisdomcampusEntities())
            {
                return db.clr_exercises.Where(w => w.UserID == tid.Trim()).Select(s => new Exercises
                {
                    Resources = s.Resources
                }).ToList();
            }
        }
    }
}
