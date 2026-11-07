using System.Web.Mvc;
using Case9MvcSozluk.Security;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;

namespace Case9MvcSozluk.Controllers
{
    public class LoginController : Controller
    {
        private readonly AdminManager _adminManager =
            new AdminManager(new EfAdminDal());

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AdminLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new AdminLoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(
            AdminLoginViewModel model,
            string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
                return View(model);

            var key = LoginThrottle.Key("admin", model.UserName, Request.UserHostAddress);
            if (LoginThrottle.IsBlocked(key))
            {
                ModelState.AddModelError("", "Çok fazla başarısız giriş. 15 dakika sonra yeniden deneyin.");
                return View(model);
            }
            var admin = _adminManager.Authenticate(
                model.UserName.Trim(),
                model.Password);

            if (admin == null)
            {
                LoginThrottle.Failure(key);
                ModelState.AddModelError(
                    "",
                    "Kullanıcı adı veya parola hatalı.");

                return View(model);
            }


            LoginThrottle.Clear(key);
            FormsAuthentication.SetAuthCookie(
                admin.AdminUserName, false);

            return RedirectToAction("Index", "AdminDashboard");

        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("AdminLogin");
        }
    }
}