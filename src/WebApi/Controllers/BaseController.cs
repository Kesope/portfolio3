using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController : Controller
    {
        public IDataService DataService { get; }

        public BaseController(IDataService dataService)
        {
            DataService = dataService;
        }

        protected bool IsLastPage(int page, int pagesize, int total)
        {
            if (total - page * pagesize > 0)
            {
                return false;
            }
            return true;
        }

        protected static bool IsFirstPage(int page)
        {
            return page == 0;
        }

        //Comment
        protected string GetNextCommentUrl(IUrlHelper url, int page, int pagesize, int total)
        {
            if (IsLastPage(page, pagesize, total)) return null;
            return url.Link(Config.CommentsRoute, new { page = page + 1, pagesize });
        }
        protected string GetPrevCommentUrl(IUrlHelper url, int page, int pagesize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(Config.CommentsRoute, new { page = page - 1, pagesize });
        }

        //Post
        protected string GetNextPostUrl(IUrlHelper url, int page, int pagesize, int total)
        {
            if (IsLastPage(page, pagesize, total)) return null;
            return url.Link(Config.PostsRoute, new { page = page + 1, pagesize });
        }
        protected string GetPrevPostUrl(IUrlHelper url, int page, int pagesize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(Config.PostsRoute, new { page = page - 1, pagesize });
        }

        //User
        protected string GetNextUserUrl(IUrlHelper url, int page, int pagesize, int total)
        {
            if (IsLastPage(page, pagesize, total)) return null;
            return url.Link(Config.UsersRoute, new { page = page + 1, pagesize });
        }
        protected string GetPrevUserUrl(IUrlHelper url, int page, int pagesize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(Config.UsersRoute, new { page = page - 1, pagesize });
        }

        //Linkpost
        protected string GetNextLinkpostUrl(IUrlHelper url, int page, int pagesize, int total)
        {
            if (IsLastPage(page, pagesize, total)) return null;
            return url.Link(Config.LinkpostsRoute, new { page = page + 1, pagesize });
        }
        protected string GetPrevLinkpostUrl(IUrlHelper url, int page, int pagesize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(Config.LinkpostsRoute, new { page = page - 1, pagesize });
        }

        //Post_tag
        protected string GetNextPost_tagUrl(IUrlHelper url, int page, int pagesize, int total)
        {
            if (IsLastPage(page, pagesize, total)) return null;
            return url.Link(Config.Post_tagsRoute, new { page = page + 1, pagesize });
        }
        protected string GetPrevPost_tagUrl(IUrlHelper url, int page, int pagesize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(Config.Post_tagsRoute, new { page = page - 1, pagesize });
        }

        //Tags
        protected string GetNextTagsUrl(IUrlHelper url, int page, int pagesize, int total)
        {
            if (IsLastPage(page, pagesize, total)) return null;
            return url.Link(Config.TagsRoute, new { page = page + 1, pagesize });
        }
        protected string GetPrevTagsUrl(IUrlHelper url, int page, int pagesize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(Config.TagsRoute, new { page = page - 1, pagesize });
        }
    }
}
