using System;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    public class HomeController : Controller
    {
        private readonly HeadingManager _headings = new HeadingManager(new EfHeadingDal(), new EfCategoryDal(), new EfWriterDal());
        private readonly ContentManager _contents = new ContentManager(new EfContentDal(), new EfHeadingDal(), new EfWriterDal());
        private readonly WriterManager _writers = new WriterManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index(int? id)
        {
            var headings = _headings.GetPublic();
            var ids = headings.Select(x => x.HeadingID).ToList();
            var vm = new HomeIndexViewModel
            {
                Headings = headings,
                Entries = _contents.GetAllWithRelations().Where(x => ids.Contains(x.HeadingID) && x.Writer != null && x.Writer.WriterStatus).ToList(),
                SelectedHeadingID = (id.HasValue && ids.Contains(id.Value)) ? id : (headings.Any() ? (int?)headings[0].HeadingID : null)
            };
            if (User.Identity.IsAuthenticated && User.Identity.Name.StartsWith("writer:", StringComparison.Ordinal))
            {
                int writerId;
                if (int.TryParse(User.Identity.Name.Substring(7), out writerId))
                {
                    var w = _writers.GetByID(writerId);
                    if (w != null && w.WriterStatus) { vm.CurrentWriterID = writerId; vm.CurrentWriterName = w.WriterUserName; }
                }
            }
            return View(vm);
        }
        private readonly AboutManager _about = new AboutManager(new EfAboutDal());
        private readonly ContactManager _contact = new ContactManager(new EfContactDal());
        [HttpGet] public ActionResult About() { return View(_about.Get()); }
        [HttpGet] public ActionResult Contact() { return View(new ContactFormViewModel()); }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try { _contact.Send(model.Name, model.Email, model.Subject, model.Message); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); return View(model); }
            TempData["Success"] = "Mesajın alındı, teşekkürler.";
            return RedirectToAction("Contact");
        }
    }
}