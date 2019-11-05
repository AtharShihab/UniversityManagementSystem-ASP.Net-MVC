using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class CourseStaticsVMGateway : Gateway
    {
        public List<CourseStaticsVM> GetAllCoursesWithDepartmentId(int deptId)
        {
            Query = "SELECT Courses.CourseId, Courses.CourseName, Courses.CourseCode, Courses.Semester, Teachers.TeacherName FROM Courses" +
                    " LEFT OUTER JOIN Teachers ON Teachers.TeacherId = Courses.TeacherId WHERE Courses.DepartmentId = @deptId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptId", deptId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStaticsVM> courses = new List<CourseStaticsVM>();

            while (Reader.Read())
            {
                CourseStaticsVM aCourseStaticsVm = new CourseStaticsVM();
                aCourseStaticsVm.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourseStaticsVm.CourseName = Reader["CourseName"].ToString();
                aCourseStaticsVm.CourseCode = Reader["CourseCode"].ToString();
                aCourseStaticsVm.Semester = Reader["Semester"].ToString();
                aCourseStaticsVm.TeacherName = Reader["TeacherName"].ToString();

                if (aCourseStaticsVm.TeacherName == "")
                {
                    aCourseStaticsVm.TeacherName = "Not Assigned Yet";
                }

                courses.Add(aCourseStaticsVm);
            }
            Reader.Close();
            Connection.Close();

            return courses;
        } 
    }
}