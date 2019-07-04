using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace ECPay.SDK.Logistics.Helpers
{
    public static class HttptHelper
    {
        #region Functions

        public static FormUrlEncodedContent ConvertObjectToForm(object source)
        {
            var parameters = ModelHelper.ToDictionary(source);

            return ConvertDictionaryToForm(parameters);
        }

        public static FormUrlEncodedContent ConvertDictionaryToForm(IDictionary<string, string> parameters)
        {
            //Reorder parameters
            var orderedParameters = parameters.OrderBy(kp => kp.Key).ToDictionary(d => d.Key, d => d.Value);

            //Convert to result
            var result = attachCheckMacValue(orderedParameters);

            return result;
        }

        #endregion

        #region private methods

        private static FormUrlEncodedContent attachCheckMacValue(Dictionary<string, string> parameters)
        {
            string strQuery = "";
            //Generate QueryString

            strQuery = toQueryString(parameters);
            var encodedRaw = System.Web.HttpUtility.UrlEncode(strQuery).ToLower();
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = MD5Helper.GetMd5Hash(md5Hash, encodedRaw).ToUpper();

                Console.WriteLine("The MD5 hash of " + encodedRaw + " is: " + hash + ".");

                Console.WriteLine("Verifying the hash...");

                if (MD5Helper.VerifyMd5Hash(md5Hash, encodedRaw, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                    parameters.Add("CheckMacValue", hash);
                    return new FormUrlEncodedContent(parameters);
                }
                else
                {
                    throw new Exception("The hashes are not same.");
                }
            }
            throw new Exception();
        }

        private static string toQueryString(this IDictionary<string, string> dict)
        {
            if (dict.Count == 0) return string.Empty;

            var buffer = new StringBuilder();
            int count = 0;
            bool end = false;

            foreach (var key in dict.Keys)
            {
                if (count == dict.Count - 1) end = true;

                if (end)
                    buffer.AppendFormat("{0}={1}", key, dict[key]);
                else
                    buffer.AppendFormat("{0}={1}&", key, dict[key]);

                count++;
            }

            return buffer.ToString();
        }

        #endregion
    }
}
