using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using RCTemp.Models;

namespace RCTemp.Repositories
{
    public static class UserRepository
    {
        private const int Pbkdf2Iter = 10000;
        private const int HashSize = 32; // bytes

        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["RCTempConnection"].ConnectionString;

        public static User ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                return null;

            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand("SELECT UserId, Username, PasswordHash, PasswordSalt, Role, IsActive FROM [Users] WHERE Username = @u", conn))
            {
                cmd.Parameters.Add(new SqlParameter("@u", SqlDbType.NVarChar, 256) { Value = username });
                conn.Open();
                using (var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (!rdr.Read()) return null;

                    var user = new User
                    {
                        UserId = rdr.GetInt32(rdr.GetOrdinal("UserId")),
                        Username = rdr.GetString(rdr.GetOrdinal("Username")),
                        Role = rdr.IsDBNull(rdr.GetOrdinal("Role")) ? string.Empty : rdr.GetString(rdr.GetOrdinal("Role")),
                        IsActive = !rdr.IsDBNull(rdr.GetOrdinal("IsActive")) && rdr.GetBoolean(rdr.GetOrdinal("IsActive"))
                    };

                    if (rdr.IsDBNull(rdr.GetOrdinal("PasswordHash")) || rdr.IsDBNull(rdr.GetOrdinal("PasswordSalt")))
                        return null;

                    user.PasswordHash = (byte[])rdr["PasswordHash"];
                    user.PasswordSalt = (byte[])rdr["PasswordSalt"];

                    // verify active
                    if (!user.IsActive) return null;

                    return VerifyPassword(password, user.PasswordSalt, user.PasswordHash) ? user : null;
                }
            }
        }

        public static bool AuthenticateAdmin(string username, string password, out User user)
        {
            user = ValidateUser(username, password);
            if (user == null) return false;
            return (user.Role ?? string.Empty).IndexOf("Admin", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        // Helper: verify PBKDF2 password
        private static bool VerifyPassword(string password, byte[] salt, byte[] expectedHash)
        {
            using (var derive = new Rfc2898DeriveBytes(password, salt, Pbkdf2Iter))
            {
                var computed = derive.GetBytes(HashSize);
                return FixedTimeEquals(computed, expectedHash);
            }
        }

        // Fixed time comparison to avoid timing attacks
        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }

        // (Optional) Helper to create password hash for user provisioning
        public static void CreatePasswordHash(string password, out byte[] salt, out byte[] hash)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                salt = new byte[16];
                rng.GetBytes(salt);
            }
            using (var derive = new Rfc2898DeriveBytes(password, salt, Pbkdf2Iter))
            {
                hash = derive.GetBytes(HashSize);
            }
        }
    }
}