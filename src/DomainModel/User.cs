using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User
    {
        public int id { get; set; }
        public string displayname { get; set; }
        public DateTime? creationdate { get; set; }
        public string location { get; set; }
        public int? userage { get; set; }
    }
}
