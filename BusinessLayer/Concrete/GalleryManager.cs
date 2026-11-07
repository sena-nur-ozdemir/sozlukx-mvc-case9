using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
    public class GalleryManager
    {
        private readonly IImageFileDal _dal;
        public GalleryManager(IImageFileDal dal) { _dal = dal; }
        public List<ImageFile> GetList() { return _dal.List().OrderByDescending(x => x.ImageID).ToList(); }
        public void Add(string name, string path)
        {
            name = (name ?? "").Trim(); path = (path ?? "").Trim();
            if (name.Length < 2 || name.Length > 100) throw new ArgumentException("Görsel adı 2–100 karakter olmalıdır.");
            if (path.Length > 300 || !(path.StartsWith("https://", StringComparison.OrdinalIgnoreCase) || path.StartsWith("/Content/", StringComparison.OrdinalIgnoreCase))) throw new ArgumentException("Görsel bağlantısı https:// veya /Content/ ile başlamalı.");
            _dal.Insert(new ImageFile { ImageName = name, ImagePath = path });
        }
        public void Delete(int id) { var img = _dal.GetByID(id); if (img == null) throw new InvalidOperationException("Görsel bulunamadı."); _dal.Delete(img); }
    }
}