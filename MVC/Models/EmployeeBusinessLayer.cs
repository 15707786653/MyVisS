using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployeeList()
        {
            var list = new List<Employee>();
            Employee emp = new Employee();
            emp.Name = "jj";
            emp.Salary = 5000000;
            list.Add(emp);

            emp = new Employee();
            emp.Name = "ss";
            emp.Salary = 7000;
            list.Add(emp);

            emp = new Employee();
            emp.Name = "vv";
            emp.Salary = 1234560;
            list.Add(emp);
            return list;
        }
    }
}