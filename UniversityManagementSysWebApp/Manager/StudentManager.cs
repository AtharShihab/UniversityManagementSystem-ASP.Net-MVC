using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();

        public string Save(Student aStudent)
        {
            if (aStudent.StudentName == null || aStudent.Email == null || aStudent.Address == null ||
                aStudent.ContactNo == null || aStudent.DepartmentId == 0)
            {
                return "One of the above field is empty. Please fill out the form properly.";
            }
            if (!IsValidEmail(aStudent.Email))
            {
                return "Entered email is not in correct format";
            }
            if (aStudentGateway.IsEmailExists(aStudent))
            {
                return "This email address already exists";
            }
            else
            {

                int rowAffect = aStudentGateway.Save(aStudent);
                if (rowAffect > 0)
                {
                    return "success";
                }

                return "Save failed";
            }
            
        }

        public List<string> GetAllStudentsRegId(int deptId, string year)
        {
            return aStudentGateway.GetAllStudentsRegId(deptId, year);
        }

        private static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email); ;
        }

        public Student GetStudentByRegId(string regId)
        {
            return aStudentGateway.GetStudentByRegId(regId);
        }

        public List<Student> GetAllStudents()
        {
            return aStudentGateway.GetAllStudents();
        } 
    }
}