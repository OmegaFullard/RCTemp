using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;



namespace RCTemp
{
    public static class AuthHelper
    {
        private const int SaltSize = 64; // bytes
        private const int HashSize = 32; // bytes
        private const int Iterations = 10000;

        public static void CreateHash(string password, out byte[] hash, out byte[] salt)
        {
            salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }
        }

        public static bool VerifyHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, Iterations))
            {
                var computed = pbkdf2.GetBytes(HashSize);
                return AreEqual(storedHash, computed);
            }
        }

        private static bool AreEqual(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            var diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}