using Newtonsoft.Json;
using System;
using System.Text;

namespace ExpenseManagement.Shared.Helpers
{
    public static class CryptographyHelper
    {
        public static string Base64Encode(string plainText)
        {
            if(string.IsNullOrEmpty(plainText))
                return plainText;

            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData))
                return base64EncodedData;

            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }


        public static string Base64Encode(object obj)
        {
            if (obj == null)
                return string.Empty;
            var plainText = JsonConvert.SerializeObject(obj);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static T Base64Decode<T>(string base64EncodedData)
        {
            T result = default(T);
            if (string.IsNullOrEmpty(base64EncodedData))
                return result;
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            var plaintText = Encoding.UTF8.GetString(base64EncodedBytes);
            result = JsonConvert.DeserializeObject<T>(plaintText);
            return result;
        }
    }
}
