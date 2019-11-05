using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSysWebApp.Models;

namespace UniversityManagementSysWebApp.Gateway
{
    public class DesignationGateway : Gateway
    {
        public List<Designation> GetAllDesignations()
        {
            Query = "SELECT * FROM Designations";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();

            while (Reader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.DesignationId = Convert.ToInt32(Reader["DesignationId"]);
                aDesignation.DesignationName = Reader["DesignationName"].ToString();

                designations.Add(aDesignation);
            }

            Reader.Close();
            Connection.Close();

            return designations;
        } 
    }
}