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
    }
}