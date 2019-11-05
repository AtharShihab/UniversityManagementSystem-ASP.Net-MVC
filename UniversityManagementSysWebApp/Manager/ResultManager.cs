using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class ResultManager
    {

        ResultGateway aResultGateway = new ResultGateway();
        public List<Result> Students()
        {

            return aResultGateway.Enrolls();
        }
        public List<Result> Courses()
        {
            return aResultGateway.Courses();
        }
        public List<Result> ViewResults()
        {
            return aResultGateway.ViewResult();
        }
        public string Result(Result aResult)
        {
            if (aResult.StudentName == null || aResult.DepartmentName==null|| aResult.CourseId==0 )
            {
                return "All Entry must be filled";
            }

            else{
                if (aResultGateway.IsResultExist(aResult))
                {
                    int rowAffect = aResultGateway.ResultUpdate(aResult);
                    if (rowAffect > 0)
                    {
                        return "Update Successful";
                    }

                    return "Update failed";
                }
                else
                {
                    int rowAffect = aResultGateway.Result(aResult);
                    if (rowAffect > 0)
                    {
                        return "Save Successful";
                    }

                    return "Save failed";
                }
            }
        }

        public List<ResultVM> GetResultsbystudentId(int studentId)
        {
            return aResultGateway.GetResultsbystudentId(studentId);
        }
    }
}