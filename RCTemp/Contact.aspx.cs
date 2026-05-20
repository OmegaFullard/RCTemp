using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitContact_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblContactStatus.ForeColor = System.Drawing.Color.Red;
                lblContactStatus.Text = "Please fix validation errors and try again.";
                return;
            }

            lblContactStatus.ForeColor = System.Drawing.Color.Green;
            lblContactStatus.Text = "Thank you. Your message has been received.";

            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }
    }
}