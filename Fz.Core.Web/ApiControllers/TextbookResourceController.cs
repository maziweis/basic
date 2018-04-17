using FzDatabase.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fz.Core.Web.ApiControllers
{
    public class TextbookResourceController : ApiController
    {

        // GET api/<controller>/5
        /// <summary>
        /// 获取教材资源（水滴）
        /// </summary>
        /// <param name="bookId">教材id</param>
        /// <param name="pages">页码（多个）</param>
        /// <returns></returns>
        public string[] Get(int bookId, string pages)
        {
            string[] pages1 = pages.Split('_');
            List<int> pages2 = new List<int>();
            foreach (var p in pages1)
            {
                if (!string.IsNullOrWhiteSpace(p))
                {
                    pages2.Add(int.Parse(p));
                }
            }

            using (var db = new fz_basicEntities())
            {
                return db.dict_textbook_resource.Where(w => w.BookId == bookId && pages2.Contains(w.PageIndex)).Select(s => s.Content).ToArray();
            }
        }

        // POST api/<controller>
        /// <summary>
        /// 保存教材资源
        /// </summary>
        /// <param name="prebook">教材id</param> 
        public class PreBook
        {
            public string bookId { get; set; }
            public string page { get; set; }
            public string PreLessonContent { get; set; }
        }
        public void Post([FromBody]List<PreBook> prebook)
        {
            using (var db = new fz_basicEntities())
            {
                foreach(PreBook book in prebook)
                {
                    dict_textbook_resource m = db.dict_textbook_resource.Find(Int32.Parse(book.bookId), Int32.Parse(book.page));
                    if (m == null)
                    {
                        db.dict_textbook_resource.Add(new dict_textbook_resource
                        {
                            BookId = Int32.Parse(book.bookId),
                            PageIndex = Int32.Parse(book.page),
                            Content = book.PreLessonContent
                        });
                    }
                    else
                    {
                        m.Content = book.PreLessonContent;
                    }
                }               
                db.SaveChanges();
            }
        }

    }
}