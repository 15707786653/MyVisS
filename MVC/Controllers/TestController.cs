using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

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
                greeting = "早上好";
            }
            else
            {
                greeting = "下午好";
            }
            ViewData["greeting"] = greeting;
            Employee emp = new Employee();
            emp.Name = "石昊";
            emp.Salary = 12138;
            ViewData["EmpKey"] = emp;
            return View("MyGetView");
        }
    }
}