using RCTemp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RCTemp.xsRCTemp;

namespace RCTemp.Controls_Delete
{

    public partial class ctrEmployee_Delete : System.Web.UI.UserControl
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
                    if (Request.Form["ctl00$MainContent$ctrEmployee_Delete$btnDelete"] == "Delete")
                    {
                        DeleteEmployee();
                    }
                }
                else
                {
                    if (m_EmpID == 0)
                        return;
                    int argEmpID = EmpID;
                    tblEmployee = (EmployeesDataTable)theEmployee.GetEmployees(EmpID);
                    EmpID = argEmpID;
                    if (tblEmployee.Count == 0)
                        return;

                    var withBlock = tblEmployee[0];

                    withBlock.EmpID = int.Parse(txtempid.Text);

                    txtFN.Text = withBlock.FN;
                    txtLN.Text = withBlock.LN;
                    txtphone.Text = withBlock.Phone.ToString();
                    txtemail.Text = withBlock.Email;
                    txtavailable.Text = withBlock.Available;

                    btnDelete.Enabled = true;
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

        public void DeleteEmployee()
        {
            var thisEmployee = new clsEmployee();

            if (string.IsNullOrEmpty(txtempid.Text))
                return;


            // Replace the problematic line with the following:
            thisEmployee.EmpID = Convert.ToInt32(txtempid.Text.Trim());
            

            try
            {
                var theEmployee = new clsRCTemp();
                theEmployee.DeleteEmployee(thisEmployee);
                lblResult.Text = "Employee data has been deleted";
            }
            catch (SqlException ex)
            {
                // Log the exception (consider using a logging framework)
                var SendError = new clsRCTemp_Web();
                string NotificationBody = ex.Message + "  " + ex.StackTrace;
                SendError.SendMailMessage(NotificationBody);

                // Optionally, rethrow the original exception
                throw;
            }

            CleanupControls();
        }

        private void CleanupControls()
        {

            txtempid.Text = string.Empty;
            txtFN.Text = string.Empty;
            txtLN.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtavailable.Text = string.Empty;

        }

        public void CleanResultControl()
        {
            lblResult.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Find.aspx", false);
        }
    }
}