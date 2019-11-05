using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSysWebApp.Models
{
    public class ClassScheduleInfoVM
    {
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public List<ScheduleVM> Schedule { get; set; }

        public ClassScheduleInfoVM()
        {
            Schedule = new List<ScheduleVM>();
        }
    }
}