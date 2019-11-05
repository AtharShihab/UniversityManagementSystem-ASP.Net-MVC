using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSysWebApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public double Credit { get; set; }
        public string CourseDescription { get; set; }
        public int DepartmentId { get; set; }
        public string Semester { get; set; }
        public int TeacherId { get; set; }
    }
}