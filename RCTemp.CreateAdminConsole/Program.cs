using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CreateAdminConsole
{
    class Program
    {
        // PBKDF2 parameters (match your AuthHelper if present)
        private const int SaltSize = 64;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        static void Main()
        {
            Console.WriteLine("Create Admin User");
            Console.Write("Username (email): ");
            var username = Console.ReadLine()?.Trim();
            Console.Write("Password: ");
            var password = ReadPassword();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Username and password required.");
                return;
            }

            // create salt + hash
            var salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            var connString = ConfigurationManager.ConnectionStrings["RCTempConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connString))
            {
                Console.WriteLine("Connection string 'RCTempConnection' not found in App.config.");
                return;
            }

            using (var conn = new SqlConnection(connString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
INSERT INTO Users (Username, PasswordHash, PasswordSalt, Role, CreatedDate)
VALUES (@u, @h, @s, @r, GETDATE());";
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 200).Value = username;
                cmd.Parameters.Add("@h", SqlDbType.VarBinary, -1).Value = hash;
                cmd.Parameters.Add("@s", SqlDbType.VarBinary, -1).Value = salt;
                cmd.Parameters.Add("@r", SqlDbType.NVarChar, 50).Value = "Admin";

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Admin user created successfully.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL error: " + ex.Message);
                }
            }
        }

        // simple masked password input
        private static string ReadPassword()
        {
            var pwd = string.Empty;
            ConsoleKeyInfo key;
            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace && pwd.Length > 0)
                {
                    pwd = pwd.Substring(0, pwd.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    pwd += key.KeyChar;
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            return pwd;
        }
    }
}