namespace ECPay.SDK.Payment.Enumeration
{
    /// <summary>
    /// 查詢日期類型。
    /// </summary>
    public enum TradeDateType
    {
        /// <summary>
        /// 付款日期。
        /// </summary>
        Payment = 2,
        /// <summary>
        /// 撥款日期。
        /// </summary>
        Appropriation = 4,
        /// <summary>
        /// 退款日期。
        /// </summary>
        Refund = 5,
        /// <summary>
        /// 訂單日期。
        /// </summary>
        Order = 6
    }
}
