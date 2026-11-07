using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Filters
{
    public class WriterAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase context)
        {
            if (!base.AuthorizeCore(context)) return false;
            var identity = context.User.Identity.Name;
            int id;
            if (!identity.StartsWith("writer:", StringComparison.Ordinal) ||
                !int.TryParse(identity.Substring(7), out id)) return false;
            var writer = new EfWriterDal().GetByID(id);
            return writer != null && writer.WriterStatus;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new HttpStatusCodeResult(403);
                return;
            }
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "WriterAccount",
                action = "Login"
            }));
        }
    }
}