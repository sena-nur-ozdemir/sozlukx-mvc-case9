using System;
using System.Linq;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
    public class AboutManager
    {
        private readonly IAboutDal _dal;
        public AboutManager(IAboutDal dal) { _dal = dal; }
        public About Get() { return _dal.List().OrderBy(x => x.AboutID).FirstOrDefault(); }
        public void Save(string first, string second, string image1, string image2)
        {
            first = (first ?? "").Trim(); second = (second ?? "").Trim(); image1 = (image1 ?? "").Trim(); image2 = (image2 ?? "").Trim();
            if (first.Length < 10 || first.Length > 5000 || second.Length > 5000) throw new ArgumentException("Hakkımızda metni 10–5000 karakter olmalıdır.");
            if (image1.Length > 300 || image2.Length > 300) throw new ArgumentException("Görsel yolu çok uzun.");
            if (!ValidImage(image1) || !ValidImage(image2)) throw new ArgumentException("Görsel yolu https:// veya /Content/ ile başlamalı.");
            var item = Get();
            if (item == null) _dal.Insert(new About { AboutDetails1 = first, AboutDetails2 = second, AboutImage1 = image1, AboutImage2 = image2 });
            else { item.AboutDetails1 = first; item.AboutDetails2 = second; item.AboutImage1 = image1; item.AboutImage2 = image2; _dal.Update(item); }
        }
        private static bool ValidImage(string url) { return url.Length == 0 || url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("/Content/", StringComparison.OrdinalIgnoreCase); }
    }
}