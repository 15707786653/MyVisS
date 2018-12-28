using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.DataAccessLayer;

namespace MVC.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            //var list = new List<Employee>();
            //Employee emp = new Employee();
            //emp.Name = "石昊";
            //emp.Salary = 5000000;
            //list.Add(emp);

            //emp = new Employee();
            //emp.Name = "叶凡";
            //emp.Salary = 7000;
            //list.Add(emp);

            //emp = new Employee();
            //emp.Name = "楚风";
            //emp.Salary = 1234560;
            //list.Add(emp);
            //return list;

            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.MyEmployees.ToList();
            //return null;
        }
        public Employee SaveEmployees(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.MyEmployees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
        public void Delete(int id)
        {
            using(var db =new SalesERPDAL())
            {
                Employee emp = db.MyEmployees.Find(id);
                db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public Employee Query(int id)
        {
            using (var db=new SalesERPDAL())
            {
                Employee emp = db.MyEmployees.Find(id);
                return emp;
            }
        }
        public void Updatepos(Employee e)
        {
            using (var db=new SalesERPDAL())
            {
                db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public IEnumerable<Employee>Select(string name)
        {
            using(var db=new SalesERPDAL())
            {
                return db.MyEmployees.Where(e => e.Name.Contains(name)).ToList();
            }
        }
    }
}