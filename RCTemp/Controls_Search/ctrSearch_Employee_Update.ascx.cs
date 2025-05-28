using RCTemp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp.Controls_Search
{
    public partial class ctrSearch_Employee_Update : System.Web.UI.UserControl
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

            if (!Page.IsPostBack)
            {

                cmbEmployee.DataSource = theEmployee.GetEmployeeList();
                cmbEmployee.DataTextField = "EmpID";
                cmbEmployee.DataValueField = "LN";
                cmbEmployee.DataBind();
            }
        }

        public void ClearControl()
        {
            this.cmbEmployee.Value = string.Empty;
            cmbEmployee.Text = "--";
        }
        public void PopulateSearchControl()
        {
            if (int.TryParse(cmbEmployee.Text, out int result))
            {
                m_EmpID = result;
            }
            else
            {
                // Handle the case where the text is not a valid integer
                m_EmpID = 0; // or any default value
            }
        }
    }
}