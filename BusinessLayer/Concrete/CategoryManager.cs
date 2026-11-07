using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal
                ?? throw new ArgumentNullException(nameof(categoryDal));
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public List<Category> GetActiveList()
        {
            return _categoryDal.List(c => c.CategoryStatus);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public void CategoryAdd(Category category)
        {
            ValidateCategory(category);

            EnsureUniqueName(category);

            category.CategoryStatus = true;
            _categoryDal.Insert(category);
        }

        public void CategoryUpdate(Category category)
        {
            ValidateCategory(category);

            var current = _categoryDal.GetByID(category.CategoryID);

            if (current == null)
                throw new InvalidOperationException(
                    "Kategori bulunamadı.");

            EnsureUniqueName(category);
            current.CategoryName = category.CategoryName;
            current.CategoryDescription = category.CategoryDescription;

            _categoryDal.Update(current);
        }

        public void CategoryDelete(int id)
        {
            ChangeStatus(id, false);
        }

        public void CategoryActivate(int id)
        {
            ChangeStatus(id, true);
        }

        private void ChangeStatus(int id, bool isActive)
        {
            var current = _categoryDal.GetByID(id);

            if (current == null)
                throw new InvalidOperationException(
                    "Kategori bulunamadı.");

            current.CategoryStatus = isActive;
            _categoryDal.Update(current);
        }

        private void EnsureUniqueName(Category category)
        {
            var normalized = category.CategoryName.Trim();
            bool exists = _categoryDal.List().Any(c =>
                c.CategoryID != category.CategoryID &&
                string.Equals((c.CategoryName ?? "").Trim(), normalized,
                    StringComparison.OrdinalIgnoreCase));
            if (exists)
                throw new ArgumentException("Bu kategori adı zaten kullanılıyor.");
        }

        private static void ValidateCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            string name = category.CategoryName?.Trim();

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Kategori adı boş olamaz.");

            if (name.Length > 50)
                throw new ArgumentException(
                    "Kategori adı en fazla 50 karakter olabilir.");

            string description =
                category.CategoryDescription?.Trim();

            if (description != null && description.Length > 250)
                throw new ArgumentException(
                    "Kategori açıklaması en fazla 250 karakter olabilir.");

            category.CategoryName = name;
            category.CategoryDescription = description;
        }
    }
}
