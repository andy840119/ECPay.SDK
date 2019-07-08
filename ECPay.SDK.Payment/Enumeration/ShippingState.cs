namespace ECPay.SDK.Payment.Enumeration
{
    /// <summary>
    /// 出貨狀態。
    /// </summary>
    public enum ShippingState
    {
        /// <summary>
        /// 出貨。
        /// </summary>
        Delivery = 5,
        /// <summary>
        /// 取消出貨(當為無貨可出等原因需要取消出貨)。
        /// </summary>
        Cancel = 6
    }
}
