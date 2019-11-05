using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class StudentGateway : Gateway
    {
        public int Save(Student aStudent)
        {
            Query = "INSERT INTO Students(StudentName, RegId, Email, ContactNo, RegDate, Address, DepartmentId)" +
                    "VALUES (@studentName, @regId, @email, @contactNo, @regDate, @address, @departmentId)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("studentName", aStudent.StudentName);
            Command.Parameters.AddWithValue("regId", aStudent.RegId);
            Command.Parameters.AddWithValue("email", aStudent.Email);
            Command.Parameters.AddWithValue("contactNo", aStudent.ContactNo);
            Command.Parameters.AddWithValue("regDate", aStudent.RegDate);
            Command.Parameters.AddWithValue("address", aStudent.Address);
            Command.Parameters.AddWithValue("departmentId", aStudent.DepartmentId);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public bool IsEmailExists(Student aStudent)
        {
            Query = "SELECT * FROM Students WHERE Email = @email AND StudentId <> @studentId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("email", aStudent.Email);
            Command.Parameters.AddWithValue("studentId", aStudent.StudentId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public List<string> GetAllStudentsRegId(int deptId, string year)
        {
            Query =
                "SELECT * FROM Students WHERE RegDate >= @dateOne AND RegDate <= @dateTwo AND DepartmentId = @departmentId ORDER BY RegId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("dateOne", year + "-01-01");
            Command.Parameters.AddWithValue("dateTwo", year + "-12-31");
            Command.Parameters.AddWithValue("departmentId", deptId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<string> regIds = new List<string>();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    string RegId = Reader["RegId"].ToString();
                    regIds.Add(RegId);
                }
            }
            
            Reader.Close();
            Connection.Close();

            return regIds;
        }

        public Student GetStudentByRegId(string regId)
        {
            Query = "SELECT * FROM Students WHERE RegId = @regId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("regId", regId);

            Connection.Open();
            Reader = Command.ExecuteReader();

            Student student = new Student();
            if (Reader.HasRows)
            {
                Reader.Read();

                student.StudentId = Convert.ToInt32(Reader["StudentId"]);
                student.RegId = Reader["RegId"].ToString();
                student.StudentName = Reader["StudentName"].ToString();
                student.Email = Reader["Email"].ToString();
                student.ContactNo = Reader["ContactNo"].ToString();
                student.RegDate = Convert.ToDateTime(Reader["RegDate"]);
                student.Address = Reader["Address"].ToString();
                student.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
            }
            Reader.Close();
            Connection.Close();

            return student;
        }

        public List<Student> GetAllStudents()
        {
            Query = "SELECT * FROM Students";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Student> students = new List<Student>();

            while (Reader.Read())
            {
                Student student = new Student
                {
                    StudentId = Convert.ToInt32(Reader["StudentId"]),
                    RegId = Reader["RegId"].ToString(),
                    StudentName = Reader["StudentName"].ToString(),
                    Email = Reader["Email"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    RegDate = Convert.ToDateTime(Reader["RegDate"]),
                    Address = Reader["Address"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"])
                };

                students.Add(student);
            }

            Reader.Close();
            Connection.Close();

            return students;
        } 
    }
}