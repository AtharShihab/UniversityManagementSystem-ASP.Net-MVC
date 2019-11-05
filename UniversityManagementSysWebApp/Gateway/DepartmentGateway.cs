using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class DepartmentGateway : Gateway
    {
        public int Save(Department aDepartment)
        {
            Query = "INSERT INTO Departments(DeptName, DeptCode) VALUES(@deptName, @deptCode)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptName", aDepartment.DeptName);
            Command.Parameters.AddWithValue("deptCode", aDepartment.DeptCode);

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public bool IsNameAndCodeExists(Department aDepartment)
        {
            Query = "SELECT * FROM Departments WHERE DeptName = @deptName OR DeptCode = @deptCode";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptName", aDepartment.DeptName);
            Command.Parameters.AddWithValue("deptCode", aDepartment.DeptCode);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Departments";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.DeptId = (int) Reader["DeptId"];
                aDepartment.DeptName = Reader["DeptName"].ToString();
                aDepartment.DeptCode = Reader["DeptCode"].ToString();

                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();

            return departments;
        }

        public Department GetDepartmentByDepartmentId(int deptId)
        {
            Query = "SELECT * FROM Departments WHERE DeptId = @deptId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptId", deptId);

            Connection.Open();

            Reader = Command.ExecuteReader();
            Department department = new Department();
            if (Reader.HasRows)
            {
                Reader.Read();
                department.DeptId = (int) Reader["DeptId"];
                department.DeptName = Reader["DeptName"].ToString();
                department.DeptCode = Reader["DeptCode"].ToString();
            }
            Reader.Close();
            Connection.Close();

            return department;
        }
    }
}