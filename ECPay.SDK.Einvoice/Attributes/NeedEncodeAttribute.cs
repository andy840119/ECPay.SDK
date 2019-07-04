using System;

namespace ECPay.SDK.Einvoice.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    internal class NeedEncodeAttribute : Attribute
    {
        /// <summary>
        /// 表示不作UrlEncode動作。
        /// </summary>
        public NeedEncodeAttribute()
        {
        }
    }
}