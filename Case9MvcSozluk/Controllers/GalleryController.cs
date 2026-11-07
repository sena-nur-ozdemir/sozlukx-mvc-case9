using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    public class GalleryController : Controller
    {
        private readonly GalleryManager _manager = new GalleryManager(new EfImageFileDal());
        [HttpGet] public ActionResult Index() { return View(_manager.GetList()); }
    }
}