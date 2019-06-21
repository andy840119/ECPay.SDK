using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Models
{
    public class CheckShippingProgressRequest : BaseECPayLogisticsRequest
    {
        public string AllPayLogisticsID { get; set; }

        public string PlatformID { get; set; }
    }
}
