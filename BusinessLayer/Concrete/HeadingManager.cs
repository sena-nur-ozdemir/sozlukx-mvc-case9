using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
    public class HeadingManager
    {
        private readonly IHeadingDal _headings;
        private readonly ICategoryDal _categories;
        private readonly IWriterDal _writers;
        public HeadingManager(IHeadingDal headings, ICategoryDal categories, IWriterDal writers)
        {
            _headings = headings; _categories = categories; _writers = writers;
        }
        public List<Heading> GetAll() { return _headings.ListWithRelations().OrderByDescending(h => h.HeadingID).ToList(); }
        public List<Heading> GetPublic()
        {
            return _headings.ListWithRelations().Where(h => h.HeadingStatus && h.Category != null && h.Category.CategoryStatus && h.Writer != null && h.Writer.WriterStatus)
                .OrderByDescending(h => h.HeadingID).ToList();
        }
        public Heading GetByID(int id) { return _headings.GetByID(id); }
        public Heading Add(string title, int categoryId, int writerId)
        {
            title = NormalizeTitle(title);
            ValidateCategory(categoryId);
            var writer = _writers.GetByID(writerId);
            if (writer == null || !writer.WriterStatus) throw new ArgumentException("Aktif yazar bulunamadı.");
            // Bir başlık ismi sözlükte tek olsun; case-insensitive kontrol.
            if (_headings.List(h => h.HeadingName == title).Any() ||
                _headings.List().Any(h => string.Equals(h.HeadingName, title, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Bu başlık zaten bulunuyor.");
            var heading = new Heading
            {
                HeadingName = title,
                CategoryID = categoryId,
                WriterID = writerId,
                HeadingDate = DateTime.Now,
                HeadingStatus = true
            };
            _headings.Insert(heading);
            return heading;
        }
        public void Update(int id, string title, int categoryId)
        {
            title = NormalizeTitle(title);
            ValidateCategory(categoryId);
            var existing = _headings.GetByID(id);
            if (existing == null) throw new InvalidOperationException("Başlık bulunamadı.");
            if (_headings.List().Any(h => h.HeadingID != id && string.Equals(h.HeadingName, title, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("Bu başlık adı zaten kullanılıyor.");
            existing.HeadingName = title; existing.CategoryID = categoryId;
            _headings.Update(existing);
        }
        public void ChangeStatus(int id, bool active)
        {
            var heading = _headings.GetByID(id);
            if (heading == null) throw new InvalidOperationException("Başlık bulunamadı.");
            heading.HeadingStatus = active;
            _headings.Update(heading);
        }
        private void ValidateCategory(int id)
        {
            var category = _categories.GetByID(id);
            if (category == null || !category.CategoryStatus) throw new ArgumentException("Aktif kategori seçmelisiniz.");
        }
        private static string NormalizeTitle(string name)
        {
            name = (name ?? "").Trim();
            if (name.Length < 3 || name.Length > 150) throw new ArgumentException("Başlık 3–150 karakter olmalıdır.");
            return name;
        }
    }
}