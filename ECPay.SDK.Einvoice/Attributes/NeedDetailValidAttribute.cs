using System;

namespace ECPay.SDK.Einvoice.Attributes
{
    /// <summary>
    /// 細部驗證標籤
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    public class NeedDetailValidAttribute : Attribute
    {
    }
}