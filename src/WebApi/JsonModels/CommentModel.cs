using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class CommentModel
    {
        public string Url { get; set; }
        public int id { get; set; }
        public int postid { get; set; }
        public int score { get; set; }
        public string text { get; set; }
        public DateTime createdate { get; set; }
        public int userid { get; set; }
    }
}
