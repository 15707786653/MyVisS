using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Employee
    {
        [Key]
        public int Employeeld { get; set; }
        public string Name { get; set; } 
        public int Salary { get; set; }
    }
}