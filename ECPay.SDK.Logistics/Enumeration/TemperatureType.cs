using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Enums
{
    /// <summary>
    /// 溫層
    /// </summary>
    public enum TemperatureType
    {
        /// <summary>
        /// 常溫(0001)
        /// </summary>
        ROOM,

        /// <summary>
        /// 冷藏(0002)
        /// </summary>
        REFRIGERATION,

        /// <summary>
        /// 冷凍(0003)
        /// </summary>
        FREEZE
    }
}
