using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace B12_UploadImageCart.Filters
{
    public class myAuthenFilter : FilterAttribute, IAuthenticationFilter
    {
        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            var authCookie = filterContext.HttpContext.Request.Cookies["auth"];
            if (authCookie == null)
            {
                filterContext.HttpContext.Response.Redirect("/User/Login");
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}