using Microsoft.VisualBasic;
using RCTemp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RCTemp.xsRCTemp;

namespace RCTemp.Controls_Update
{
    public partial class ctrEmployee_Update : System.Web.UI.UserControl
    {
        private int m_EmpID = 0;
        internal int m_Original_EmpID = 0;

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

             public int Orig_EmpID
        {
            get
            {
                return m_Original_EmpID;
            }
            set
            {
                m_Original_EmpID = value;
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

                    if (Request.Form["ctl00$MainContent$ctrEmployee_Update$btnUpdate"] == "Update")
                    {
                        UpdateEmployee();
                    }

                    else
                    {
                        if (m_EmpID == 0)

                            return;

                        tblEmployee = (EmployeesDataTable)theEmployee.GetEmpList();
                        if (tblEmployee.Count == 0)

                            return;
                        {
                            var withBlock = tblEmployee[0];
                            txtempid.Text = withBlock.EmpID.ToString();
                            txtFN.Text = withBlock.FN.ToString();
                            txtLN.Text = withBlock.LN.ToString();
                            if (!withBlock.IsPhoneNull())
                            {
                                txtemail.Text = withBlock.Email.Trim();
                                if (!withBlock.IsEmailNull())
                                    txtemail.Text = withBlock.Email.ToString();
                            }

                            if (!withBlock.IsAvailableNull())
                                txtavailable.Text = withBlock.Available.Trim();

                        }

                        this.btnUpdate.Enabled = true;
                    }
                }


                else
                {

                    PopulateControls();
                }
            }


            catch (Exception ex)
            {
                clsRCTemp_Web SendError = new clsRCTemp_Web();
                string NotificationBody = ex.Message + "  " + ex.StackTrace;
                SendError.SendMailMessage(NotificationBody);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        public void UpdateEmployee()
        {

            clsEmployee thisEmployee = new clsEmployee();
            try
            {

                var withBlock = thisEmployee;

                if (txtempid.Text.Length == 0)
                    return;
                // If cmbEmployee.Text = String.Empty Then Exit Sub

                withBlock.Original_EmpID = Convert.ToInt32(txtempid.Text.Trim());

                // IIf(cmbEmployeeText.Length > 0, cmbEmployee.Text, "******")

                withBlock.FN = txtFN.Text.Trim();
                withBlock.LN = txtLN.Text.Trim();
                withBlock.Phone = txtphone.Text.Trim();
                withBlock.Email = txtemail.Text.Trim();
                withBlock.Available = txtavailable.Text.Trim();


                withBlock.EmpID = Convert.ToInt32(Strings.Replace(lblEmpID.Text, "ID", ""));

                try
                {
                    clsRCTemp theEmployee = new clsRCTemp();

                    theEmployee.UpdateEmployee(thisEmployee);
                    lblResult.Text = "Employee data has been updated";
                }
                catch (SqlException ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void PopulateControls()
        {
            clsRCTemp theEmployee = new clsRCTemp();
            EmployeesDataTable tblEmployee = new EmployeesDataTable();
            if (m_EmpID == 0)
                return;
            tblEmployee = (EmployeesDataTable)theEmployee.GetEmployees(m_EmpID);
            if (tblEmployee.Count == 0)
                return;
            var withBlock = tblEmployee[0];
            txtempid.Text = withBlock.EmpID.ToString();
            txtFN.Text = withBlock.FN.ToString();
            txtLN.Text = withBlock.LN.ToString();
            if (!withBlock.IsPhoneNull())
                txtemail.Text = withBlock.Email.Trim();
            if (!withBlock.IsEmailNull())
                txtemail.Text = withBlock.Email.ToString();
            if (!withBlock.IsAvailableNull())
                txtavailable.Text = withBlock.Available.Trim();
            this.btnUpdate.Enabled = true;
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