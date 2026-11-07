using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
namespace Case9MvcSozluk.Controllers
{
    [WriterAuthorize]
    public class WriterMessageController : Controller
    {
        private readonly MessageManager _manager = new MessageManager(new EfMessageDal(), new EfWriterDal());
        private int WriterID { get { return int.Parse(User.Identity.Name.Substring(7)); } }
        [HttpGet] public ActionResult Inbox() { return View("List", _manager.Inbox(WriterID)); }
        [HttpGet] public ActionResult Sent() { return View("List", _manager.Sent(WriterID)); }
        [HttpGet] public ActionResult Drafts() { return View("List", _manager.Drafts(WriterID)); }
        [HttpGet] public ActionResult Compose() { return View(new MessageFormViewModel()); }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Compose(MessageFormViewModel model, string operation)
        {
            if (!ModelState.IsValid) return View(model);
            bool draft = string.Equals(operation, "draft", StringComparison.OrdinalIgnoreCase);
            try { _manager.Compose(WriterID, model.Recipient, model.Subject, model.Body, draft); }
            catch (ArgumentException ex) { ModelState.AddModelError("", ex.Message); return View(model); }
            TempData["Success"] = draft ? "Taslak kaydedildi." : "Mesaj gönderildi.";
            return RedirectToAction(draft ? "Drafts" : "Sent");
        }
        [HttpGet]
        public ActionResult Read(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Inbox");
            try { var msg = _manager.Read(WriterID, id.Value); if (msg == null) return HttpNotFound(); return View(msg); }
            catch (UnauthorizedAccessException) { return new HttpStatusCodeResult(403); }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SendDraft(int id)
        {
            try { _manager.SendDraft(WriterID, id); }
            catch (InvalidOperationException) { return HttpNotFound(); }
            catch (UnauthorizedAccessException) { return new HttpStatusCodeResult(403); }
            catch (ArgumentException ex) { TempData["Error"] = ex.Message; return RedirectToAction("Drafts"); }
            TempData["Success"] = "Taslak gönderildi."; return RedirectToAction("Sent");
        }
    }
}