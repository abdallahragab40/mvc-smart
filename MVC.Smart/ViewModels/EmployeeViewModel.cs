using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Smart.Models;

namespace MVC.Smart.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}