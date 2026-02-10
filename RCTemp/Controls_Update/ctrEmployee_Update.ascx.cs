using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.VisualBasic;
using RCTemp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Telerik.Web.UI.Diagram;
using Telerik.Windows.Documents.Model.Drawing.Charts;
using static Humanizer.In;
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
            if (Page.IsPostBack)
            {
                if (m_EmpID > 0)
                    this.lblEmpID.Text = "ID" + m_EmpID.ToString();
                if (this.lblEmpID.Text.Length == 2)
                    return;

                try
                {
                    if (Request.Form["ctl00$MainContent$ctrEmployee_Update$btnUpdate"] == "Update")
                    {
                        UpdateEmployee();
                    }
                    else if (Request.Form["ctl00$MainContent$ctrSearch_Employee$btnSearch"] == "Search")
                    {
                        clsRCTemp theEmployeeDetail = new clsRCTemp();
                        EmployeesDataTable tblEmployee = (EmployeesDataTable)theEmployeeDetail.GetEmployees(Convert.ToInt32(m_EmpID));
                        var withBlock = tblEmployee[0];

                        txtFN.Text = withBlock.FN.ToString();
                        txtLN.Text = withBlock.LN.ToString();

                        if (withBlock.Email != null)
                            txtemail.Text = withBlock.Email;
                        if (!withBlock.IsAvailableNull())
                            txtavailable.Text = withBlock.Available;

                        btnUpdate.Enabled = true;
                    }
                    PopulateControls();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public void UpdateEmployee()
        {

            clsEmployee thisEmployee = new clsEmployee();
            try
            {

                var withBlock = thisEmployee;

               
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
            
            txtFN.Text = withBlock.FN.ToString();
            txtLN.Text = withBlock.LN.ToString();
            if (!withBlock.IsPhoneNull())
                txtphone.Text = withBlock.Phone.Trim();
            if (withBlock.Email != null)
                txtemail.Text = withBlock.Email.Trim();
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