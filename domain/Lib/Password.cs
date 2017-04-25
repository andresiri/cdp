using System;
using System.Security.Cryptography;
using System.Text;

namespace domain.Lib
{
    public class Password
    {
        public static string Hash(string password, string salt)
        {
            var bytes = new UTF8Encoding().GetBytes(password + salt);
            byte[] hashBytes;

            using (var algorithm = SHA512.Create())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
    }
}