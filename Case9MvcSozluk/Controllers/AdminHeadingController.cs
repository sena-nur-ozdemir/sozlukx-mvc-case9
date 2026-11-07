using System;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminHeadingController : Controller
    {
        private readonly HeadingManager _manager = new HeadingManager(new EfHeadingDal(), new EfCategoryDal(), new EfWriterDal());
        private readonly CategoryManager _categories = new CategoryManager(new EfCategoryDal());
        private readonly WriterManager _writers = new WriterManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index() { return View(_manager.GetAll()); }
        private void Lists(int selectedCat = 0, int selectedWriter = 0)
        {
            ViewBag.Categories = new SelectList(_categories.GetActiveList().OrderBy(x => x.CategoryName), "CategoryID", "CategoryName", selectedCat);
            ViewBag.Writers = new SelectList(_writers.GetList().Where(x => x.WriterStatus).OrderBy(x => x.WriterUserName), "WriterID", "WriterUserName", selectedWriter);
        }
        [HttpGet]
        public ActionResult Create() { Lists(); return View(new HeadingFormViewModel()); }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(HeadingFormViewModel model)
        {
            if (!ModelState.IsValid || model.WriterID <= 0)
            { if (model.WriterID <= 0) ModelState.AddModelError("WriterID", "Yazar seçiniz."); Lists(model.CategoryID, model.WriterID); return View(model); }
            try { _manager.Add(model.HeadingName, model.CategoryID, model.WriterID); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); Lists(model.CategoryID, model.WriterID); return View(model); }
            TempData["Success"] = "Başlık eklendi."; return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            var h = _manager.GetByID(id.Value); if (h == null) return HttpNotFound();
            Lists(h.CategoryID, h.WriterID);
            return View(new HeadingFormViewModel { HeadingID = h.HeadingID, HeadingName = h.HeadingName, CategoryID = h.CategoryID, WriterID = h.WriterID });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(HeadingFormViewModel model)
        {
            if (model.HeadingID <= 0) return new HttpStatusCodeResult(400);
            if (!ModelState.IsValid) { Lists(model.CategoryID, model.WriterID); return View(model); }
            try { _manager.Update(model.HeadingID, model.HeadingName, model.CategoryID); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); Lists(model.CategoryID, model.WriterID); return View(model); }
            catch (InvalidOperationException) { return HttpNotFound(); }
            TempData["Success"] = "Başlık güncellendi."; return RedirectToAction("Index");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(int id, bool active)
        {
            try { _manager.ChangeStatus(id, active); } catch (InvalidOperationException) { return HttpNotFound(); }
            TempData["Success"] = active ? "Başlık aktifleştirildi." : "Başlık pasife alındı.";
            return RedirectToAction("Index");
        }
    }
}