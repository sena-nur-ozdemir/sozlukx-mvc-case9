using System;
using System.Web.Mvc;
using Case9MvcSozluk.Security;
using System.Web.Security;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;

namespace Case9MvcSozluk.Controllers
{
    public class WriterAccountController : Controller
    {
        private readonly WriterAccountManager _manager = new WriterAccountManager(new EfWriterDal());

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login() { return View(new WriterLoginViewModel()); }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(WriterLoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var key = LoginThrottle.Key("writer", model.UserName, Request.UserHostAddress);
            if (LoginThrottle.IsBlocked(key))
            {
                ModelState.AddModelError("", "Çok fazla başarısız giriş. 15 dakika sonra yeniden deneyin.");
                return View(model);
            }
            var writer = _manager.Authenticate(model.UserName, model.Password);
            if (writer == null)
            {
                LoginThrottle.Failure(key);
                ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı.");
                return View(model);
            }
            LoginThrottle.Clear(key);
            FormsAuthentication.SetAuthCookie("writer:" + writer.WriterID, false);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register() { return View(new WriterRegisterViewModel()); }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(WriterRegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                var writer = _manager.Register(model.Name, model.Surname, model.UserName, model.Email, model.Password);
                FormsAuthentication.SetAuthCookie("writer:" + writer.WriterID, false);
                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            if (User != null && User.Identity.IsAuthenticated && User.Identity.Name.StartsWith("writer:", StringComparison.Ordinal))
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}