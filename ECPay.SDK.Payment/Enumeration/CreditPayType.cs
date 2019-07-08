using ECPay.SDK.Payment.Attributes;

namespace ECPay.SDK.Payment.Enumeration
{
    public enum CreditPayType
    {
        /// <summary>
        /// 沒有
        /// </summary>
        None,
        /// <summary>
        /// 一次付清
        /// </summary>
        CreditPayOff,
        /// <summary>
        /// 分期付款
        /// </summary>
        CreditInstallment,
        /// <summary>
        /// 定期定額
        /// </summary>
        CreditRSP
    }

    /// <summary>
    /// 電子發票啟用狀態(預設不啟用)
    /// </summary>
    public enum EInvoiceType
    {
        /// <summary>
        /// 不使用電子發票
        /// </summary>
        [Text(Name = "N")]
        None,
        /// <summary>
        /// 使用電子發票
        /// </summary>
        [Text(Name = "Y")]
        Use
    }
}
