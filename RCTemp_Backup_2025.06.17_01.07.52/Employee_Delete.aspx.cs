using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Employee_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsPostBack)
                {
                    string strEmployee = Request.Form["ctl00_MainContent_ctrEmployee_Update_EmpID_ClientState"].Replace("\"", "").Replace("{", "").Replace("}", "").Replace(",", "").Replace("text", "").Replace("value", "").Replace("%20", " ").Replace("%26", "&");

                    if (strEmployee.Length > 2)
                    {
                        string[] arrEmployee = strEmployee.Split(Convert.ToChar(":"));
                        this.ctrEmployee_Delete.EmpID = int.Parse(arrEmployee[1]);
                        this.ctrEmployee_Delete.EmpID = int.Parse(arrEmployee[2]);
                    }
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
    }
}