using System;
using System.Linq;
using BusinessLayer.Security;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterAccountManager
    {
        private readonly IWriterDal _writerDal;
        public WriterAccountManager(IWriterDal writerDal)
        {
            _writerDal = writerDal ?? throw new ArgumentNullException(nameof(writerDal));
        }

        public Writer Authenticate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrEmpty(password)) return null;
            var key = userName.Trim().ToLowerInvariant();
            var writer = _writerDal.Get(w => w.WriterUserName.ToLower() == key && w.WriterStatus);
            if (writer == null) return null;
            return PasswordHasher.VerifyPassword(password, writer.WriterPasswordHash, writer.WriterPasswordSalt)
                ? writer : null;
        }

        public Writer Register(string name, string surname, string userName, string email, string password)
        {
            name = (name ?? "").Trim();
            surname = (surname ?? "").Trim();
            userName = (userName ?? "").Trim();
            email = (email ?? "").Trim();
            if (name.Length < 2 || name.Length > 80 || surname.Length < 2 || surname.Length > 80)
                throw new ArgumentException("Ad ve soyad 2–80 karakter olmalıdır.");
            if (userName.Length < 3 || userName.Length > 50)
                throw new ArgumentException("Kullanıcı adı 3–50 karakter olmalıdır.");
            if (email.Length < 5 || email.Length > 100 || !email.Contains("@"))
                throw new ArgumentException("Geçerli bir e-posta adresi giriniz.");
            if (string.IsNullOrEmpty(password) || password.Length < 12)
                throw new ArgumentException("Parola en az 12 karakter olmalıdır.");

            var userKey = userName.ToLowerInvariant();
            var mailKey = email.ToLowerInvariant();
            if (_writerDal.List(w => w.WriterUserName.ToLower() == userKey).Any())
                throw new ArgumentException("Bu kullanıcı adı zaten kullanılıyor.");
            if (_writerDal.List(w => w.WriterMail.ToLower() == mailKey).Any())
                throw new ArgumentException("Bu e-posta adresi zaten kayıtlı.");

            string hash, salt;
            PasswordHasher.HashPassword(password, out hash, out salt);
            var writer = new Writer
            {
                WriterName = name,
                WriterSurname = surname,
                WriterUserName = userName,
                WriterMail = email,
                WriterPasswordHash = hash,
                WriterPasswordSalt = salt,
                WriterTitle = "SözlükX Yazarı",
                WriterStatus = true
            };
            _writerDal.Insert(writer);
            return writer;
        }
    }
}
