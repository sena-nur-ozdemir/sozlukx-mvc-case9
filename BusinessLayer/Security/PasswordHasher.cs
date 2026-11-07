using System;
using System.Security.Cryptography;

namespace BusinessLayer.Security
{
    public static class PasswordHasher
    {
        private const int Iterations = 210000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static void HashPassword(
            string password,
            out string passwordHash,
            out string passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Parola boş olamaz.");

            byte[] salt = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                passwordHash =
                    Convert.ToBase64String(pbkdf2.GetBytes(HashSize));

                passwordSalt =
                    Convert.ToBase64String(salt);
            }
        }

        public static bool VerifyPassword(
            string password,
            string storedHash,
            string storedSalt)
        {
            if (string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(storedHash) ||
                string.IsNullOrEmpty(storedSalt))
            {
                return false;
            }

            try
            {
                byte[] salt = Convert.FromBase64String(storedSalt);
                byte[] expected = Convert.FromBase64String(storedHash);

                if (salt.Length != SaltSize ||
                    expected.Length != HashSize)
                {
                    return false;
                }

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    password,
                    salt,
                    Iterations,
                    HashAlgorithmName.SHA256))
                {
                    byte[] actual = pbkdf2.GetBytes(HashSize);

                    int difference = 0;

                    for (int i = 0; i < HashSize; i++)
                    {
                        difference |= actual[i] ^ expected[i];
                    }

                    return difference == 0;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
