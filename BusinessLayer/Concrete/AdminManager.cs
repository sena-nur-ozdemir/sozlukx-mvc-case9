using System;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Security;

namespace BusinessLayer.Concrete
{
    public class AdminManager
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal
                ?? throw new ArgumentNullException(nameof(adminDal));
        }

        public Admin Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrEmpty(password))
            {
                return null;
            }

            var admin = _adminDal.Get(
                a => a.AdminUserName == username);

            if (admin == null || admin.AdminRole != "Admin")
                return null;

            bool validPassword = PasswordHasher.VerifyPassword(
                password,
                admin.AdminPasswordHash,
                admin.AdminPasswordSalt);

            return validPassword ? admin : null;
        }

        public bool IsAdministrator(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return _adminDal.Get(a =>
                a.AdminUserName == username &&
                a.AdminRole == "Admin") != null;
        }
    }
}
