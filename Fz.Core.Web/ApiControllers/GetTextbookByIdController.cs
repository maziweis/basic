using Fz.Core.VModelAPI;
using FzDatabase.Basic;
using FzDatabase.ModMetaBreach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class GetTextbookByIdController : ApiController
    {

        // GET api/<controller>/5
        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public C_Textbook Get(int id)
        {
            using (var db = new MODMetaDatabaseBranchEntities())
            {
                tb_StandardBook s = db.tb_StandardBook.Find(id);

                return new C_Textbook
                {
                    Id = s.ID,
                    BookName = s.BooKName,
                    Stage = s.Stage,
                    Subject = s.Subject,
                    Grade = s.Grade,
                    Edition = s.Edition,
                    Booklet = s.Booklet
                };
            }
        }
    }
}