using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class CourseGateway : Gateway
    {
        //Save Courses==
        public int Save(Course aCourse)
        {
            Query = "INSERT INTO Courses(CourseName, CourseCode, Credit, CourseDescription, DepartmentId, Semester)" +
                    "VALUES (@courseName, @courseCode, @credit, @courseDescription, @departmentId, @semester)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("courseName", aCourse.CourseName);
            Command.Parameters.AddWithValue("courseCode", aCourse.CourseCode);
            Command.Parameters.AddWithValue("credit", aCourse.Credit);
            Command.Parameters.AddWithValue("courseDescription", aCourse.CourseDescription);
            Command.Parameters.AddWithValue("departmentId", aCourse.DepartmentId);
            Command.Parameters.AddWithValue("semester", aCourse.Semester);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public bool IsNameAndCodeExists(Course aCourse)
        {
            Query = "SELECT * FROM Courses WHERE CourseCode = @courseCode OR CourseName = @courseName";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("courseCode", aCourse.CourseCode);
            Command.Parameters.AddWithValue("courseName", aCourse.CourseName);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }
        //save courses==

        //Course assign to teacher==
        public List<Course> GetAllUnassignedCoursesWithDeptId(int deptId)
        {
            Query = "SELECT * FROM Courses WHERE DepartmentId = @deptId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptId", deptId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = (int) Reader["CourseId"];
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseDescription = Reader["CourseDescription"].ToString();
                aCourse.Credit = Convert.ToDouble(Reader["Credit"]);
                aCourse.DepartmentId = (int) Reader["DepartmentId"];
                aCourse.Semester = Reader["Semester"].ToString();
                string teacherId = Reader["TeacherId"].ToString();

                if (teacherId == "")
                {
                    courses.Add(aCourse);
                }
            }
            Reader.Close();
            Connection.Close();

            return courses;
        }

        public Course GetCourseInfoWithCourseId(int courseId)
        {
            Query = "SELECT * FROM Courses WHERE CourseId = @courseId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("courseId", courseId);

            Connection.Open();
            Reader = Command.ExecuteReader();

            Course aCourse = new Course();
            if (Reader.HasRows)
            {
                Reader.Read();
                aCourse.CourseId = (int)Reader["CourseId"];
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseDescription = Reader["CourseDescription"].ToString();
                aCourse.Credit = Convert.ToDouble(Reader["Credit"]);
                aCourse.DepartmentId = (int)Reader["DepartmentId"];
                aCourse.Semester = Reader["Semester"].ToString();
                string teacherId = Reader["TeacherId"].ToString();

                if (teacherId != "")
                {
                    aCourse.TeacherId = Convert.ToInt32(teacherId);
                }
            }

            Reader.Close();
            Connection.Close();

            return aCourse;
        }

        public int UpdateTeacherId(int teacherId, int courseId)
        {
            Query = "UPDATE Courses SET TeacherId = @teacherId WHERE CourseId = @courseId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("courseId", courseId);
            Command.Parameters.AddWithValue("teacherId", teacherId);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }



        public int UnassignCourses(Course a)
        {
            Query = "UPDATE Courses SET TeacherId=Null";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }
        public int CreditTaken(Teacher aTeacher)
        {
            Query = "UPDATE Teachers SET CreditTaken=0.00 where CreditTaken>0";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }
        //course assign to teacher==

        //View course statics
        public List<Course> GetAllCoursesWithDepartmentId(int deptId)
        {
            Query = "SELECT * FROM Courses WHERE DepartmentId = @deptId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptId", deptId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = (int)Reader["CourseId"];
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseDescription = Reader["CourseDescription"].ToString();
                aCourse.Credit = Convert.ToDouble(Reader["Credit"]);
                aCourse.DepartmentId = (int)Reader["DepartmentId"];
                aCourse.Semester = Reader["Semester"].ToString();
                string teacherId = Reader["TeacherId"].ToString();

                if (teacherId != "")
                {
                    aCourse.TeacherId = Convert.ToInt32(teacherId);
                }
                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();

            return courses;
        } 

        //view course statics
    }
}