using System;
using System.Collections.Generic;
using System.Web.UI;

namespace RCTemp
{
    public partial class Team : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployees();
            }
        }

        private void BindEmployees()
        {
            // For now this returns sample data. Replace with DB call if needed.
            List<Employee> employees = EmployeeRepository.GetAll();
            rptEmployees.DataSource = employees;
            rptEmployees.DataBind();
        }
    

    // Add this class to your project if EmployeeRepository is missing.
    // If EmployeeRepository should be implemented differently, please provide its details.

   
        public static List<Employee> GetAll()
        {
            // Return sample data for demonstration. Replace with actual data retrieval logic.
            return new List<Employee>();
        }
    }
}