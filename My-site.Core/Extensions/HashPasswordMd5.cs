using System.Security.Cryptography;
using System.Text;

namespace My_site.Core.Extensions
{
    public static class HashPasswordMd5
    {
        public static string EncodePasswordMd5(this string password)
        {
            byte[] originalBytes;
            byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = Encoding.Default.GetBytes(password);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
    }
}
