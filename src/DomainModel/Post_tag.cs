using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Post_tag
    {
        public int id { get; set; }
        public int? postid { get; set; }
        public string tagkeyword { get; set; }
    }
}
