using System;
using System.Collections.Generic;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
    public class WriterManager
    {
        private readonly IWriterDal _writers;
        public WriterManager(IWriterDal writers) { _writers = writers; }
        public List<Writer> GetList() { return _writers.List(); }
        public Writer GetByID(int id) { return _writers.GetByID(id); }
        public void ChangeStatus(int id, bool active)
        {
            var writer = _writers.GetByID(id);
            if (writer == null) throw new InvalidOperationException("Yazar bulunamadı.");
            writer.WriterStatus = active;
            _writers.Update(writer);
        }
        public void UpdateProfile(int id, string name, string surname, string title, string about)
        {
            var writer = _writers.GetByID(id);
            if (writer == null) throw new InvalidOperationException("Yazar bulunamadı.");
            name = (name ?? "").Trim(); surname = (surname ?? "").Trim(); title = (title ?? "").Trim(); about = (about ?? "").Trim();
            if (name.Length < 2 || name.Length > 80 || surname.Length < 2 || surname.Length > 80) throw new ArgumentException("Ad ve soyad 2–80 karakter olmalıdır.");
            if (title.Length > 100 || about.Length > 1000) throw new ArgumentException("Unvan veya açıklama çok uzun.");
            writer.WriterName = name; writer.WriterSurname = surname; writer.WriterTitle = title; writer.WriterAbout = about;
            _writers.Update(writer);
        }
    }
}