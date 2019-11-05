using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class ClassroomAllocationGateway : Gateway
    {
        public int Allocate(ClassroomAllocation allocationVm)
        {
            Query = "INSERT INTO AllocatedClassrooms(DepartmentId, CourseId, RoomId, AllocatedDay, StartTime, EndTime)" +
                    "VALUES (@departmentId, @courseId, @roomId, @allocationDay, @startTime, @endTime)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("departmentId", allocationVm.DepartmentId);
            Command.Parameters.AddWithValue("courseId", allocationVm.CourseId);
            Command.Parameters.AddWithValue("roomId", allocationVm.RoomId);
            Command.Parameters.AddWithValue("allocationDay", allocationVm.AllocatedDay);
            Command.Parameters.AddWithValue("startTime", allocationVm.StartTime.ToString("t"));
            Command.Parameters.AddWithValue("endTime", allocationVm.EndTime.ToString("t"));

            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;
        }

        public bool IsCreditHourOverlapped(ClassroomAllocation allocationVm)
        {
            Query =
                "SELECT * FROM AllocatedClassrooms WHERE RoomId = @roomId AND AllocatedDay = @allocationDay AND ((StartTime <= @startTime AND EndTime > @startTime) OR (StartTime < @endTime AND EndTime >= @endTime))";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("roomId", allocationVm.RoomId);
            Command.Parameters.AddWithValue("allocationDay", allocationVm.AllocatedDay);
            Command.Parameters.AddWithValue("startTime", allocationVm.StartTime.ToString("t"));
            Command.Parameters.AddWithValue("endTime", allocationVm.EndTime.ToString("t"));

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return hasRow;
        }

        public List<Room> GetAllRooms()
        {
            Query = "SELECT * FROM ClassRooms";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room aRoom = new Room
                {
                    Id = (int) Reader["Id"],
                    RoomNo = Reader["RoomNo"].ToString()
                };

                rooms.Add(aRoom);
            }
            Reader.Close();
            Connection.Close();

            return rooms;
        }

        public List<ClassScheduleInfoVM> GetClassSchedule(int deptId)
        {
            Query = "SELECT * FROM Courses WHERE DepartmentId = @deptId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("deptId", deptId);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<ClassScheduleInfoVM> classSchedule = new List<ClassScheduleInfoVM>();
            while (Reader.Read())
            {
                ClassScheduleInfoVM aclassSchedule = new ClassScheduleInfoVM();

                aclassSchedule.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aclassSchedule.CourseCode = Reader["CourseCode"].ToString();
                aclassSchedule.CourseName = Reader["CourseName"].ToString();
                classSchedule.Add(aclassSchedule);
            }
            Reader.Close();
            Connection.Close();

            foreach (ClassScheduleInfoVM classScheduleInfoVm in classSchedule)
            {
                classScheduleInfoVm.Schedule = GetAllScheduleInfoByCourseId(classScheduleInfoVm.CourseId);
            }

            return classSchedule;
        }

        public List<ScheduleVM> GetAllScheduleInfoByCourseId(int courseId)
        {
            Query = "SELECT AC.AllocatedDay, AC.StartTime, AC.EndTime, CR.RoomNo FROM AllocatedClassrooms AC LEFT OUTER JOIN ClassRooms CR ON CR.Id = AC.RoomId WHERE CourseId = @courseId ORDER BY AC.AllocatedDay, AC.StartTime";
            
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("courseId", courseId);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<ScheduleVM> scheduleList = new List<ScheduleVM>();
            while (Reader.Read())
            {
                ScheduleVM schedule = new ScheduleVM();
                
                    /*Id = Convert.ToInt32(Reader["Id"]),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"]),
                    CourseId = Convert.ToInt32(Reader["CourseId"]),*/
                schedule.RoomNo = Reader["RoomNo"].ToString();
                schedule.AllocatedDay = Reader["AllocatedDay"].ToString();
                TimeSpan starTime = (TimeSpan)Reader["StartTime"];
                DateTime STime = Convert.ToDateTime(starTime.ToString());
                schedule.StartTime = STime.ToString("hh:mm tt");
                TimeSpan endTime = (TimeSpan)Reader["EndTime"];
                DateTime ETime = Convert.ToDateTime(endTime.ToString());
                schedule.EndTime = ETime.ToString("hh:mm tt");
                

                scheduleList.Add(schedule);
            }
            Reader.Close();
            Connection.Close();

            return scheduleList;
        }

        public int UnallocateAllClassrooms()
        {
            Query = "DELETE FROM AllocatedClassrooms";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;



        }
    }
}