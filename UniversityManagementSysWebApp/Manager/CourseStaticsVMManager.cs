using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class CourseStaticsVMManager
    {
        CourseStaticsVMGateway aCourseStaticsVmGateway = new CourseStaticsVMGateway();

        public List<CourseStaticsVM> GetAllCoursesWithDepartmentId(int deptId)
        {
            return aCourseStaticsVmGateway.GetAllCoursesWithDepartmentId(deptId);
        }
    }
}