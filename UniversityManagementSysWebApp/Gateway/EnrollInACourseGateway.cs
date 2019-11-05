using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class EnrollInACourseGateway : Gateway
    {
        public int Enroll(EnrollInACourse enrollInACourse)
        {
            Query = "INSERT INTO EnrolledCourses (StudentId, CourseId, RegDate) VALUES(@studentId, courseId, regDate)";

            Command = new SqlCommand();
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("studentId", enrollInACourse.StudentId);
            Command.Parameters.AddWithValue("courseId", enrollInACourse.CourseId);
            Command.Parameters.AddWithValue("regDate", enrollInACourse.RegDate);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }
    }
}