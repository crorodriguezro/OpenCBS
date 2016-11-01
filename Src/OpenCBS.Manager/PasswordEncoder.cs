using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using OpenCBS.CoreDomain;
using BCrypt.Net;
using Microsoft.SqlServer.Server;

namespace OpenCBS.Manager
{
    public class PasswordEncoder
    {

        public static string GeneratePasswordHash(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentException();
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        public static bool Match(User user, string password)
        {
            if (user == null || string.IsNullOrEmpty(password)) return false;
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }


    }
}
