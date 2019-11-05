using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSysWebApp.Manager;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Controllers
{
    public class ClassroomAllocationController : Controller
    {
        public DepartmentManager DepartmentManager { get; private set; }
        public ClassroomAllocationManager ClassroomAllocationManager { get; private set; }

        public ClassroomAllocationController()
        {
            DepartmentManager = new DepartmentManager();
            ClassroomAllocationManager = new ClassroomAllocationManager();
        }
        //
        // GET: /ClassroomAllocationVM/
        public ActionResult Index()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            ViewBag.Rooms = ClassroomAllocationManager.GetAllRooms();
            ViewBag.Days = GetAllDaysOfTheWeek();
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClassroomAllocation allocationVm)
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            ViewBag.Rooms = ClassroomAllocationManager.GetAllRooms();
            ViewBag.Days = GetAllDaysOfTheWeek();
            ViewBag.Message = ClassroomAllocationManager.Allocate(allocationVm);
            return View();
        }

        public ActionResult ViewClassScheduleAndRoomAllocationInformation()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();

            return View();
        }

        public JsonResult GetClassSchedule(int deptId)
        {
            List<ClassScheduleInfoVM> classSchedule = ClassroomAllocationManager.GetClassSchedule(deptId);
            return Json(classSchedule);
        }

        public List<SelectListItem> DepartmentSelectListItems()
        {
            var departments = DepartmentManager.GetAllDepartments();

            var departmentListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",
                    Text = "--Select--"
                }
            };
            foreach (var department in departments)
            {
                var departmentListItem = new SelectListItem
                {
                    Value = Convert.ToString(department.DeptId),
                    Text = department.DeptName
                };

                departmentListItems.Add(departmentListItem);
            }

            return departmentListItems;
        }

        public List<SelectListItem> GetAllDaysOfTheWeek()
        {
            var daysOfTheList = new List<SelectListItem>()
            {
                new SelectListItem(){ Value = "", Text = "--Select--"},
                new SelectListItem(){ Value = "Saturday", Text = "Saterday"},
                new SelectListItem(){ Value = "Sunday", Text = "Sunday"},
                new SelectListItem(){ Value = "Monday", Text = "Monday"},
                new SelectListItem(){ Value = "Tuesday", Text = "Tuesday"},
                new SelectListItem(){ Value = "Wednesday", Text = "Wednesday"},
                new SelectListItem(){ Value = "Thursday", Text = "Thursday"},
                new SelectListItem(){ Value = "Friday", Text = "Friday"}
            };

            return daysOfTheList;
        }

        public ActionResult UnallocateAllClassrooms()
        {

            return View();
        }
        [HttpPost]
        public ActionResult UnallocateAllClassroomsPost()
        {
            ViewBag.Message = ClassroomAllocationManager.Unallocate();
            return View();
        }
	}
}