using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (ModelState.IsValid)
            {
                ModelContext ctx = new ModelContext();
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
                return View("Welcome", employee);
            }

            return View();
        }
    }
}