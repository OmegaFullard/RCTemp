using Microsoft.VisualBasic.CompilerServices;
using RCTemp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using static RCTemp.xsRCTemp;

namespace RCTemp.Controls_Add
{
    public partial class ctrEmployee_Add : System.Web.UI.UserControl
    {
        private int m_EmpID = 0;


        public int EmpID
        {
            get
            {
                return m_EmpID;
            }
            set
            {
                m_EmpID = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            clsRCTemp theEmployee = new clsRCTemp();
            EmployeesDataTable tblEmployee = new EmployeesDataTable();

            try
            {

                if (Page.IsPostBack)
                {
                    if (Request.Form["ctl00$MainContent$ctrEmployee_Add$btnAdd"] == "Add")
                    {

                        AddEmployee();

                    }
                }
                else
                {
                    //PopulateControls();
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void AddEmployee()
        {
            try
            {
                clsEmployee thisEmployee = new clsEmployee();


                if (txtempid.Text.Trim().Length == 0 || txtLN.Text.Trim().Length == 0)
                    return;

                thisEmployee.EmpID = Conversions.ToInteger(txtempid.Text.Trim());
                thisEmployee.FN = txtFN.Text.Trim();
                thisEmployee.LN = txtLN.Text;
                thisEmployee.Phone = txtphone.Text.Trim();
                thisEmployee.Email = txtemail.Text;
                thisEmployee.Available = txtavailable.Text;

                try
                {
                    clsRCTemp theEmployee = new clsRCTemp();

                    theEmployee.AddEmployee(thisEmployee);
                    lblResult.Text = "Employee Inventory data has been added";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        lblResult.Text = "Item already exist!";
                    }
                    else
                    {
                        throw new ApplicationException(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                var SendError = new clsRCTemp_Web();
                string NotificationBody = ex.Message + "  " + ex.StackTrace;
                SendError.SendMailMessage(NotificationBody);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Find.aspx", false);
        }
    }
}
