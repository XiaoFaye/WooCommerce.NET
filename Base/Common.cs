using System;
using System.Security.Cryptography;
using System.Text;

namespace WooCommerceNET.Base
{
    public static class Common
    {
        static Common()
        {
            DebugInfo = new StringBuilder();
        }

        public static StringBuilder DebugInfo { get; set; }

        public static string GetUnixTime(bool micro)
        {
            long unixtime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks;

            if (!micro)
            {
                DebugInfo.AppendLine(unixtime.ToString().Substring(0, 10));
                return unixtime.ToString().Substring(0, 10);
            }

            DebugInfo.AppendLine("0." + unixtime.ToString().Substring(10, 6) + "00 " + unixtime.ToString().Substring(0, 10));

            return "0." + unixtime.ToString().Substring(10, 6) + "00 " + unixtime.ToString().Substring(0, 10);
        }

        public static string GetSHA1(string key, string message)
        {
            var encoding = new ASCIIEncoding();

            byte[] keyBytes = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);

            string Sha1Result = string.Empty;

            using (HMACSHA1 SHA1 = new HMACSHA1(keyBytes))
            {
                var Hashed = SHA1.ComputeHash(messageBytes);
                Sha1Result = Convert.ToBase64String(Hashed);
            }

            return Sha1Result;
        }

        public static string GetSHA256(string key, string message)
        {
            return HMAC_SHA256.HMAC(Encoding.UTF8.GetBytes(message), Encoding.UTF8.GetBytes(key));
            //MacAlgorithmProvider sha256 = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA256");
            //IBuffer contentBuffer = CryptographicBuffer.ConvertStringToBinary(message, BinaryStringEncoding.Utf8);

            //IBuffer keyBuffer = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);
            //var signatureKey = sha256.CreateKey(keyBuffer);

            //IBuffer digest = CryptographicEngine.Sign(signatureKey, contentBuffer);

            //return CryptographicBuffer.EncodeToBase64String(digest);
        }

        public static string GetMD5(string content)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(content));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }
    }
}
