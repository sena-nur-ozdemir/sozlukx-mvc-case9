using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
namespace BusinessLayer.Concrete
{
    public class ContactManager
    {
        private readonly IContactDal _dal;
        public ContactManager(IContactDal dal) { _dal = dal; }
        public List<Contact> GetList() { return _dal.List().OrderByDescending(x => x.ContactDate).ToList(); }
        public void Send(string name, string email, string subject, string message)
        {
            name = (name ?? "").Trim(); email = (email ?? "").Trim(); subject = (subject ?? "").Trim(); message = (message ?? "").Trim();
            if (name.Length < 2 || name.Length > 80 || email.Length < 5 || email.Length > 100 || !email.Contains("@") || subject.Length < 3 || subject.Length > 150 || message.Length < 10 || message.Length > 3000)
                throw new ArgumentException("İsim, e-posta, konu veya mesaj bilgilerini kontrol edin.");
            _dal.Insert(new Contact { UserName = name, UserMail = email, Subject = subject, Message = message, ContactDate = DateTime.Now });
        }
    }
}