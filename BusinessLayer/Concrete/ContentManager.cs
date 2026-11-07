using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
    public class ContentManager
    {
        private readonly IContentDal _contents;
        private readonly IHeadingDal _headings;
        private readonly IWriterDal _writers;
        public ContentManager(IContentDal contents, IHeadingDal headings, IWriterDal writers)
        { _contents = contents; _headings = headings; _writers = writers; }
        public List<Content> GetAllWithRelations() { return _contents.ListWithRelations().OrderByDescending(x => x.ContentDate).ToList(); }
        public Content GetByID(int id) { return _contents.GetByID(id); }
        public void Add(int headingId, int writerId, string value)
        {
            value = Normalize(value);
            var heading = _headings.ListWithRelations().FirstOrDefault(h => h.HeadingID == headingId);
            if (heading == null || !heading.HeadingStatus || heading.Category == null || !heading.Category.CategoryStatus || heading.Writer == null || !heading.Writer.WriterStatus)
                throw new ArgumentException("Kullanılabilir bir başlık bulunamadı.");
            var writer = _writers.GetByID(writerId);
            if (writer == null || !writer.WriterStatus) throw new ArgumentException("Aktif yazar bulunamadı.");
            _contents.Insert(new Content { HeadingID = headingId, WriterID = writerId, ContentValue = value, ContentDate = DateTime.Now });
        }
        public void UpdateOwn(int id, int writerId, string value)
        {
            value = Normalize(value);
            var current = _contents.GetByID(id);
            if (current == null) throw new InvalidOperationException("Entry bulunamadı.");
            if (current.WriterID != writerId) throw new UnauthorizedAccessException("Bu entry sana ait değil.");
            current.ContentValue = value;
            _contents.Update(current);
        }
        public void DeleteOwn(int id, int writerId)
        {
            var current = _contents.GetByID(id);
            if (current == null) throw new InvalidOperationException("Entry bulunamadı.");
            if (current.WriterID != writerId) throw new UnauthorizedAccessException("Bu entry sana ait değil.");
            _contents.Delete(current);
        }
        public void DeleteAsAdmin(int id)
        {
            var item = _contents.GetByID(id);
            if (item == null) throw new InvalidOperationException("Entry bulunamadı.");
            _contents.Delete(item);
        }
        private static string Normalize(string text)
        {
            text = (text ?? "").Trim();
            if (text.Length < 5 || text.Length > 5000) throw new ArgumentException("Entry 5–5000 karakter olmalıdır.");
            return text;
        }
    }
}