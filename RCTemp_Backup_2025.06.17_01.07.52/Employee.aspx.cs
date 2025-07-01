using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Page.Request.Form["ctl00$MainContent$ctrSearch_Employee$btnSearch"] == "Search")
                {
                    ctrSearch_Employee.PopulateSearchControl();
                    ctrEmployee.EmpID = ctrSearch_Employee.EmpID;
                }
            }
        }
    }
}