using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.HelperFunc
{
    public static class PasswordHashing
    {
        private static string MD5(this string pass)
        {
            // MD5CryptoServiceProvider instance has been created
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            // Hash calc is done
            // parameter has been converted in to byte series
            byte[] sers = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder sb = new StringBuilder();

            // Every char in the series has been converted in to string type.
            for (int i = 0; i < sers.Length; i++)
            {
                sb.Append(sers[i].ToString("x2"));
            }

            // have returned the hexadecimal string back
            return sb.ToString();
        }

        private static string SHA_1(this string pass)
        {
            SHA1 sha1Hasher = SHA1.Create();
            byte[] sers = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sers.Length; i++)
            {
                sb.Append(sers[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static string Hashing(this string pass)
        {
            pass = pass.SHA_1();
            pass = pass.MD5();
            pass = pass.SHA_1();
            pass = pass.MD5();

            return pass;
        }

        public static string NewPasswordGenerator(int charNumber)
        {
            var chars = "ABCDEGHIKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, charNumber)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray()
                );
            return result;
        }
    }
}
