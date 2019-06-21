using ECPay.SDK.Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ECPay.SDK.Logistics.Helpers
{
    public static class ModelHelper
    {
        /// <summary>
        /// See : https://stackoverflow.com/questions/4943817/mapping-object-to-dictionary-and-vice-versa/4944547
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null).ToString()
            );
        }

        public static T ToObject<T>(this IDictionary<string, object> source)
        where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value, null);
            }

            return someObject;
        }
    }
}
