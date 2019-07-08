using System;

namespace ECPay.SDK.Payment.Attributes
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
    public class TextAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
