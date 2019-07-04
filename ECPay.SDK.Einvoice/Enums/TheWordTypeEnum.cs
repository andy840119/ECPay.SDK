using ECPay.SDK.Einvoice.Attributes;

namespace ECPay.SDK.Einvoice.Enums
{
    /// <summary>
    /// 字軌類型。
    /// </summary>
    public enum TheWordTypeEnum : int
    {
        /// <summary>
        /// 一般稅額
        /// </summary>
        [Text("07")]
        Normal = 7,

        /// <summary>
        /// 特種稅額
        /// </summary>
        [Text("08")]
        Special = 8
    }
}