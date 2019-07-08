namespace ECPay.SDK.Payment.Enumeration
{
    /// <summary>
    /// 付款狀態。
    /// </summary>
    public enum PaymentState
    {
        /// <summary>
        /// 全部。
        /// </summary>
        ALL = 9,
        /// <summary>
        /// 未付款。
        /// </summary>
        Nonpayment = 0,
        /// <summary>
        /// 已付款。
        /// </summary>
        Paid = 1,
        /// <summary>
        /// 平台商。
        /// </summary>
        Fail = 2
    }
}
