using System;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;

namespace Case9MvcSozluk.Filters
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(
            HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext))
                return false;

            var username = httpContext.User.Identity.Name;

            // FormsAuth writer identities are always namespaced.
            if (username.StartsWith("writer:", StringComparison.Ordinal)) return false;

            var manager = new AdminManager(new EfAdminDal());

            return manager.IsAdministrator(username);
        }

        protected override void HandleUnauthorizedRequest(
            AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result =
                    new HttpStatusCodeResult(403);
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
