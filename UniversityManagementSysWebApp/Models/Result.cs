using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSysWebApp.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string RegId { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }
        public int GradeId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
    }
}