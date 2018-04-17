using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fz.Core.VModelAPI
{
    public class StandBook
    {
        public int ID { get; set; }
        public int? Stage { get; set; }
        public int? Subject { get; set; }
        public int? Grade { get; set; }
        public int? Booklet { get; set; }
        public int? Edition { get; set; }
        public string BooKName { get; set; }
    }
}
