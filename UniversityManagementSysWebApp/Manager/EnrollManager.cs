using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class EnrollManager
    {
        EnrollGateway aEnrollGateway = new EnrollGateway();
        public List<Enroll> Students()
        {
            return aEnrollGateway.GetAllCourseWithDeptId();
        }
        public List<Course> Courses()
        {
            return aEnrollGateway.Courses();
        }
        public string Entry(Enroll aEnroll)
        {
            if (aEnroll.CourseId == 0 || aEnroll.StudentId == 0 || aEnroll.RegDate == null)
            {
                return "All Filled must be entry";
            }
            else
            {
                if (aEnrollGateway.IsCourseExist(aEnroll))
                {
                    return "Course already Entry";
                }
                {
                    int rowAffect = aEnrollGateway.Enroll(aEnroll);
                    if (rowAffect > 0)
                    {
                        return "Save Successful";
                    }

                    return "Save failed";
                }
            }
        }

    }
}