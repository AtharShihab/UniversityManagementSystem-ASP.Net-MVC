using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class ClassroomAllocationManager
    {
        public ClassroomAllocationGateway ClassroomAllocationGateway { get; private set; }

        public ClassroomAllocationManager()
        {
            ClassroomAllocationGateway = new ClassroomAllocationGateway();
        }

        public string Allocate(ClassroomAllocation allocationVm)
        {
            if (allocationVm.DepartmentId == 0 || allocationVm.CourseId == 0 || allocationVm.RoomId == 0 ||
                allocationVm.AllocatedDay == null)
            {
                return "All the fields is neccessary to allocate a classroom";
            }
            if (ClassroomAllocationGateway.IsCreditHourOverlapped(allocationVm))
            {
                return "Selected room is already occupied at " + allocationVm.AllocatedDay.Substring(0, 3) + ", " +
                       allocationVm.StartTime + " - " + allocationVm.EndTime;
            }
            int rowAffected = ClassroomAllocationGateway.Allocate(allocationVm);
            if (rowAffected > 0)
            {
                return "Classroom allocation successful";
            }

            return "Classroom allocation failed";
        }

        public List<Room> GetAllRooms()
        {
            return ClassroomAllocationGateway.GetAllRooms();
        }

        public List<ClassScheduleInfoVM> GetClassSchedule(int deptId)
        {
            return ClassroomAllocationGateway.GetClassSchedule(deptId);
        }

        public string Unallocate()
        {
            int rowAffected = ClassroomAllocationGateway.UnallocateAllClassrooms();
            if (rowAffected > 0)
            {
                return "Unallocation Successful";
            }

            return "Unallocation Failed";
        }
    }
}