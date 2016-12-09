using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace DatabaseService
{
    public class MySovaDataService : IDataService
    {
        
        public IList<SearchResult> EFShowSearchResult(string searchstring)
        {
            using (var db = new Sova())
            {
                //var conn = (MySqlConnection)db.Database.GetDbConnection();
                //conn.Open();
                //var cmd = new MySqlCommand("call weightingsearch(@searchstring)", conn);
                //cmd.Parameters.Add("@searchstring", DbType.String).Value = searchstring;
                //var reader = cmd.ExecuteReader();
                //var result = new List<SearchResult>();
                //while(reader.HasRows && reader.Read())
                //{
                //    result.Add(new SearchResult
                //    {
                //        id = reader.GetInt32(0),
                //        Title = reader.GetString(2),
                //        body = reader.GetString(3)
                //    });
                //}
                //return result;
                var result = db.Set<SearchResult>()
                    .FromSql("call weightingsearch('" + searchstring + "')");
                foreach (var data in result)
                {
                    Console.WriteLine($"{data.id} {data.title} {data.body}");
                }
                return result.ToList();
            }
        }

        public void EFMarkThisPost(int postid, string searchstring)
        {
            using (var db = new Sova())
            {
                var conn = (MySqlConnection)db.Database.GetDbConnection();
                conn.Open();
                var cmd = new MySqlCommand("call markthispost(@1,@2)", conn);
                cmd.Parameters.Add("@1", DbType.Int64).Value = postid;
                cmd.Parameters.Add("@2", DbType.String).Value = searchstring;
                Console.WriteLine($"Marked");

            }
        }

        //Post
        public IList<Post> GetPosts(int page, int pagesize)
        {

            using (var db = new Sova())
            {
                return db.Posts
                    .OrderBy(p => p.id)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Post GetPost(int id)
        {
            using (var db = new Sova())
            {
                return db.Posts.FirstOrDefault(p => p.id == id);
            }
        }

        public void AddPost(Post post)
        {
            using (var db = new Sova())
            {
                post.id = db.Posts.Max(p => p.id) + 1;
                db.Add(post);
                db.SaveChanges();
            }
        }

        public bool UpdatePost(Post post)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(post);
                    db.Entry(post).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeletePost(int id)
        {
            using (var db = new Sova())
            {
                var post = db.Posts.FirstOrDefault(p => p.id == id);
                if (post == null)
                {
                    return false;
                }
                db.Remove(post);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfPosts()
        {
            using (var db = new Sova())
            {
                return db.Posts.Count();
            }
        }

        //Comments
        public IList<Comment> GetComments(int page, int pagesize)
        {
            using (var db = new Sova())
            {
                return db.Comments
                    .OrderBy(c => c.id)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Comment GetComment(int id)
        {
            using (var db = new Sova())
            {
                return db.Comments.FirstOrDefault(c => c.id == id);
            }
        }

        public void AddComment(Comment comment)
        {
            using (var db = new Sova())
            {
                comment.id = db.Comments.Max(c => c.id) + 1;
                db.Add(comment);
                db.SaveChanges();
            }
        }

        public bool UpdateComment(Comment comment)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(comment);
                    db.Entry(comment).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeleteComment(int id)
        {
            using (var db = new Sova())
            {
                var comment = db.Comments.FirstOrDefault(c => c.id == id);
                if (comment == null)
                {
                    return false;
                }
                db.Remove(comment);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfComments()
        {
            using (var db = new Sova())
            {
                return db.Comments.Count();
            }
        }

        //User

        public IList<User> GetUser(int page, int pagesize)
        {
            using (var db = new Sova())
            {
                return db.User
                    .OrderBy(u => u.id)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public User GetUser(int id)
        {
            using (var db = new Sova())
            {
                return db.User.FirstOrDefault(c => c.id == id);
            }
        }

        public void AddUser(User user)
        {
            using (var db = new Sova())
            {
                user.id = db.User.Max(u => u.id) + 1;
                db.Add(user);
                db.SaveChanges();
            }
        }

        public bool UpdateUser(User user)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(user);
                    db.Entry(user).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeleteUser(int id)
        {
            using (var db = new Sova())
            {
                var user = db.User.FirstOrDefault(u => u.id == id);
                if (user == null)
                {
                    return false;
                }
                db.Remove(user);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfUser()
        {
            using (var db = new Sova())
            {
                return db.User.Count();
            }
        }

        //Linkpost
        public IList<Linkpost> GetLinkpost(int page, int pagesize)
        {
            using (var db = new Sova())
            {
                return db.Linkpost
                    .OrderBy(lp => lp.linkpostid)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Linkpost GetLinkpost(int id)
        {
            using (var db = new Sova())
            {
                return db.Linkpost.FirstOrDefault(lp => lp.linkpostid == id);
            }
        }

        public void AddLinkpost(Linkpost linkpost)
        {
            using (var db = new Sova())
            {
                linkpost.linkpostid = db.Linkpost.Max(lp => lp.linkpostid) + 1;
                db.Add(linkpost);
                db.SaveChanges();
            }
        }

        public bool UpdateLinkpost(Linkpost linkpost)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(linkpost);
                    db.Entry(linkpost).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeleteLinkpost(int id)
        {
            using (var db = new Sova())
            {
                var linkpost = db.Linkpost.FirstOrDefault(lp => lp.linkpostid == id);
                if (linkpost == null)
                {
                    return false;
                }
                db.Remove(linkpost);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfLinkpost()
        {
            using (var db = new Sova())
            {
                return db.Linkpost.Count();
            }
        }

        //Post_tag
        public IList<Post_tag> GetPost_tag(int page, int pagesize)
        {
            using (var db = new Sova())
            {
                return db.Post_tag
                    .OrderBy(pt => pt.id)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Post_tag GetPost_tag(int id)
        {
            using (var db = new Sova())
            {
                return db.Post_tag.FirstOrDefault(pt => pt.id == id);
            }
        }

        public void AddPost_tag(Post_tag pt)
        {
            using (var db = new Sova())
            {
                pt.postid = db.Post_tag.Max(p => pt.id) + 1;
                db.Add(pt);
                db.SaveChanges();
            }
        }

        public bool UpdatePost_tag(Post_tag post_tag)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(post_tag);
                    db.Entry(post_tag).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeletePost_tag(int id)
        {
            using (var db = new Sova())
            {
                var post_tag = db.Post_tag.FirstOrDefault(pt => pt.id == id);
                if (post_tag == null)
                {
                    return false;
                }
                db.Remove(post_tag);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfPost_tag()
        {
            using (var db = new Sova())
            {
                return db.Post_tag.Count();
            }
        }

        //Tags

        public IList<Tags> GetTags(int page, int pagesize)
        {
            using (var db = new Sova())
            {
                return db.Tags
                    .OrderBy(ta => ta.id)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Tags GetTags(int id)
        {
            using (var db = new Sova())
            {
                return db.Tags.FirstOrDefault(ta => ta.id == id);
            }
        }

        public void AddTags(Tags tags)
        {
            using (var db = new Sova())
            {
                tags.id = db.Tags.Max(ta => ta.id) + 1;
                db.Add(tags);
                db.SaveChanges();
            }
        }

        public bool UpdateTags(Tags tags)
        {
            using (var db = new Sova())

                try
                {
                    db.Attach(tags);
                    db.Entry(tags).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeleteTags(int id)
        {
            using (var db = new Sova())
            {
                var tags = db.Tags.FirstOrDefault(ta => ta.id == id);
                if (tags == null)
                {
                    return false;
                }
                db.Remove(tags);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfTags()
        {
            using (var db = new Sova())
            {
                return db.Tags.Count();
            }
        }
    }
}
