using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
namespace RCTemp
{
    public partial class Login : System.Web.UI.Page
    {
        protected TextBox txtUser;
        protected TextBox txtPwd;
        protected Label lblError;
        protected CheckBox chkRemember;
        protected void Page_Load(object sender, EventArgs e)
        {
            //// If already authenticated, optionally redirect away
            //if (User?.Identity?.IsAuthenticated ?? false)
            //{
            //    // redirect to returnUrl or default landing
            //    var returnUrl = Request.QueryString["ReturnUrl"];
            //    if (!string.IsNullOrEmpty(returnUrl)) Response.Redirect(returnUrl);
            //    else Response.Redirect(User.IsInRole("Admin") ? "AdminReviews.aspx" : "ClientPortal.aspx");
            //}
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (!Page.IsValid) return;

            var username = txtUser.Text.Trim();
            var password = txtPwd.Text;

            try
            {
                var user = UserRepository.ValidateUser(username, password);
                if (user == null || !string.Equals(user.Role, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    lblError.Text = "Invalid credentials or not an admin.";
                    return;
                }

                // build roles string (can be comma-separated if multiple)
                var roles = user.Role ?? string.Empty;

                // create forms auth ticket
                var isPersistent = chkRemember.Checked;
                var ticket = new FormsAuthenticationTicket(
                    1,
                    user.Username,
                    DateTime.Now,
                    DateTime.Now.AddHours(isPersistent ? 168 : 1), // 7 days if remembered, otherwise 1 hour
                    isPersistent,
                    roles,
                    FormsAuthentication.FormsCookiePath);

                var encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
                {
                    HttpOnly = true,
                    Secure = Request.IsSecureConnection
                };

                if (isPersistent)
                {
                    cookie.Expires = ticket.Expiration;
                }

                Response.Cookies.Add(cookie);

                // redirect to ReturnUrl if provided and local, otherwise to role-based landing
                var returnUrl = Request.QueryString["ReturnUrl"];
                if (!string.IsNullOrEmpty(returnUrl) && UrlIsLocal(returnUrl))
                {
                    Response.Redirect(returnUrl);
                    return;
                }

                // role-based default landing
                if (roles.IndexOf("Admin", StringComparison.OrdinalIgnoreCase) >= 0)
                    Response.Redirect("AdminReviews.aspx");
                else
                    Response.Redirect("ClientPortal.aspx");
            }
            catch (Exception)
            {
                lblError.Text = "An error occurred during login. Please try again later.";
            }
        }

        private bool UrlIsLocal(string url)
        {
            // simple check for local URL to avoid open redirect
            return url.StartsWith("/") && !url.StartsWith("//") && !url.StartsWith("/\\");
        }
    }
}