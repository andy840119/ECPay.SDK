using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using ECPay.SDK.Einvoice.Enumeration;
//using System.Runtime.Caching;
using ECPay.SDK.Einvoice.Interface;
using ECPay.SDK.Einvoice.Resource;

namespace ECPay.SDK.Einvoice.Service
{
    internal class ApiUrlModel : IApiUrlModel
    {
        private string cacheName = "apiList";
        //private ObjectCache cache = MemoryCache.Default;

        public ApiUrlModel()
        {
        }

        public List<ApiUrl> getlist()
        {
            var apiUrls = new List<ApiUrl>();//(List<ApiUrl>)cache.Get(cacheName);
            if (apiUrls == null || !apiUrls.Any())
                apiUrls = GetApiUrls();
            return apiUrls;
        }

        private List<ApiUrl> GetApiUrls()
        {
            ResourceSet resourceSet;
            var list = new List<ApiUrl>();

            resourceSet = ApiUrl_Dev_Resource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                list.Add(
                   new ApiUrl()
                   {
                       apiUrl = entry.Value.ToString(),
                       env = EnvironmentEnum.Dev,
                       invM = (InvoiceMethodEnum)Enum.Parse(typeof(InvoiceMethodEnum), entry.Key.ToString())
                   }
                );
            }

            resourceSet = ApiUrl_Stage_Resource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                list.Add(
                   new ApiUrl()
                   {
                       apiUrl = entry.Value.ToString(),
                       env = EnvironmentEnum.Stage,
                       invM = (InvoiceMethodEnum)Enum.Parse(typeof(InvoiceMethodEnum), entry.Key.ToString())
                   }
                );
            }

            resourceSet = ApiUrl_Prod_Resource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                list.Add(
                   new ApiUrl()
                   {
                       apiUrl = entry.Value.ToString(),
                       env = EnvironmentEnum.Prod,
                       invM = (InvoiceMethodEnum)Enum.Parse(typeof(InvoiceMethodEnum), entry.Key.ToString())
                   }
                );
            }
            //CacheItemPolicy policy = new CacheItemPolicy();
            //policy.AbsoluteExpiration = DateTime.Now.AddHours(12);
            //cache.Set(cacheName, list, policy);

            return list;
        }
    }
}
