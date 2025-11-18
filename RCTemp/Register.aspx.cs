using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace RCTemp
{
    public partial class Register : System.Web.UI.Page
    {
        protected TextBox txtUsername;
        protected TextBox txtPassword;     
        protected Label lblMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                // already logged in — send to client portal
                Response.Redirect("ClientPortal.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;

            if (!Page.IsValid) return;

            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username and password are required.";
                return;
            }

            try
            {
                // create user with role "User"
                UserRepository.CreateUser(username, password, "User");

                // auto-login after registration
                var roles = "User";
                var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddHours(1), false, roles, FormsAuthentication.FormsCookiePath);
                var enc = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enc) { HttpOnly = true, Secure = Request.IsSecureConnection };
                Response.Cookies.Add(cookie);

                Response.Redirect("ClientPortal.aspx");
            }
            catch (SqlException sqlEx)
            {
                // unique constraint violation (username exists)
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    lblMessage.Text = "That username is already registered. Please choose another or log in.";
                    return;
                }

                lblMessage.Text = "A database error occurred. Please try again later.";
            }
            catch (Exception)
            {
                lblMessage.Text = "An error occurred while creating the account. Please try again later.";
            }
        }
    }
}