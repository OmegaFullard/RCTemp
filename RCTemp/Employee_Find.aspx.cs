using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Employee_Find : System.Web.UI.Page
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
            try
            {
                if (Page.IsPostBack)
                {
                    if (Request.Form["ctl00$MainContent$ctrSearch_Employee$btnSearch"] == "Search")
                    {

                        ctrSearch_Employee.PopulateSearchControl();
                        
                            {
                            if (ctrSearch_Employee.EmpID == 0)
                            {
                                return;
                            }
                            this.ctrEmployee_Find.EmpID = ctrSearch_Employee.EmpID;
                            
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                clsRCTemp_Web SendError = new clsRCTemp_Web();
                string NotificationBody = ex.Message + Constants.vbCrLf + ex.StackTrace;
                SendError.SendMailMessage(NotificationBody);
                Response.Redirect("ErrorPage.aspx", false);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // needed for Export to Excel to work
            // Verifies that the control is rendered
        }


        public override bool EnableEventValidation
        {
            get
            {
                return false;
            }
            set
            {

            }
        }
    }
}