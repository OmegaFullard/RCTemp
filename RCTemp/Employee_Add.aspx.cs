using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Employee_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Request.Form["ctl00$MainContent$ctrSearch_Employee$btnSearch"] == "Search")
                {
                    ctrSearch_Employee.PopulateSearchControl();

                    if (ctrSearch_Employee.EmpID == 0)
                        return;
                    //this.ctrEmployee_Add.ClearControls(); 
                    this.ctrEmployee_Add.EmpID = ctrSearch_Employee.EmpID;
                }

                else if (Request.Form["ctl00$MainContent$ctrEmployee_Add$btnCreate"] == "Add")
                {
                    this.ctrEmployee_Add.AddEmployee();
                    if ((ctrSearch_Employee.EmpID) == 0)
                        return;
                }
            }
        }
    }
}