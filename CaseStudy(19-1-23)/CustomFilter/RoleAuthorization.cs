using CaseStudy_19_1_23_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy_19_1_23_.CustomFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class RoleAuthorization : AuthorizeAttribute
    {
        
        
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~//Views/Shared/UnauthorizedView.cshtml"
                };

            }
        }

    }
}