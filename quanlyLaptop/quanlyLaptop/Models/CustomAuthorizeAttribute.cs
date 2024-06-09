using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        if (httpContext.User == null)
        {
            return false;
        }

        // Get the forms authentication ticket from the cookie
        var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie == null)
        {
            return false;
        }

        // Decrypt the ticket
        FormsAuthenticationTicket authTicket;
        try
        {
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        }
        catch
        {
            return false;
        }

        if (authTicket == null)
        {
            return false;
        }

        // Get the roles from the UserData part of the ticket
        string[] roles = authTicket.UserData.Split(',');

        // Check if the user has any of the required roles
        return roles.Any(role => Roles.Split(',').Contains(role));
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        filterContext.Result = new RedirectResult("~/PhanQuyen/NotPermission");
    }
}
