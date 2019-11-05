using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa.MVC;
using UniversityManagementSysWebApp.Manager;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Controllers
{
    public class StudentController : Controller
    {
        public DepartmentManager DepartmentManager { get; private set; }
        public StudentManager StudentManager { get; private set; }
        
        ResultManager aResultManager = new ResultManager();

        public StudentController()
        {
            DepartmentManager = new DepartmentManager();
            StudentManager = new StudentManager();
        }
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return RedirectToAction("RegisterStudent");
        }

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            List<Department> departments = DepartmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            Department adepartment = departments.Find(department => department.DeptId == student.DepartmentId);

            //Creating RegId==
            string regIdPartA = adepartment.DeptCode;
            string regIdPartB = student.RegDate.Year.ToString("0000");
            int regIdInt = 1;
            List<string> regIds = StudentManager.GetAllStudentsRegId(student.DepartmentId, regIdPartB);
            if (regIds.Count > 0)
            {
                regIdInt = Convert.ToInt32(regIds.Max().Substring(regIds.Max().Length - 3)) + 1;
            }
            string regIdPartC = regIdInt.ToString("000");
            student.RegId = regIdPartA + "-" + regIdPartB + "-" + regIdPartC;
            //RegId==

            string message = StudentManager.Save(student);
            if (message == "success")
            {
                return RedirectToAction("RegistrationInformation", new { student.RegId });
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult RegistrationInformation(string regId)
        {
            if (regId != null)
            {
                Student aStudent = StudentManager.GetStudentByRegId(regId);
                ViewBag.Department = DepartmentManager.GetDepartmentByDepartmentId(aStudent.DepartmentId);
                return View(aStudent);
            }
            return RedirectToAction("RegisterStudent");
        }

        /*public ActionResult EnrollInACourse()
        {
            ViewBag.Students = StudentManager.GetAllStudents();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollInACourse(EnrollInACourse enrollInACourse)
        {
            ViewBag.Students = StudentManager.GetAllStudents();/*
            ViewBag.Message = StudentManager.#1#
            return View();
        }*/

        /*public JsonResult GetStudentById(int studentId)
        {
            List<Student> students = StudentManager.GetAllStudents();
            Student student = students.Find(s => s.StudentId == studentId);
            return Json(student);
        }*/

        public ActionResult ViewResult()
        {
            ViewBag.Students = aResultManager.Students();
            return View();
        }
        public ActionResult ResultAsPdf(Result result)
        {
            ViewBag.Results = aResultManager.GetResultsbystudentId(result.StudentId);
            return View(result);
        }
        [HttpPost]
        public ActionResult CreatePdf(Result result)
        {
            return new ActionAsPdf("ResultAsPdf", result);
        }
        public JsonResult GetByPerson(int studentId)
        {
            var students = aResultManager.Students();
            var studentlist = students.Where(s => s.StudentId == studentId);
            return Json(studentlist);
            //  return Json(courselist);
        }
        public JsonResult GetByCourses(int studentId)
        {
            var students = aResultManager.ViewResults();
            var studentlist = students.Where(s => s.StudentId == studentId);
            return Json(studentlist);
            //  return Json(courselist);
        }
        
    }
}