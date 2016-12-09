using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootstrapKnockout.DomainModel;

namespace BootstrapKnockout.Services
{
    public interface testIDataService
    {
        IList<testComment> GetDummyComments();
        testComment GetDummyComment(int id);
        IList<testPost> GetDummyPosts();
        testPost GetDummyPost(int id);
    }
}
