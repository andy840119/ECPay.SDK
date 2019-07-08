using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Enums
{
    public enum ScheduledDeliveryTimeType
    {
        /// <summary>
        /// 不限時(4)
        /// </summary>
        TIME_UNLIMITED,

        /// <summary>
        /// 13前
        /// </summary>
        TIME_0_13,

        /// <summary>
        /// 14~18
        /// </summary>
        TIME_14_18
    }
}
