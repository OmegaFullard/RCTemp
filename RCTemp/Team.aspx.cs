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
            
            List<Employee> employees = EmployeeRepository.GetAll();
            rptEmployees.DataSource = employees;
            rptEmployees.DataBind();
        }
    
        public static List<Employee> GetAll()
        {
            
            return new List<Employee>();
        }
    }
}