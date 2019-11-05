using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSysWebApp.Manager;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Controllers
{
    public class CourseController : Controller
    {
        public CourseManager CourseManager { get; private set; }
        public DepartmentManager DepartmentManager { get; private set; }
        public TeacherManager TeacherManager { get; private set; }
        public CourseStaticsVMManager CourseStaticsVmManager { get; private set; }
        public CourseController()
        {
            CourseManager = new CourseManager();
            DepartmentManager = new DepartmentManager();
            TeacherManager = new TeacherManager();
            CourseStaticsVmManager = new CourseStaticsVMManager();
        }

        //
        // GET: /Course/
        /*public ActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public ActionResult SaveCourse()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            string message = CourseManager.Save(course);
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult CourseAssignToTeacher()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            
            return View();
        }

        [HttpPost]
        public ActionResult CourseAssignToTeacher(string teacherId, string courseId, string credit)
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            string message1 = CourseManager.UpdateTeacherId(teacherId, courseId);
            string message2 = TeacherManager.UpdateCreditTaken(credit, teacherId);
            if (message1 == "input" || message2 == "input")
            {
                ViewBag.Message = "Must select a teacher and a course";
            }
            else if(message1 == "success" && message2 == "success")
            {
                ViewBag.Message = "Course assignment successfull";
            }
            else if(message1 == "failed" || message2 == "failed")
            {
                ViewBag.Message = "Course assignment failed";
            }
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int deptId)
        {
            List<Teacher> teachers = TeacherManager.GetAllTeachersWithDeptId(deptId);
            return Json(teachers);
        }

        public JsonResult GetTeacherInfoByTeacherId(int teacherId)
        {
            Teacher teacher = TeacherManager.GetTeacherInfoWithTeacherId(teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnassignedCoursesByDepartmentId(int deptId)
        {
            List<Course> courses = CourseManager.GetAllUnassignedCoursesWithDeptId(deptId);
            return Json(courses);
        }

        public JsonResult GetCourseInfoByCourseId(int courseId)
        {
            Course course = CourseManager.GetCourseInfoWithCourseId(courseId);
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewCourseStatics()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();

            return View();
        }

        public JsonResult GetAllCoursesWithDepartmentId(int deptId)
        {
            List<CourseStaticsVM> courses = CourseStaticsVmManager.GetAllCoursesWithDepartmentId(deptId);
            return Json(courses);
        }

        public ActionResult Unassign()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Unassign(Course aCourse, Teacher a)
        {
            ViewBag.Courses = CourseManager.UnassignCourses(aCourse, a);
            return View();
        }
	}
}