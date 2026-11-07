using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminGalleryController : Controller
    {
        private readonly GalleryManager _manager = new GalleryManager(new EfImageFileDal());
        [HttpGet] public ActionResult Index() { return View(_manager.GetList()); }
        [HttpGet] public ActionResult Create() { return View(new GalleryFormViewModel()); }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(GalleryFormViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try { _manager.Add(model.Name, model.Path); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); return View(model); }
            TempData["Success"] = "Görsel eklendi."; return RedirectToAction("Index");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        { try { _manager.Delete(id); } catch (InvalidOperationException) { return HttpNotFound(); } TempData["Success"] = "Görsel silindi."; return RedirectToAction("Index"); }
    }
}