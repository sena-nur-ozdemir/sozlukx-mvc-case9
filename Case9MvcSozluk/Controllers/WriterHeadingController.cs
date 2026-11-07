using System;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [WriterAuthorize]
    public class WriterHeadingController : Controller
    {
        private readonly HeadingManager _manager = new HeadingManager(new EfHeadingDal(), new EfCategoryDal(), new EfWriterDal());
        private readonly CategoryManager _categories = new CategoryManager(new EfCategoryDal());
        private int WriterID { get { return int.Parse(User.Identity.Name.Substring(7)); } }
        private void Categories(int selected = 0)
        { ViewBag.Categories = new SelectList(_categories.GetActiveList().OrderBy(x => x.CategoryName), "CategoryID", "CategoryName", selected); }
        [HttpGet]
        public ActionResult Index() { return View(_manager.GetAll().Where(x => x.WriterID == WriterID).ToList()); }
        [HttpGet]
        public ActionResult Create() { Categories(); return View(new HeadingFormViewModel()); }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(HeadingFormViewModel model)
        {
            if (!ModelState.IsValid) { Categories(model.CategoryID); return View(model); }
            try { _manager.Add(model.HeadingName, model.CategoryID, WriterID); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); Categories(model.CategoryID); return View(model); }
            TempData["Success"] = "Başlık oluşturuldu."; return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            var h = _manager.GetByID(id.Value); if (h == null) return HttpNotFound();
            if (h.WriterID != WriterID) return new HttpStatusCodeResult(403);
            Categories(h.CategoryID);
            return View(new HeadingFormViewModel { HeadingID = h.HeadingID, HeadingName = h.HeadingName, CategoryID = h.CategoryID });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(HeadingFormViewModel model)
        {
            var h = _manager.GetByID(model.HeadingID); if (h == null) return HttpNotFound();
            if (h.WriterID != WriterID) return new HttpStatusCodeResult(403);
            if (!ModelState.IsValid) { Categories(model.CategoryID); return View(model); }
            try { _manager.Update(model.HeadingID, model.HeadingName, model.CategoryID); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); Categories(model.CategoryID); return View(model); }
            TempData["Success"] = "Başlık güncellendi."; return RedirectToAction("Index");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(int id, bool active)
        {
            var h = _manager.GetByID(id); if (h == null) return HttpNotFound();
            if (h.WriterID != WriterID) return new HttpStatusCodeResult(403);
            _manager.ChangeStatus(id, active); TempData["Success"] = "Durum değiştirildi."; return RedirectToAction("Index");
        }
    }
}