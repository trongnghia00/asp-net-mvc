using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace B12_UploadImageCart.Filters
{
    public class myAuthorFilter : FilterAttribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            var roleCookie = filterContext.HttpContext.Request.Cookies["role"];
            if (roleCookie == null || roleCookie.Value != "admin")
            {
                filterContext.HttpContext.Response.Redirect("/User/Login");
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}