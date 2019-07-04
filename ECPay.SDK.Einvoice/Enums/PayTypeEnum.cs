﻿using ECPay.SDK.Einvoice.Attributes;

namespace ECPay.SDK.Einvoice.Enums
{
    /// <summary>
    /// 交易類別
    /// </summary>
    public enum PayTypeEnum : int
    {
        /// <summary>
        /// Allpay
        /// </summary>
        [Text("ALLPAY")]
        ALLPAY = 1,

        /// <summary>
        /// ECPay
        /// </summary>
        [Text("ECPAY")]
        ECPAY = 2,

        
        /// <summary>
        /// ECBank
        /// </summary>
        [Text("ECBANK")]
        ECBANK = 3
    }
}