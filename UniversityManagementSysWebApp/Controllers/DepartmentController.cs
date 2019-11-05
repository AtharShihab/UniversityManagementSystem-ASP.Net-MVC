using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSysWebApp.Manager;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        public DepartmentManager DepartmentManager { get; private set; }

        public DepartmentController()
        {
            DepartmentManager = new DepartmentManager();
        }
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return RedirectToAction("ViewAllDepartments");
        }

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            string message = DepartmentManager.Save(department);
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult ViewAllDepartments()
        {
            List<Department> departments = DepartmentManager.GetAllDepartments();

            return View(departments);
        }
	}
}