namespace ECPay.SDK.Logistics.Settings
{
    public class ECPayLogisticsSettings : IECPayLogisticsSettings
    {
        public string HashKey { get; set; }

        public string HashIV { get; set; }

        public string MerchantID { get; set; }
    }
}
