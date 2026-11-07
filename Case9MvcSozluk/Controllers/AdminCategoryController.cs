using System;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using Case9MvcSozluk.Filters;
using Case9MvcSozluk.Models;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;

namespace Case9MvcSozluk.Controllers
{
    [AdminAuthorize]
    public class AdminCategoryController : Controller
    {
        private readonly CategoryManager _categoryManager =
            new CategoryManager(new EfCategoryDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View(_categoryManager.GetList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CategoryFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _categoryManager.CategoryAdd(new Category
                {
                    CategoryName = model.CategoryName,
                    CategoryDescription = model.CategoryDescription
                });

                TempData["Success"] = "Kategori eklendi.";
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var category = _categoryManager.GetByID(id.Value);

            if (category == null)
                return HttpNotFound();

            return View(new CategoryFormViewModel
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.CategoryID <= 0)
                return new HttpStatusCodeResult(400);

            if (_categoryManager.GetByID(model.CategoryID) == null)
                return HttpNotFound();

            try
            {
                _categoryManager.CategoryUpdate(new Category
                {
                    CategoryID = model.CategoryID,
                    CategoryName = model.CategoryName,
                    CategoryDescription = model.CategoryDescription
                });

                TempData["Success"] = "Kategori güncellendi.";
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deactivate(int id)
        {
            if (_categoryManager.GetByID(id) == null)
                return HttpNotFound();

            _categoryManager.CategoryDelete(id);

            TempData["Success"] = "Kategori pasife alındı.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Activate(int id)
        {
            if (_categoryManager.GetByID(id) == null)
                return HttpNotFound();

            _categoryManager.CategoryActivate(id);

            TempData["Success"] = "Kategori aktifleştirildi.";
            return RedirectToAction("Index");
        }
    }
}
