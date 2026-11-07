using System.Linq;
using System.Web.Mvc;
using Case9MvcSozluk.Filters;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminReportsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var cats = new CategoryManager(new EfCategoryDal()).GetList();
            var writers = new WriterManager(new EfWriterDal()).GetList();
            var headings = new HeadingManager(new EfHeadingDal(), new EfCategoryDal(), new EfWriterDal()).GetAll();
            var entries = new ContentManager(new EfContentDal(), new EfHeadingDal(), new EfWriterDal()).GetAllWithRelations();
            var contacts = new ContactManager(new EfContactDal()).GetList();
            ViewBag.TotalCategories = cats.Count; ViewBag.ActiveCategories = cats.Count(x => x.CategoryStatus);
            ViewBag.Writers = writers.Count; ViewBag.ActiveWriters = writers.Count(x => x.WriterStatus);
            ViewBag.Headings = headings.Count; ViewBag.ActiveHeadings = headings.Count(x => x.HeadingStatus);
            ViewBag.Entries = entries.Count; ViewBag.Contacts = contacts.Count;
            return View();
        }
    }
}