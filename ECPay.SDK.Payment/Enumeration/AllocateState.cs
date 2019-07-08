namespace ECPay.SDK.Payment.Enumeration
{
    /// <summary>
    /// 撥款狀態。
    /// </summary>
    public enum AllocateState
    {
        /// <summary>
        /// 全部。
        /// </summary>
        ALL = 9,
        /// <summary>
        /// 未撥款。
        /// </summary>
        NoAppropriations = 0,
        /// <summary>
        /// 已撥款。
        /// </summary>
        Appropriations = 1
    }
}
