using System;
using System.Web;

namespace RCTemp
{
    public static class IdentityHelper
    {
        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/Default.aspx");
            }
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) 
                && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) 
                || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }
    }
}