using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService
{
    public class Sova : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Linkpost> Linkpost { get; set; }
        public DbSet<Post_tag> Post_tag { get; set; }
        public DbSet<Tags> Tags { get; set; }
        //public DbSet<History> History { get; set; }
        public DbSet<Markedpost> Markedpost { get; set; }
        public DbSet<SearchResult> SearchResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("post");
            modelBuilder.Entity<Post>().Property(p => p.id).HasColumnName("postid");
            modelBuilder.Entity<Post>().Property(p => p.posttypeid).HasColumnName("posttypeid");
            modelBuilder.Entity<Post>().Property(p => p.parentid).HasColumnName("parentid");
            modelBuilder.Entity<Post>().Property(p => p.acceptedanswerid).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Post>().Property(p => p.creationdate).HasColumnName("creationdate");
            modelBuilder.Entity<Post>().Property(p => p.score).HasColumnName("score");
            modelBuilder.Entity<Post>().Property(p => p.body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(p => p.closeddate).HasColumnName("closeddate");
            modelBuilder.Entity<Post>().Property(p => p.title).HasColumnName("title");
            modelBuilder.Entity<Post>().Property(p => p.userid).HasColumnName("userid");

            //Comments
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(c => c.id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(c => c.postid).HasColumnName("postid");
            modelBuilder.Entity<Comment>().Property(c => c.score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(c => c.text).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(c => c.createdate).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comment>().Property(c => c.userid).HasColumnName("userid");

            //User
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().Property(u => u.id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(u => u.displayname).HasColumnName("userdisplayname");
            modelBuilder.Entity<User>().Property(u => u.creationdate).HasColumnName("usercreationdate");
            modelBuilder.Entity<User>().Property(u => u.location).HasColumnName("userlocation");
            modelBuilder.Entity<User>().Property(u => u.userage).HasColumnName("userage");

            //Linkpost
            modelBuilder.Entity<Linkpost>().ToTable("linkpost");
            modelBuilder.Entity<Linkpost>().Property(lp => lp.linkpostid).HasColumnName("linkpostid");
            modelBuilder.Entity<Linkpost>().Property(lp => lp.postid).HasColumnName("postid");

            //Post_tag
            modelBuilder.Entity<Post_tag>().ToTable("post_tag");
            modelBuilder.Entity<Post_tag>().Property(pt => pt.id).HasColumnName("id");
            modelBuilder.Entity<Post_tag>().Property(pt => pt.postid).HasColumnName("postid");
            modelBuilder.Entity<Post_tag>().Property(pt => pt.tagkeyword).HasColumnName("tagkeyword");

           //Tags
            modelBuilder.Entity<Tags>().ToTable("tags");
            modelBuilder.Entity<Tags>().Property(t => t.id).HasColumnName("tagid");
            modelBuilder.Entity<Tags>().Property(t => t.tagkeyword).HasColumnName("tagkeyword");

            /*//History
            modelBuilder.Entity<History>().ToTable("history");
            modelBuilder.Entity<History>().Property(h => h.searchstring).HasColumnName("searchstring");

            //Markedpost
            modelBuilder.Entity<Markedpost>().ToTable("markedpost");
            modelBuilder.Entity<Markedpost>().Property(mp => mp.postid).HasColumnName("postid");
            modelBuilder.Entity<Markedpost>().Property(mp => mp.searchstring).HasColumnName("searchstring");*/

            modelBuilder.Entity<SearchResult>().HasKey(t => new { t.id, t.title, t.body });
            modelBuilder.Entity<Markedpost>().HasKey(t => new { t.postid, t.searchstring});

            base.OnModelCreating(modelBuilder);
        }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=sova;uid=root;pwd=kevin");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
