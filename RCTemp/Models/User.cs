using System;

namespace RCTemp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        // Do NOT expose password/salt here in public APIs in real apps
        internal byte[] PasswordHash { get; set; }
        internal byte[] PasswordSalt { get; set; }
    }
}