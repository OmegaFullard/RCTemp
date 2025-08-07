using Microsoft.VisualBasic.CompilerServices;
using RCTemp.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;
using static Humanizer.In;
using static RCTemp.xsRCTemp;

namespace RCTemp.Controls_Add
{
    public partial class ctrEmployee_Add : System.Web.UI.UserControl
    {
        private string m_EmpID = string.Empty;


        public string EmpID
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
            //clsRCTemp theEmployee = new clsRCTemp();
            //EmployeesDataTable tblEmployee = new EmployeesDataTable();

            //try
            //{

            //    if (Page.IsPostBack)
            //    {
            //        if (Request.Form["ctl00$MainContent$ctrEmployee_Add$btnAdd"] == "Add")
            //        {

            //            AddEmployee();

            //        }
            //    }
            //    else
            //    {
            //        //PopulateControls();
            //    }
            //}

            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public void AddEmployee()
        {
            try
            {
                clsEmployee thisEmployee = new clsEmployee();

                //thisEmployee.EmpID = Conversions.ToInteger(txtempid.Text.Trim());
                thisEmployee.FN = txtFN.Text.Trim();
                thisEmployee.LN = txtLN.Text.Trim();
                thisEmployee.Phone = txtphone.Text.Trim();
                thisEmployee.Email = txtemail.Text;
                thisEmployee.Available = txtavailable.Text;

                if (txtempid.Text.Trim().Length == 0 || txtLN.Text.Trim().Length == 0)
                    return;

                    clsRCTemp theEmployee = new clsRCTemp();

                    m_EmpID = theEmployee.AddEmployee(thisEmployee);
                    lblResult.Text = "ID" + m_EmpID.ToString();
                }
                catch (Exception)
                {
                  
                        throw;
                    }
                }
           

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee_Find.aspx", false);
        }
    }
}
