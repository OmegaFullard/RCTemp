using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;


namespace RCTemp
{
    public partial class sign_up : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    // Check if user is already logged in
            //    if (User.Identity.IsAuthenticated)
            //    {
            //        Response.Redirect("~/Default.aspx");
            //    }
            //}
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //// Validate inputs
            //if (!ValidateInputs())
            //{
            //    return;
            //}

            //try
            //{
            //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            //    if (manager == null)
            //    {
            //        ShowError("User manager is not available. Please contact support.");
            //        return;
            //    }

            //    // Create user object
            //    var user = new ApplicationUser()
            //    {
            //        UserName = txtEmail.Text.Trim(),
            //        Email = txtEmail.Text.Trim(),
            //        FirstName = txtFirstName.Text.Trim(),
            //        LastName = txtLastName.Text.Trim(),
            //        Address = txtAddress.Text.Trim(),
            //        Address2 = txtAddress2.Text.Trim(),
            //        City = txtCity.Text.Trim(),
            //        State = ddlState.SelectedValue,
            //        ZipCode = txtZip.Text.Trim(),
            //        PhoneNumber = txtPhone.Text.Trim()
            //    };

            //    // Create user with password
            //    IdentityResult result = manager.Create(user, txtPassword.Text);

            //    if (result.Succeeded)
            //    {
            //        // Sign in the user
            //        if (signInManager != null)
            //        {
            //            signInManager.SignIn(user, isPersistent: chkRememberMe.Checked, rememberBrowser: false);
            //        }
            //        else
            //        {
            //            // Fallback: Manual sign-in
            //            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //            Context.GetOwinContext().Authentication.SignIn(
            //                new Microsoft.Owin.Security.AuthenticationProperties() 
            //                { 
            //                    IsPersistent = chkRememberMe.Checked 
            //                }, 
            //                identity
            //            );
            //        }

            //        // Redirect to return URL or default page
            //        string returnUrl = Request.QueryString["ReturnUrl"];
            //        if (!string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            //        {
            //            Response.Redirect(returnUrl, false);
            //        }
            //        else
            //        {
            //            Response.Redirect("~/Default.aspx", false);
            //        }
            //        Context.ApplicationInstance.CompleteRequest();
            //    }
            //    else
            //    {
            //        // Display errors
            //        DisplayErrors(result);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception
            //    System.Diagnostics.Debug.WriteLine($"Registration error: {ex.Message}");
            //    ShowError("An error occurred during registration. Please try again.");
            //}
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            string errorMessage = "";

            // Required field validation
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorMessage += "First Name is required.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorMessage += "Last Name is required.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorMessage += "Email is required.<br/>";
                isValid = false;
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                errorMessage += "Please enter a valid email address.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorMessage += "Password is required.<br/>";
                isValid = false;
            }
            else if (txtPassword.Text.Length < 6)
            {
                errorMessage += "Password must be at least 6 characters long.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorMessage += "Address is required.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                errorMessage += "City is required.<br/>";
                isValid = false;
            }

            if (string.IsNullOrEmpty(ddlState.SelectedValue))
            {
                errorMessage += "Please select a state.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtZip.Text))
            {
                errorMessage += "Zip code is required.<br/>";
                isValid = false;
            }
            else if (!IsValidZipCode(txtZip.Text))
            {
                errorMessage += "Please enter a valid zip code.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorMessage += "Phone number is required.<br/>";
                isValid = false;
            }

            if (!isValid)
            {
                ShowError(errorMessage);
            }

            return isValid;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidZipCode(string zipCode)
        {
            // Supports both 5-digit and 9-digit (with hyphen) zip codes
            var zip5Pattern = @"^\d{5}$";
            var zip9Pattern = @"^\d{5}-\d{4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(zipCode, zip5Pattern) ||
                   System.Text.RegularExpressions.Regex.IsMatch(zipCode, zip9Pattern);
        }

        private bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) 
                && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) 
                || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        private void DisplayErrors(IdentityResult result)
        {
            string errorMessage = "";
            foreach (var error in result.Errors)
            {
                errorMessage += error + "<br/>";
            }
            ShowError(errorMessage);
        }

        private void ShowError(string message)
        {
            // Using ClientScript to show an alert
            string script = $"alert('{message.Replace("'", "\\'").Replace("\r", "").Replace("\n", "")}');";
            ClientScript.RegisterStartupScript(this.GetType(), "ValidationError", script, true);
        }
    }
}
