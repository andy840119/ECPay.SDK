
namespace ECPay.SDK.Einvoice.Models
{
    public class MobileBarcodeReturn : ReturnBase
    {
        public string IsExist { get; set; }

        public string CheckMacValue { get; set; }
    }
}
