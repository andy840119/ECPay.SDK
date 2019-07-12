using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Einvoice.Helpers
{
    public static class JsonHelper
    {
        public static bool IsJson(String str)
        {
            bool result = false;
            try
            {
                Object obj = JObject.Parse(str);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }
}