using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class ResultGateway : Gateway
    {
        public List<Result> Enrolls()
        {
            Query = "SELECT * FROM Students s JOIN Departments d ON s.DepartmentId=d.DeptId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Result> Students = new List<Result>();
            while (Reader.Read())
            {
                Result aStudent = new Result();
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
        public List<Result> Courses()
        {
            Query = "Select * from Courses c INNER JOIN EnrolledCourses e ON c.CourseId=e.CourseId ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Result> Courses = new List<Result>();
            while (Reader.Read())
            {
                Result aCourse = new Result();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourse.StudentId = Convert.ToInt32(Reader["StudentId"]);
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                Courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return Courses;

        }
        public int Result(Result aResult)
        {

            Query = "INSERT INTO Results(StudentId,CourseId,Grade)" +
                      "VALUES (@StudentId, @CourseId, @Grade)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("StudentId", aResult.StudentId);
            Command.Parameters.AddWithValue("CourseId", aResult.CourseId);
            Command.Parameters.AddWithValue("Grade", aResult.Grade);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;

        }
        public int ResultUpdate(Result aResult)
        {

            Query = "UPDATE Results SET Grade=@Grade WHERE StudentId=" + aResult.StudentId + " AND CourseId=" + aResult.CourseId + "";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("Grade", aResult.Grade);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;

        }
        public bool IsResultExist(Result aResult)
        {
            Query = "Select * from Results where CourseId=" + aResult.CourseId + " AND StudentId=" + aResult.StudentId + "";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasrows = false;
            if (Reader.HasRows)
            {
                hasrows = true;
            }
            Reader.Close();
            Connection.Close();
            return hasrows;

        }
        public List<Result> ViewResult()
        {
            Query = "SELECT * FROM EnrolledCourses e left outer JOIN Results r ON  e.CourseId=r.CourseId and e.StudentId=r.StudentId join Courses c on c.CourseId=e.CourseId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Result> courses = new List<Result>();
            while (Reader.Read())
            {
                Result aCourse = new Result();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourse.StudentId = Convert.ToInt32(Reader["StudentId"]);
                aCourse.CourseCode = Reader["CourseCode"].ToString();
                aCourse.CourseName = Reader["CourseName"].ToString();
                aCourse.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aCourse.Grade = Reader["Grade"].ToString();
               
                if(aCourse.Grade=="")
                {
                    aCourse.Grade = "Not Published";
                }
               
                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<ResultVM> GetResultsbystudentId(int studentId)
        {
            Query = "SELECT * FROM EnrolledCourses e LEFT OUTER JOIN Results r ON  e.CourseId=r.CourseId AND e.StudentId=r.StudentId JOIN Courses c ON c.CourseId=e.CourseId WHERE e.StudentId = @studentId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("studentId", studentId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ResultVM> results = new List<ResultVM>();
            while (Reader.Read())
            {
                ResultVM result = new ResultVM();
                result.CourseCode = Reader["CourseCode"].ToString();
                result.CourseName = Reader["CourseName"].ToString();
                result.Grade = Reader["Grade"].ToString();

                if (result.Grade == "")
                {
                    result.Grade = "Not Published";
                }

                results.Add(result);
            }
            Reader.Close();
            Connection.Close();
            return results;
        }
    }
}