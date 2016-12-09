using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapKnockout.DomainModel;

namespace BootstrapKnockout.Services
{
    public class testDataService : testIDataService
    {
        private List<testPost> _posts = new List<testPost>
        {
            new testPost {id = 1, title = "this is a dummy post no.1.",  body= "this is the body of posts no.1"},
            new testPost {id = 2, title = "this is a dummy post no.2.o", body= "this is the body of posts no.2"},
            new testPost {id = 3, title = "this is a dummy post no.3",   body= "this is the body of posts no.3"}
        };

        private List<testComment> _comments = new List<testComment>
        {
            new testComment {id = 1, text = "aspdfuohqwoih testing 1",score = 1},
            new testComment {id = 2, text = "aspdfuohqwoih testing 2",score =  2},
            new testComment {id = 3, text = "aspdfuohqwoih testing 3",score =  3},
            new testComment {id = 4, text = "aspdfuohqwoih testing 4",score = 4},
            new testComment {id = 5, text = "aspdfuohqwoih testing 5",score = 5}
        };

        public IList<testComment> GetDummyComments()
        {
            return _comments;
        }

        public testComment GetDummyComment(int id)
        {
            return _comments.FirstOrDefault(p => p.id == id);
        }

        public IList<testPost> GetDummyPosts()
        {
            return _posts;
        }

        public testPost GetDummyPost(int id)
        {
            return _posts.FirstOrDefault(p => p.id == id);
        }
    }
}
