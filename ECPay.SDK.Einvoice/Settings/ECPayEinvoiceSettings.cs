using System.ComponentModel.DataAnnotations;
using ECPay.SDK.Einvoice.Enumeration;

namespace ECPay.SDK.Einvoice.Settings
{
    public class ECPayEinvoiceSettings
    {
        /// <summary>
        /// 介接的 HashKey。
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public string HashKey { get; set; }

        /// <summary>
        /// 介接的 HashIV。
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public string HashIV { get; set; }

        /// <summary>
        /// 執行環境
        /// Stage -- 測試
        /// Prod -- 正式
        /// </summary>
        public EnvironmentEnum Environment { get; set; }
    }
}
