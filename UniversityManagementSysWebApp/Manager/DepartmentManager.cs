using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public string Save(Department aDepartment)
        {
            if (aDepartment.DeptName == null || aDepartment.DeptCode == null)
            {
                return "Must Input Department Name And Department Code!!!";
            }
            if (aDepartment.DeptCode.Length < 2 || aDepartment.DeptCode.Length > 7)
            {
                return "Department code must be 2 to 7 character long";
            }
            if (aDepartmentGateway.IsNameAndCodeExists(aDepartment))
            {
                return "Department Name or Code already exists!!!";
            }
            int rowAffect = aDepartmentGateway.Save(aDepartment);

            if (rowAffect > 0)
            {
                return "Save Successful";
            }

            return "Save failed";
        }

        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }

        public Department GetDepartmentByDepartmentId(int deptId)
        {
            return aDepartmentGateway.GetDepartmentByDepartmentId(deptId);
        }
    }
}