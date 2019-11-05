using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class EnrollGateway : Gateway
    {
        public List<Enroll> GetAllCourseWithDeptId()
        {
            Query = "SELECT * FROM Students s JOIN Departments d ON s.DepartmentId=d.DeptId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Enroll> Students = new List<Enroll>();
            while (Reader.Read())
            {
                Enroll aStudent = new Enroll();
                aStudent.StudentId = Convert.ToInt32(Reader["StudentId"]);
                aStudent.StudentName = Reader["StudentName"].ToString();
                aStudent.RegId = Reader["RegId"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aStudent.DepartmentName = Reader["DeptName"].ToString();
                Students.Add(aStudent);

            }

            Reader.Close();
            Connection.Close();
            return Students;


        }

        public List<Course> Courses()
        {
            Query = "SELECT * FROM Courses";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> Courses = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                Courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return Courses;

        }
        public int Enroll(Enroll aEnroll)
        {

            Query = "INSERT INTO EnrolledCourses(StudentId,CourseId,RegDate)" +
                      "VALUES (@StudentId, @CourseId, @RegDate)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("StudentId", aEnroll.StudentId);
            Command.Parameters.AddWithValue("CourseId", aEnroll.CourseId);
            Command.Parameters.AddWithValue("RegDate", aEnroll.RegDate);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;

        }

        public bool IsCourseExist(Enroll aEnroll)
        {
            Query = "Select * from EnrolledCourses where CourseId=" + aEnroll.CourseId + " AND StudentId=" + aEnroll.StudentId + "";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasrows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasrows;

        }
        //GetAllUnassignedCoursesWithDeptId(int deptId)
        //        Query = "SELECT * FROM Courses WHERE DepartmentId = @deptId";

        //            Command = new SqlCommand(Query, Connection);
        //        Command.Parameters.Clear();

        //            Command.Parameters.AddWithValue("deptId", deptId);

        //            Connection.Open();
        //            Reader = Command.ExecuteReader();
        //            List<Course> courses = new List<Course>();

        //            while (Reader.Read())
        //            {
        //                Course aCourse = new Course();
        //        aCourse.CourseId = (int) Reader["CourseId"];
        //        aCourse.CourseName = Reader["CourseName"].ToString();
        //        aCourse.CourseCode = Reader["CourseCode"].ToString();
        //        aCourse.CourseDescription = Reader["CourseDescription"].ToString();
        //        aCourse.Credit = Convert.ToDouble(Reader["Credit"]);
        //                aCourse.DepartmentId = (int) Reader["DepartmentId"];
        //        aCourse.Semester = Reader["Semester"].ToString();
        //        string teacherId = Reader["TeacherId"].ToString();

        //                if (teacherId == "")
        //                {
        //                    courses.Add(aCourse);
        //                }
        //}
        //Reader.Close();
        //            Connection.Close();

        //            return courses;
    }
}