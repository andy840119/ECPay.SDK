using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics
{
    public interface IECPayLogisticsSettings
    {
        string HashKey { get; set; }

        string HashIV { get; set; }

        string MerchantID { get; set; }
    }
}
