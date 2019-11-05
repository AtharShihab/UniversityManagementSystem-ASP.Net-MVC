using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSysWebApp.Manager;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Controllers
{
    public class CourseEnrollController : Controller
    {
        //
        // GET: /CourseEnroll/
        EnrollManager aEnrollManager = new EnrollManager();
        public ActionResult Enroll()
        {
            ViewBag.Students = aEnrollManager.Students();
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(Enroll aEnroll)
        {
            ViewBag.Students = aEnrollManager.Students();
            ViewBag.Message = aEnrollManager.Entry(aEnroll);
            return View();
        }
        public JsonResult GetByPerson(int studentId)
        {
            var students = aEnrollManager.Students();
            var studentlist = students.Where(s => s.StudentId == studentId);
            return Json(studentlist);
            //  return Json(courselist);
        }
        public JsonResult GetByCourse(int departmentId)
        {
            var students = aEnrollManager.Courses();
            var studentlist = students.Where(s => s.DepartmentId == departmentId);
            return Json(studentlist);
        }
    }
}