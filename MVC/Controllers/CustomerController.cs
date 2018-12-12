using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GeView()
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
            Customer c = new Customer();
           c.Address= "叶凡";
           c.CustomerName = "12138";
            //ViewData["EmpKey"] = emp
            ViewBag.Employee = c;
            return View("MyGeView", c);
        }
    }
}