using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSysWebApp.Models
{
    public class EnrollInACourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegDate { get; set; }
    }
}