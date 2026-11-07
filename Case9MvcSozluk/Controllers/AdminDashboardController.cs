using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminDashboardController : Controller
    {
        private readonly CategoryManager _categories = new CategoryManager(new EfCategoryDal());
        private readonly WriterManager _writers = new WriterManager(new EfWriterDal());
        private readonly HeadingManager _headings = new HeadingManager(new EfHeadingDal(), new EfCategoryDal(), new EfWriterDal());
        private readonly ContentManager _contents = new ContentManager(new EfContentDal(), new EfHeadingDal(), new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {
            var categories = _categories.GetList();
            ViewBag.TotalCategories = categories.Count;
            ViewBag.ActiveCategories = categories.Count(c => c.CategoryStatus);
            ViewBag.InactiveCategories = categories.Count(c => !c.CategoryStatus);
            ViewBag.WriterCount = _writers.GetList().Count;
            ViewBag.HeadingCount = _headings.GetAll().Count;
            ViewBag.EntryCount = _contents.GetAllWithRelations().Count;
            return View(categories.OrderByDescending(c => c.CategoryID).Take(6).ToList());
        }
    }
}