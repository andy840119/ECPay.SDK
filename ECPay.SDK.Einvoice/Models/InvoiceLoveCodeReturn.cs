namespace ECPay.SDK.Einvoice.Models
{
    /// <summary>
    /// 愛心碼 回傳
    /// </summary>
    public class InvoiceLoveCodeReturn : ReturnBase
    {
        /// <summary>
        /// 愛心碼是否存在
        /// </summary>
        public string IsExist { get; set; }

        /// <summary>
        /// MacValue
        /// </summary>
        public string CheckMacValue { get; set; }
    }
}
