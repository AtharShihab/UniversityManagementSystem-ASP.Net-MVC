using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSysWebApp.Models
{
    public class CourseStaticsVM
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Semester { get; set; }
        public string TeacherName { get; set; }
    }
}