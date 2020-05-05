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
        [ChildActionOnly]
        public PartialViewResult TestActionResult()
        {
            return PartialView("_TestPartial");
        }


        //public FilePathResult TestActionResult()
        //{
        //    return File("~/page.html", "text/html","mypage.html");
        //}

        //public FilePathResult TestActionResult()
        //{
        //    return File("~/page.html", "text/html", "mypage.html");
        //}

        //public JavaScriptResult TestActionResult()
        //{
        //    return JavaScript("alert('hi')");
        //}

        //public JsonResult TestActionResult()
        //{
        //    var x = new Employee
        //    {
        //        Id = 1,
        //        Name = "Osama",
        //        Salary = 2000
        //    };
        //    return Json(x, JsonRequestBehavior.AllowGet);
        //}

        //public RedirectToRouteResult TestActionResult()
        //{
        //    return RedirectToAction(nameof(Index));
        //}

        //public RedirectResult TestActionResult()
        //{
        //    return Redirect("https://www.google.com");
        //}
    }
}