using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Models
{
    public class BaseECPayLogisticsRequest : IECPayLogisticsSettings
    {
        public string HashKey { get; set; }

        public string HashIV { get; set; }

        public string MerchantID { get; set; }
    }
}
