using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminContentController : Controller
    {
        private readonly ContentManager _manager = new ContentManager(new EfContentDal(), new EfHeadingDal(), new EfWriterDal());
        [HttpGet] public ActionResult Index() { return View(_manager.GetAllWithRelations()); }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try { _manager.DeleteAsAdmin(id); } catch (InvalidOperationException) { return HttpNotFound(); }
            TempData["Success"] = "Entry silindi."; return RedirectToAction("Index");
        }
    }
}