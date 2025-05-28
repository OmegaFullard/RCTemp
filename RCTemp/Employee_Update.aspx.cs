using Microsoft.VisualBasic;
using RCTemp.Controls_Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Employee_Update : System.Web.UI.Page
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

                    if (Request.Form["ctl00$MainContent$ctrEmployee_Update_EmpID_ClientState"] == "Search")
                    {
                        ctrEmployee_Update.EmpID = 0;
                        this.ctrEmployee_Update.EmpID = ctrSearch_Employee.EmpID;
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

        private void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {


            ctrEmployee_Update.Visible = false;



            switch (e.Item.Value ?? "")
            {
                case "Employee":
                    {
                        ctrEmployee_Update.Visible = true;
                        break;
                    }

            }


        }
    }
}