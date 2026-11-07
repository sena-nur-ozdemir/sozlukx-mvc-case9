using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [WriterAuthorize]
    public class WriterProfileController : Controller
    {
        private readonly WriterManager _manager = new WriterManager(new EfWriterDal());
        private int WriterID { get { return int.Parse(User.Identity.Name.Substring(7)); } }
        [HttpGet]
        public ActionResult Index()
        {
            var w = _manager.GetByID(WriterID); if (w == null) return HttpNotFound();
            return View(new WriterProfileViewModel { WriterID = w.WriterID, Name = w.WriterName, Surname = w.WriterSurname, Title = w.WriterTitle, About = w.WriterAbout });
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(WriterProfileViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try { _manager.UpdateProfile(WriterID, model.Name, model.Surname, model.Title, model.About); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); return View(model); }
            TempData["Success"] = "Profil güncellendi."; return RedirectToAction("Index");
        }
    }
}