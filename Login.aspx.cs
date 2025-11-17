using System;
using System.Web;
using System.Web.Security;

namespace RCTemp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var user = UserRepository.ValidateUser(txtUser.Text.Trim(), txtPwd.Text);
            if (user == null)
            {
                lblError.Text = "Invalid username or password.";
                return;
            }

            // create forms-auth ticket with role in UserData
            var roles = user.Role ?? "";
            var ticket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(30), false, roles, FormsAuthentication.FormsCookiePath);
            var enc = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enc) { HttpOnly = true };
            Response.Cookies.Add(cookie);

            var returnUrl = Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl)) Response.Redirect(returnUrl);
            else Response.Redirect("Jobs.aspx");
        }
    }
}