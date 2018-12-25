namespace MVC.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MVC.Models;
    public class SalesERPDAL : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“SalesERPDAL”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“MVC.DataAccessLayer.SalesERPDAL”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“SalesERPDAL”
        //连接字符串。
        public SalesERPDAL()
            : base("name=SalesERPDAL")
        {
        }

        //为数据库中对应实体集合设计不一样的表格名称
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<Employee> MyEmployees { get; set; }
    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}