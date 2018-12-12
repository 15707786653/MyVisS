using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.VieswModels;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmPloyeeListViewModel employeeModel = new EmPloyeeListViewModel();
            //实例化员工信息业务层
            EmployeeBusinessLayer empBl = new EmployeeBusinessLayer();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmp = empBl.GetEmployeeList();
           
            var listEmpVm = new List<EmployeeViewModel>();
            //通过循环遍历员工原始数组，将数据一个一个的转换，并加入listEmpVm
            foreach(var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeName = item.Name;
                empVmObj.Salary = item.Salary.ToString("C");
                if (item.Salary > 10000)
                {
                    empVmObj.SalaryGrade = "土豪";
                }
                else
                {
                    empVmObj.SalaryGrade = "穷逼";
                }
                listEmpVm.Add(empVmObj);
            }
            employeeModel.EmployeeViewList = listEmpVm;

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
            employeeModel.Greeting = greeting;
            employeeModel.UserName = "Admin";
            return View(employeeModel);
        }
    }
}