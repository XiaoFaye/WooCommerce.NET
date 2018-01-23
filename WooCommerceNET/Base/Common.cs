using System;
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

        public static string GetSHA1(string message)
        {
            SHA1 sha1 = new SHA1(message);
            return sha1.GetHash();
            //HashAlgorithmProvider sha1 = HashAlgorithmProvider.OpenAlgorithm("SHA1");
            //IBuffer vector = CryptographicBuffer.ConvertStringToBinary(message, BinaryStringEncoding.Utf8);
            //IBuffer digest = sha1.HashData(vector);////Hashing The Data 

            //return CryptographicBuffer.EncodeToHexString(digest).ToLower();
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
    }
}
