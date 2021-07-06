using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.ValidationRules.HelperClass
{
    public static class PasswordHashing
    {
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }



        //private static string MD5(this string pass)
        //{
        //    // MD5CryptoServiceProvider instance has been created
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        //    // Hash calc is done
        //    // parameter has been converted in to byte series
        //    byte[] sers = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
        //    StringBuilder sb = new StringBuilder();

        //    // Every char in the series has been converted in to string type.
        //    for (int i = 0; i < sers.Length; i++)
        //    {
        //        sb.Append(sers[i].ToString("x2"));
        //    }

        //    // have returned the hexadecimal string back
        //    return sb.ToString();
        //}

        //private static string SHA_1(this string pass)
        //{
        //    SHA1 sha1Hasher = SHA1.Create();
        //    byte[] sers = sha1Hasher.ComputeHash(Encoding.Default.GetBytes(pass));
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < sers.Length; i++)
        //    {
        //        sb.Append(sers[i].ToString("x2"));
        //    }

        //    return sb.ToString();
        //}

        //public static string Hashing(this string pass)
        //{
        //    pass = pass.SHA_1();
        //    pass = pass.MD5();
        //    pass = pass.SHA_1();
        //    pass = pass.MD5();

        //    return pass;
        //}


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

        //private static string Key = "adef@@fxcbv@";

        //public static string Encrypt(string pass)
        //{
        //    pass += Key;
        //    var passBytes = Encoding.UTF8.GetBytes(pass);
        //    return Convert.ToBase64String(passBytes);
        //}

        //public static string Decrypt(string base4EcodedData)
        //{
        //    var base4EcodeBytes = Convert.FromBase64String(base4EcodedData);
        //    var result = Encoding.UTF8.GetString(base4EcodeBytes);
        //    result = result.Substring(0, result.Length - Key.Length);
        //    return result;
        //}
    }
}
