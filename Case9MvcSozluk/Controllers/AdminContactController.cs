using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminContactController : Controller
    {
        private readonly ContactManager _manager = new ContactManager(new EfContactDal());
        [HttpGet] public ActionResult Index() { return View(_manager.GetList()); }
    }
}