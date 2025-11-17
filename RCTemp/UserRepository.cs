using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace RCTemp
{
    public class UserRecord
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }

    public static class UserRepository
    {
        private static string Conn => ConfigurationManager.ConnectionStrings["RCTempConnection"].ConnectionString;

        public static UserRecord ValidateUser(string username, string password)
        {
            using (var conn = new SqlConnection(Conn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT UserId, Username, PasswordHash, PasswordSalt, Role FROM Users WHERE Username = @u";
                cmd.Parameters.AddWithValue("@u", username);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read()) return null;
                    var userId = (int)rdr["UserId"];
                    var dbUser = (string)rdr["Username"];
                    var role = (string)rdr["Role"];
                    var hash = (byte[])rdr["PasswordHash"];
                    var salt = (byte[])rdr["PasswordSalt"];
                    if (AuthHelper.VerifyHash(password, hash, salt))
                    {
                        return new UserRecord { UserId = userId, Username = dbUser, Role = role };
                    }
                }
            }
            return null;
        }

        public static void CreateUser(string username, string password, string role = "Admin")
        {
            AuthHelper.CreateHash(password, out var hash, out var salt);
            using (var conn = new SqlConnection(Conn))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Users (Username, PasswordHash, PasswordSalt, Role) VALUES (@u, @h, @s, @r)";
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@h", hash);
                cmd.Parameters.AddWithValue("@s", salt);
                cmd.Parameters.AddWithValue("@r", role);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}