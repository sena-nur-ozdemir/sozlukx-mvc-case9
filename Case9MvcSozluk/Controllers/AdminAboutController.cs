using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminAboutController : Controller
    {
        private readonly AboutManager _manager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public ActionResult Index()
        {
            var about = _manager.Get();
            return View(new AboutFormViewModel
            {
                Details1 = about == null ? "" : about.AboutDetails1,
                Details2 = about == null ? "" : about.AboutDetails2,
                Image1 = about == null ? "" : about.AboutImage1,
                Image2 = about == null ? "" : about.AboutImage2
            });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(AboutFormViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try { _manager.Save(model.Details1, model.Details2, model.Image1, model.Image2); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); return View(model); }
            TempData["Success"] = "Hakkımızda kaydedildi."; return RedirectToAction("Index");
        }
    }
}