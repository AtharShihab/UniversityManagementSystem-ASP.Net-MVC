using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Gateway;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Manager
{
    public class DesignationManager
    {
        DesignationGateway aDesignationGateway = new DesignationGateway();

        public List<Designation> GetAllDesignations()
        {
            return aDesignationGateway.GetAllDesignations();
        } 
    }
}