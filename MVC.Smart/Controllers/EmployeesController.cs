using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Smart.Helpers;
using MVC.Smart.Models;
using MVC.Smart.ViewModels;

namespace MVC.Smart.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        ModelContext context = new ModelContext();

        [HttpGet]

        public ViewResult Index()
        {
            EmployeeViewModel employeeVM = new EmployeeViewModel
            {
                Employees = context.Employees.ToList()
            };
            return View(employeeVM);
        }
        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("EmployeeForm");
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                TempData["Message"] = "Employee added successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "Add";
            return View("EmployeeForm");

        }

        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return PartialView("_EmployeePartial", employee);
            }

            return Json(ModelState);

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = context.Employees.Find(id);

            if (employee != null)
            {
                ViewBag.Action = "Edit";
                return View("EmployeeForm",employee);
            }

            return HttpNotFound("Employee not found!");
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Attach(employee);
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
                TempData["Message"] = "Employee edited successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "Edit";
            return View("EmployeeForm", employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                return Json(true);
            }

            return HttpNotFound("Employee not found!");
        }

        [ChildActionOnly]
        public PartialViewResult EmployeePartial(int id)
        {
            Employee employee = context.Employees.Find(id);
            return PartialView("_EmployeePartial", employee);
        }

        public ActionResult Details(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
    }
}