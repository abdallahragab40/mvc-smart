using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Smart.Models;

namespace MVC.Smart.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult RegForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RegForm(Employee employee)
        {
            if (employee != null && employee.Name != null && employee.Email != null)
            {
                ViewBag.Name = employee.Name;
                return View("Welcome");
            }

            return View();
        }
    }
}