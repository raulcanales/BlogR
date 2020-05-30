using System;
using System.Security.Cryptography;
using System.Text;

namespace BlogR.Core.Helpers
{
    internal static class SecurityHelper
    {
        public static string HashString(string value)
        {
            var provider = new SHA1CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(provider.ComputeHash(bytes));
        }

        public static string GenerateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            int max_length = 32;
            byte[] salt = new byte[max_length];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
