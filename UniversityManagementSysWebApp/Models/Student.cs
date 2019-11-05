using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSysWebApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string RegId { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime RegDate { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }

    }
}