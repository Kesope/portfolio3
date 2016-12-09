using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class Post_tagModel
    {
        public string Url { get; set; }
        public int id { get; set; }
        public int ?postid { get; set; }
        public string tagkeyword { get; set; }
    }
}
