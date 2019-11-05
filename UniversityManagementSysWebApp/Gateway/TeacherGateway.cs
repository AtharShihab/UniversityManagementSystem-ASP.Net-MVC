using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class TeacherGateway : Gateway
    {
        public int Save(Teacher aTeacher)
        {
            Query = "INSERT INTO Teachers(TeacherName, Email, ContactNo, Address, DesignationId, DepartmentId, CreditToBeTaken)" +
                    "VALUES (@teacherName, @email, @contactNo, @address, @designationId, @departmentId, @creditToBeTaken)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("teacherName", aTeacher.TeacherName);
            Command.Parameters.AddWithValue("email", aTeacher.Email);
            Command.Parameters.AddWithValue("contactNo", aTeacher.ContactNo);
            Command.Parameters.AddWithValue("address", aTeacher.Address);
            Command.Parameters.AddWithValue("designationId", aTeacher.DesignationId);
            Command.Parameters.AddWithValue("departmentId", aTeacher.DepartmentId);
            Command.Parameters.AddWithValue("creditToBeTaken", aTeacher.CreditToBeTaken);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public bool IsEmailExists(Teacher aTeacher)
        {
            Query = "SELECT * FROM Teachers WHERE Email = @email AND TeacherId <> @teacherId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("email", aTeacher.Email);
            Command.Parameters.AddWithValue("teacherId", aTeacher.TeacherId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public List<Teacher> GetAllTeachersWithDeptId(int deptId)
        {
            Query = "SELECT * FROM Teachers WHERE DepartmentId = @deptId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptId", deptId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();

            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher
                {
                    TeacherId = (int) Reader["TeacherId"],
                    TeacherName = Reader["TeacherName"].ToString(),
                    Email = Reader["Email"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    DesignationId = (int) Reader["DesignationId"],
                    DepartmentId = (int) Reader["DepartmentId"],
                    Address = Reader["Address"].ToString(),
                    CreditTaken = Convert.ToDouble(Reader["CreditTaken"]),
                    CreditToBeTaken = Convert.ToDouble(Reader["CreditToBeTaken"])
                };

                teachers.Add(aTeacher);
            }

            Reader.Close();
            Connection.Close();

            return teachers;
        }

        public Teacher GetTeacherInfoWithTeacherId(int teacherId)
        {
            Query = "SELECT * FROM Teachers WHERE TeacherId = @teacherId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("teacherId", teacherId);

            Connection.Open();
            Reader = Command.ExecuteReader();

            Teacher aTeacher = new Teacher();
            if(Reader.HasRows)
            {
                Reader.Read();
                aTeacher.TeacherId = (int)Reader["TeacherId"];
                aTeacher.TeacherName = Reader["TeacherName"].ToString();
                aTeacher.Email = Reader["Email"].ToString();
                aTeacher.ContactNo = Reader["ContactNo"].ToString();
                aTeacher.DesignationId = (int)Reader["DesignationId"];
                aTeacher.DepartmentId = (int)Reader["DepartmentId"];
                aTeacher.Address = Reader["Address"].ToString();
                aTeacher.CreditTaken = Convert.ToDouble(Reader["CreditTaken"]);
                aTeacher.CreditToBeTaken = Convert.ToDouble(Reader["CreditToBeTaken"]);
            }

            Reader.Close();
            Connection.Close();

            return aTeacher;
        }

        public int UpdateCreditTaken(double creditTaken, int teacherId)
        {
            Query = "UPDATE Teachers SET CreditTaken = @creditTaken WHERE TeacherId = @teacherId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("creditTaken", creditTaken);
            Command.Parameters.AddWithValue("teacherId", teacherId);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }
    }
}