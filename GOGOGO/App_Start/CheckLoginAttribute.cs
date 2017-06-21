using System;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using GOGOGO.BLL;

namespace GOGOGO
{
    public class CheckLoginAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool pass;
            bool loginState = false;
            try
            {
                loginState = (bool)httpContext.Session["IsLogin"];
            }
            catch (Exception)
            {
            }
            if (!loginState)
            {
                httpContext.Response.StatusCode = 401; //无权限状态码  
                httpContext.RedirectLocal("/Account/Logion");
                pass = false;
            }
            else
            {
                pass = true;
            }

            return pass;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 401)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}