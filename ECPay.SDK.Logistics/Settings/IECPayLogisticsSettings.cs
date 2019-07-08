namespace ECPay.SDK.Logistics.Settings
{
    public interface IECPayLogisticsSettings
    {
        string HashKey { get; set; }

        string HashIV { get; set; }

        string MerchantID { get; set; }
    }
}
