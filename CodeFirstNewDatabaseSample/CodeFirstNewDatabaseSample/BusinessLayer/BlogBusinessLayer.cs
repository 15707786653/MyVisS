using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.DataAccessLayer;
//using System.Data.Entity;

namespace CodeFirstNewDatabaseSample.BusinessLayer
{
    public class BlogBusinessLayer
    {
        public void Add(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);

                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }
        public List<Post> QueryPosts()
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.ToList();
            }
        }
        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void AddPost(Post post)
        {
            using (var db=new BloggingContext())
            {

                db.Entry(post).State = System.Data.Entity.EntityState.Unchanged;
                db.SaveChanges();
            }
        }
        public void cratepost(Post post)
        {
            using(var db =new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }
        public void deletepost(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public List<Post> Querysds(string name)
        {
            using (var db = new BloggingContext())
            {
                var posts = from b in db.Posts
                            where b.Title.Contains(name)
                            select b;
                return posts.ToList();
            }
        }
    }
}

