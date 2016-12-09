using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class PostModel
    {
        public string Url { get; set; }
        public int id { get; set; }
        public int typeid { get; set; }
        public int? parentid { get; set; }
        public int? acceptedanswerid { get; set; }
        public DateTime? creationdate { get; set; }
        public int score { get; set; }
        public string body { get; set; }
        public DateTime? closeddate { get; set; }
        public string title { get; set; }
        public int userid { get; set; }

    }
}
