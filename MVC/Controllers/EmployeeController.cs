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
            //获取将处理过的数据列表
            employeeModel.EmployeeViewList = getEmpVmList();
            //获取问候语
            employeeModel.Greeting = getGeeting();
            //获取用户名
            employeeModel.UserName = getUserName();
            //将数据送往视图
            return View(employeeModel);
        }
        //跳转到新增界面
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        //public ActionResult SaveEmployee(Employee emp)
        //{
        //    return new  RedirectResult("Index");
        //}
        public ActionResult SaveEmployee(Employee emp,string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "保存":
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployees(emp);
                        return RedirectToAction("Index");
                    }
                case "取消":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer emBal = new EmployeeBusinessLayer();
            emBal.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Select(string name)
        {
            EmployeeBusinessLayer emBal = new EmployeeBusinessLayer();
            var querResult = emBal.Select(name);
            return View(querResult);
        }
        

        //public ActionResult Update()
        //{
        //    return View("UpdateInterface");
        //}
        public ActionResult Updatepos(int id )
        {
            EmployeeBusinessLayer emBal = new EmployeeBusinessLayer();
            Employee emp = emBal.Query(id);
            return View(emp);


        }
        [HttpPost]
        public ActionResult Updatepos(Employee e)
        {
            EmployeeBusinessLayer emBal = new EmployeeBusinessLayer();
            emBal.Updatepos(e);
            return RedirectToAction("Index");
        }
        [NonAction]
        List<EmployeeViewModel> getEmpVmList()
        {
            //实例化员工信息业务层
            EmployeeBusinessLayer empBl = new EmployeeBusinessLayer();
            //员工原始数据列表，获取来自业务层类的数据
            var listEmp = empBl.GetEmployeeList();
            //员工原始数据加工后的视图数据列表，当前状态是空的
            var listEmpVm = new List<EmployeeViewModel>();
            //通过循环遍历员工原始数组，将数据一个一个的转换，并加入listEmpVm
            foreach (var item in listEmp)
            {
                EmployeeViewModel empVmObj = new EmployeeViewModel();
                empVmObj.EmployeeId=item.Employeeld.ToString();
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
            return listEmpVm;
        }
        [NonAction]
        string getGeeting()
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
            return greeting;
        }
        [NonAction]
        string getUserName()
        {
            return "spider-man  蜘蛛侠";
        }
    }
}