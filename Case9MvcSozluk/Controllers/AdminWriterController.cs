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
    public class AdminWriterController : Controller
    {
        private readonly WriterManager _manager = new WriterManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index() { return View(_manager.GetList().OrderByDescending(w => w.WriterID).ToList()); }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            var w = _manager.GetByID(id.Value);
            if (w == null) return HttpNotFound();
            return View(new WriterProfileViewModel { WriterID = w.WriterID, Name = w.WriterName, Surname = w.WriterSurname, Title = w.WriterTitle, About = w.WriterAbout });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(WriterProfileViewModel model)
        {
            if (model.WriterID <= 0) return new HttpStatusCodeResult(400);
            if (!ModelState.IsValid) return View(model);
            try { _manager.UpdateProfile(model.WriterID, model.Name, model.Surname, model.Title, model.About); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); return View(model); }
            catch (InvalidOperationException) { return HttpNotFound(); }
            TempData["Success"] = "Yazar güncellendi."; return RedirectToAction("Index");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(int id, bool active)
        {
            try { _manager.ChangeStatus(id, active); } catch (InvalidOperationException) { return HttpNotFound(); }
            TempData["Success"] = active ? "Yazar aktifleştirildi." : "Yazar pasife alındı.";
            return RedirectToAction("Index");
        }
    }
}