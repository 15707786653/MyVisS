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
            return null;
        }
    }
}