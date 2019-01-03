using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;

namespace CodeFirstNewDatabaseSample
{
     class Program
    {
        static void Main(string[] args)
        {
            //显示全部博客列表
            //QueryBlog();

            //添加新博客
            //crateBlog();
            //更新博客
            //Update();
            //删除博客
            //Delete();
            //显示帖子列表
            //Queryable();
            //删除帖子
            //DeletePost();
            //添加帖子
            //AddPost();

            LinqSelectBlog();
            //texsts();
            //A();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
            
        }
        static void LinqSelectBlog()
        {
            Querypos();
            Console.WriteLine("请输入帖子名称");
            string name = Console.ReadLine();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var pos = bbl.Querysds(name);
            foreach(var item in pos)
            {
                Console.WriteLine(item.Title + " "+
                    item.Content);
            }
        }
        static void Querypos()
        {
            BlogBusinessLayer bbl = new BusinessLayer.BlogBusinessLayer();
            var posts = bbl.QueryPosts();
            foreach (var item in posts)
            {
                Console.WriteLine(item.Title + " " + item.Content);
            }
        }
        static void texsts()
        {
            int[] numList = { 10, 20, 30, 40, 11, 21, 31, 41 };
            //var query = from x in numList
            //            where x % 2 == 0
            //            select x;
            var query1 = from x in numList where (x % 2 == 0) select x;
            var query2 = numList.Where(x => x % 2 == 0).OrderBy(x => x).FirstOrDefault();
            foreach (var item in query1)
            {
                Console.WriteLine(item + " ");
            }
            Console.ReadKey();

            string[] names = { "abc", "aaa", "bde", "bade", "sjs456" };
            //string str = "asdsads";
            //int y = String.Compare(str, "abc");
            //Console.WriteLine(y);
            //var qit = from x in names
            //          where x.Contains("a")
            //          select x;
            //foreach(var item in qit)
            //{
            //    Console.WriteLine(item);
            //}

            Console.ReadKey();
        }
        static void A()
        {
            //显示所有博客
            QueryBlog();
            Console.WriteLine("--1-退出 --2-新增博客   --3-更改博客  --4-删除博客  --5-查询帖子 --6-添加帖子 --7-删除帖子");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                return;
            }

            else if (i == 2)
            {
                crateBlog();
                QueryBlog();
                Console.Clear();
                
            }
            else if (i == 3)
            {
                Update();
                QueryBlog();
                Console.Clear();
                
            }
            else if (i == 4)
            {
                Delete();
                QueryBlog();
                Console.Clear();
                
            }
            else if (i == 5)
            {
                int blogId = GetBlogID();
                //显示指定博客的帖子列表
                DisplatPosts(blogId);
               

            }
            else if (i == 6)
            {
                AddPost();
                Console.Clear();
                
            }
            else if (i==7)
            {
                DeletePost();
                
            }
            else
            {
                Console.WriteLine("无效字符");
            }
        }
        static void AddPost()
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogID();
            //显示指定博客的帖子列表
            DisplatPosts(blogId);
            //根据指定到博客信息创建新帖子
            crateposts(blogId);
            //显示指定博客的帖子列表
            DisplatPosts(blogId);
        }
        static int GetBlogID()
        {
            Console.WriteLine("请输入博客id");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
        static void DisplatPosts(int blogId)
        {
            Console.WriteLine(blogId + "帖子列表");
            List<Post> list = null;
            //根据博客id获取博客
            //BlogBusinessLayer bbl = new BlogBusinessLayer();
            //Console.WriteLine("请输入博客id");
            //int id = int.Parse(Console.ReadLine());
            //Blog blog = bbl.Query(id);
            //string name = blog.Name;
            //Console.WriteLine(name);
            using (var db=new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                list = blog.Posts;
            }
            //根据博客导航属性，获取所有该博客的帖子
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
            foreach (var item in list)
            {
                Console.WriteLine(item.Blog.BlogId + "--" + item.Title+"--"+item.Content);
            }
        }
        static void crateposts(int blogID)
        {
            Console.WriteLine("请输入一个博客的名称");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入一个名称");
            string title = Console.ReadLine();
            Console.WriteLine("请输入一篇内容");
            string content = Console.ReadLine();
            Post post = new Post();
            post.Title = title;
            post.Content = content;
            post.BlogId = blogID;
            BlogBusinessLayer bbl = new BusinessLayer.BlogBusinessLayer();
            bbl.cratepost(post);

        }
        static void DeletePost()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入帖子的id");
            int id = int.Parse(Console.ReadLine());
            Post post = new Post();
            post.PostId = id;
            bbl.deletepost(post);

            
        }
        static void crateBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.WriteLine(item.BlogId + " "+item .Name);
            }
        }
        static void Update()
        {
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        static void Delete()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
