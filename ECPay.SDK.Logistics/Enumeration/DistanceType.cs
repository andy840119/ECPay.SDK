using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Enums
{
    /// <summary>
    /// 距離
    /// </summary>
    public enum DistanceType
    {
        /// <summary>
        /// 同縣市(01)
        /// </summary>
        SAME,

        /// <summary>
        /// 外縣市(02)
        /// </summary>
        OTHER,

        /// <summary>
        /// 離島(03)
        /// </summary>
        ISLAND
    }
}
