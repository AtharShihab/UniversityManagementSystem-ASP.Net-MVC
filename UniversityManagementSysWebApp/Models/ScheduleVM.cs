using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSysWebApp.Models
{
    public class ScheduleVM
    {
        public string RoomNo { get; set; }
        public string AllocatedDay { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}