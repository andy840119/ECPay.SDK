using System;

namespace ECPay.SDK.Payment.Attributes
{
    /// <summary>
    /// 標記說此類別是參數的型別
    /// 只能用在類別或屬性上
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    internal class ParamterAttribute : Attribute
    { }
}
