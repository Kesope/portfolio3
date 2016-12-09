using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.JsonModels
{
    public class ModelFactory
    {
        public static SearchResultModel SearchMap(SearchResult searchresult)
        {

            return new SearchResultModel
            {
                id = searchresult.id,
                title = searchresult.title,
                body = searchresult.body
            };
        }


        public static SearchResult SearchMap(SearchResultModel model)
        {

            return new SearchResult
            {
                id = model.id,
                title = model.title,
                body = model.body
            };
        }

        //Comment
        public static CommentModel cMap(Comment comment, IUrlHelper url)
        {
            
            return new CommentModel
            {
                Url = url.Link(Config.CommentRoute, new { id = comment.id}),
                score = comment.score,
                id = comment.id,
                text = comment.text,
                createdate = comment.createdate
            };
        }

        public static Comment cMap(CommentModel model)
        {
            
            return new Comment
            {
                score = model.score,
                id = model.id,
                text = model.text,
                createdate = model.createdate
            };
        }

        //Post
        public static PostModel pMap(Post post, IUrlHelper url)
        {
           
            return new PostModel
            {
                Url = url.Link(Config.PostRoute, new { id = post.id }),
                score = post.score,
                id = post.id,
                title = post.title,
                body = post.body,
                creationdate = post.creationdate
            };
        }

        public static Post pMap(PostModel model)
        {
           
            return new Post
            {
                score = model.score,
                id = model.id,
                body = model.body,
                creationdate = model.creationdate
            };
        }

        //User
        public static UserModel uMap(User user, IUrlHelper url)
        {

            return new UserModel
            {
                Url = url.Link(Config.UserRoute, new { id = user.id }),
                displayname = user.displayname,
                creationdate = user.creationdate,
                location = user.location,
                userage = user.userage
            };
        }

        public static User uMap(UserModel model)
        {

            return new User
            {
                displayname = model.displayname,
                creationdate = model.creationdate,
                location = model.location,
                userage = model.userage
            };
        }

        //Post_tag
        public static Post_tagModel ptMap(Post_tag pt, IUrlHelper url)
        {

            return new Post_tagModel
            {
                Url = url.Link(Config.Post_tagRoute, new { id = pt.id }),
                id = pt.id,
                postid = pt.postid,
                tagkeyword = pt.tagkeyword
            };
        }

        public static Post_tag ptMap(Post_tagModel model)
        {

            return new Post_tag
            {
                id = model.id,
                postid = model.postid,
                tagkeyword = model.tagkeyword
            };
        }

        //Linkpost
        public static LinkpostModel lpMap(Linkpost lp, IUrlHelper url)
        {

            return new LinkpostModel
            {
                Url = url.Link(Config.LinkpostRoute, new { id = lp.postid }),
                linkpostid = lp.linkpostid
            };
        }

        public static Linkpost lpMap(LinkpostModel model)
        {

            return new Linkpost
            {
                linkpostid = model.linkpostid
            };
        }

        //Tags
        public static TagsModel tMap(Tags t, IUrlHelper url)
        {

            return new TagsModel
            {
                Url = url.Link(Config.TagRoute, new { id = t.id }),
                id = t.id,
                tagkeyword = t.tagkeyword
            };
        }

        public static Tags tMap(TagsModel model)
        {

            return new Tags
            {
                id = model.id,
                tagkeyword = model.tagkeyword
            };
        }
    }
}
