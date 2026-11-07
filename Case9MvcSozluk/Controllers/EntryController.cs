using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [WriterAuthorize]
    public class EntryController : Controller
    {
        private readonly ContentManager _manager = new ContentManager(new EfContentDal(), new EfHeadingDal(), new EfWriterDal());
        private int WriterID { get { return int.Parse(User.Identity.Name.Substring(7)); } }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(int HeadingID, string ContentValue)
        {
            try { _manager.Add(HeadingID, WriterID, ContentValue); TempData["Success"] = "Entry kaydedildi."; }
            catch (ArgumentException ex) { TempData["Error"] = ex.Message; }
            return RedirectToAction("Index", "Home", new { id = HeadingID });
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index", "Home");
            var item = _manager.GetByID(id.Value); if (item == null) return HttpNotFound();
            if (item.WriterID != WriterID) return new HttpStatusCodeResult(403);
            return View(new EntryEditViewModel { ContentID = item.ContentID, ContentValue = item.ContentValue });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EntryEditViewModel model)
        {
            var item = _manager.GetByID(model.ContentID); if (item == null) return HttpNotFound();
            if (item.WriterID != WriterID) return new HttpStatusCodeResult(403);
            if (!ModelState.IsValid) return View(model);
            try { _manager.UpdateOwn(model.ContentID, WriterID, model.ContentValue); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); return View(model); }
            TempData["Success"] = "Entry güncellendi."; return RedirectToAction("Index", "Home", new { id = item.HeadingID });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var item = _manager.GetByID(id); if (item == null) return HttpNotFound();
            if (item.WriterID != WriterID) return new HttpStatusCodeResult(403);
            _manager.DeleteOwn(id, WriterID);
            TempData["Success"] = "Entry silindi."; return RedirectToAction("Index", "Home", new { id = item.HeadingID });
        }
    }
}