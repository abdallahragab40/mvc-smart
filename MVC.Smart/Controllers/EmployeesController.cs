using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Smart.Models;

namespace MVC.Smart.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        ModelContext context = new ModelContext();

        [HttpGet]

        public ViewResult Index()
        {
            return View(context.Employees.ToList());
        }
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (employee.Id == 0)
                context.Employees.Add(employee);

            else 
            {
                var employeeDb = context.Employees.Single(e => e.Id == employee.Id);

                employeeDb.Name = employee.Name;
                employeeDb.Email = employee.Email;
                employeeDb.Salary = employee.Salary;
                employeeDb.Address = employee.Address;
                employeeDb.Gender = employee.Gender;
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
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

        public ActionResult Edit(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            } 
            return View("Add", employee);
        }

        public ActionResult Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }
    }
}