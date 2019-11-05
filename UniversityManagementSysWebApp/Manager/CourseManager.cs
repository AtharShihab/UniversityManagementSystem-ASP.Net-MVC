using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();

        //Save courses==
        public string Save(Course aCourse)
        {
            if (aCourse.CourseCode == null || aCourse.CourseName == null || aCourse.DepartmentId == 0 ||
                aCourse.Semester == null || aCourse.CourseDescription == null || aCourse.Credit == 0.0)
            {
                return "One of the following field was blank: \nCode, Name, Credit, Department, Semester. \n" +
                       "Please recheck and fill up the form properly";
            }
            if (aCourse.CourseCode != null && aCourse.CourseCode.Length < 5)
            {
                return "Course Code Cannot be Lower Than 5 Characters";
            }
            if (aCourse.Credit < 0.5 || aCourse.Credit > 5.0)
            {
                return "Credit must be in between 0.5 to 5.0";
            }
            if (aCourseGateway.IsNameAndCodeExists(aCourse))
            {
                return "Entered name or code of the course already exists";
            }

            int rowAffect = aCourseGateway.Save(aCourse);
            if (rowAffect > 0)
            {
                return "Save Successful";
            }

            return "Save failed";
        }
        //save courses==

        //Course assign to teacher
        public List<Course> GetAllUnassignedCoursesWithDeptId(int deptId)
        {
            return aCourseGateway.GetAllUnassignedCoursesWithDeptId(deptId);
        }

        public Course GetCourseInfoWithCourseId(int CourseId)
        {
            return aCourseGateway.GetCourseInfoWithCourseId(CourseId);
        }

        public string UpdateTeacherId(string teacherId, string courseId)
        {
            if (teacherId == "" || courseId == "")
            {
                return "input";
            }
            else
            {
                int teacherIntId = Convert.ToInt32(teacherId);
                int courseIntId = Convert.ToInt32(courseId);
                int rowAffected = aCourseGateway.UpdateTeacherId(teacherIntId, courseIntId);

                if (rowAffected > 0)
                {
                    return "success";
                }

                return "failed";
            }
        }

        public string UnassignCourses(Course aCourse, Teacher aTeacher)
        {
            int rowAffected = aCourseGateway.UnassignCourses(aCourse);
            int rowAffected2 = aCourseGateway.CreditTaken(aTeacher);
            if (rowAffected > 0 && rowAffected2 > 0)
            {
                return "Unassign Courses Successfully";
            }

            return "Unassign Failed";
        }
        //course assign to teacher

        //View course statics
        public List<Course> GetAllCoursesWithDepartmentId(int deptId)
        {
            return aCourseGateway.GetAllCoursesWithDepartmentId(deptId);
        } 
        //view course statics
    }
}