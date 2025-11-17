using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace RCTemp
{
    public class Global : HttpApplication
    {
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            try
            {
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket == null) return;

                var roles = (ticket.UserData ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var id = new FormsIdentity(ticket);
                Context.User = new GenericPrincipal(id, roles);
            }
            catch
            {
                // invalid cookie - ignore
            }
        }
    }
}