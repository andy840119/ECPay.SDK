using System;

namespace ECPay.SDK.Einvoice.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    internal class NonProcessValueAttribute : Attribute
    {
        /// <summary>
        /// 完全不處理。
        /// </summary>
        public NonProcessValueAttribute()
            : base()
        {
        }
    }
}