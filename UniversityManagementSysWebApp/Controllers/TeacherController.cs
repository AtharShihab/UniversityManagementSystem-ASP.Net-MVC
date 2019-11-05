using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSysWebApp.Manager;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Controllers
{
    public class TeacherController : Controller
    {
        public TeacherManager TeacherManager { get; private set; }
        public DepartmentManager DepartmentManager { get; private set; }
        public DesignationManager DesignationManager { get; private set; }
      
        ResultManager aResultManager = new ResultManager();

        public TeacherController()
        {
            TeacherManager = new TeacherManager();
            DepartmentManager = new DepartmentManager();
            DesignationManager = new DesignationManager();
        }
        //
        // GET: /Teacher/
        /*public ActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            ViewBag.Designations = DesignationManager.GetAllDesignations();

            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            ViewBag.Departments = DepartmentManager.GetAllDepartments();
            ViewBag.Designations = DesignationManager.GetAllDesignations();

            ViewBag.Message = TeacherManager.Save(teacher);

            return View();
        }


        public ActionResult Result()
        {

            ViewBag.Grades = Grades();
            ViewBag.Students = aResultManager.Students();
            return View();
        }
        [HttpPost]
        public ActionResult Result(Result aResult)
        {
            ViewBag.Grades = Grades();
            ViewBag.Students = aResultManager.Students();
            ViewBag.Results = aResultManager.Result(aResult);

            return View();
        }
        public JsonResult GetByPerson(int studentId)
        {
            var students = aResultManager.Students();
            var studentlist = students.Where(s => s.StudentId == studentId);
            return Json(studentlist);
            //  return Json(courselist);
        }
        public JsonResult GetByCourse(int StudentId)
        {
            var students = aResultManager.Courses();
            var studentlist = students.Where(s => s.StudentId == StudentId);
            return Json(studentlist);
            //  return Json(courselist);
        }
        public List<Result> Grades()
        {
            List<Result> grades = new List<Result>()
            {
                new Result(){GradeId=1,Grade="A+"},
                new Result(){GradeId=2,Grade="A"},
                new Result(){GradeId=3,Grade="A-"},
                new Result(){GradeId=4,Grade="B+"},
                new Result(){GradeId=5,Grade="B"},
                new Result(){GradeId=6,Grade="B-"},
                new Result(){GradeId=7,Grade="C+"},
                new Result(){GradeId=8,Grade="C"},
                new Result(){GradeId=9,Grade="C-"},
                new Result(){GradeId=10,Grade="D+"},
                new Result(){GradeId=11,Grade="D"},
                new Result(){GradeId=12,Grade="D-"},
                new Result(){GradeId=13,Grade="F"}

            };
            return grades;
        }
	}
}