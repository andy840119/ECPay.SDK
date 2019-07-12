namespace ECPay.SDK.Einvoice.Models
{
    /// <summary>
    /// 手機條碼驗證 回傳
    /// </summary>
    public class MobileBarcodeReturn : ReturnBase
    {
        /// <summary>
        /// 手機條碼是否存在
        /// </summary>
        public string IsExist { get; set; }

        /// <summary>
        /// MacValue
        /// </summary>
        public string CheckMacValue { get; set; }
    }
}
