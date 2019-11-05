using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();
        ResultManager aResultManager = new ResultManager();

        public string Save(Teacher aTeacher)
        {
            if (aTeacher.TeacherName == null || aTeacher.Email == null || aTeacher.Address == null ||
                aTeacher.ContactNo == null || aTeacher.DesignationId == 0 || aTeacher.DepartmentId == 0)
            {
                return "One of the above field is empty. Please fill out the form properly.";
            }
            if (aTeacher.CreditToBeTaken <= 0.00)
            {
                return "Must enter a non negative value.";
            }
            if (!IsValidEmail(aTeacher.Email))
            {
                return "Entered email is not in correct format";
            }
            if (aTeacherGateway.IsEmailExists(aTeacher))
            {
                return "This email address already exists";
            }

            int rowAffect = aTeacherGateway.Save(aTeacher);
            if (rowAffect > 0)
            {
                return "Save successful";
            }

            return "Save failed";
        }

        private static bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public List<Teacher> GetAllTeachersWithDeptId(int deptId)
        {
            return aTeacherGateway.GetAllTeachersWithDeptId(deptId);
        }

        public Teacher GetTeacherInfoWithTeacherId(int teacherId)
        {
            return aTeacherGateway.GetTeacherInfoWithTeacherId(teacherId);
        }

        public string UpdateCreditTaken(string credit, string teacherId)
        {
            if (credit == "" || teacherId == "")
            {
                return "input";
            }
            else
            {
                double creditInDouble = Convert.ToDouble(credit);
                int teacherIntId = Convert.ToInt32(teacherId);
                Teacher teacher = GetTeacherInfoWithTeacherId(teacherIntId);
                creditInDouble += teacher.CreditTaken;
                int rowAffected = aTeacherGateway.UpdateCreditTaken(creditInDouble, teacherIntId);
                if (rowAffected > 0)
                {
                    return "success";
                }

                return "failed";
            }
            
        }
    }
}