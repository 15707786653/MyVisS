using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.VieswModels
{
    public class EmployeeViewModel
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string SalaryGrade { get; set; }
    }
}