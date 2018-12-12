using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.VieswModels;

namespace MVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "hello world MVC";
        }
        public Customer getCustomer()
        {
            Customer ct = new Customer();
            ct.CustomerName = "abc"; 
            ct.Address = "def";
            return ct;
            
        }
        public ActionResult GetView()
        {
            //获取当前时间
            string greeting;
            
            DateTime dt = DateTime.Now;
            //获取当前小时数
            int hour = dt.Hour;
            
            //根据小时数判断需要返回哪个视图，<12返回myview 否则返回mygetview>
            if (hour > 12)
            {
                greeting = "下午好";
            }
            else
            {
                greeting = "早上好";
            }
            ViewData["greeting"] = greeting;
            //Employee emp = new Employee();
            //Customer cu = new Customer();
            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //emp.Name = "石昊";
            //emp.Salary = 12138;
            //ViewData["EmpKey"] = emp;
            //ViewBag.Employee = emp;
            //ViewBag.Customer = cu;


            //cu.Address = "叶凡";
            //cu.CustomerName = "广西";
            //ViewData["Customer"] = cu;
            //ViewBag.Employee = emp;
            ////return View("MyGetView", cu);



            //vmEmp.EmployeeName = emp.Name;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if (emp.Salary > 10000)
            //{
            //    vmEmp.SalaryGrade = "土豪";
            //}
            //else
            //{
            //    vmEmp.SalaryGrade = "屌丝";
            //}
            //vmEmp.greeting = greeting;
            //vmEmp.UserName = "超级管理员";
            //return View("MyGetView",vmEmp);

            Employee em = new Employee();
            em.Name = "猴子";
            em.Salary = 12345;
            Customer cu = new Customer();
            cu.CustomerName = "石头";
            cu.Address = "花果山";
            EmCu emcu = new EmCu();
            emcu.em = em;
            emcu.cu = cu;
            return View("MyGetView", emcu);
        }
    }
}