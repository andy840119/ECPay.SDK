using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Enums
{
    /// <summary>
    /// 物流類型
    /// </summary>
    public enum LogisticsType
    {
        /// <summary>
        /// 超商取貨(CVS)
        /// </summary>
        CVS,

        /// <summary>
        /// 宅配(Home)
        /// </summary>
        HOME
    }

    /// <summary>
    /// 物流子類型
    /// </summary>
    public enum LogisticsSubType
    {
        /// <summary>
        /// 無
        /// </summary>
        None,

        #region Home

        /// <summary>
        /// 黑貓宅配(TCAT)
        /// </summary>
        TCAT,

        /// <summary>
        /// 宅配通(ECAN)
        /// </summary>
        ECAN,

        #endregion

        #region B2C

        /// <summary>
        /// 全家B2C(FAMI)
        /// </summary>
        FAMI,

        /// <summary>
        /// 統一超商B2C(UNIMART)
        /// </summary>
        UNIMART,

        /// <summary>
        /// 全家店到店C2C(FAMIC2C)
        /// </summary>
        FAMIC2C,

        #endregion

        #region C2C

        /// <summary>
        /// 統一超商交貨便店到店C2C(UNIMARTC2C)
        /// </summary>
        UNIMARTC2C,

        /// <summary>
        /// 萊爾富店到店(HILIFEC2C)
        /// </summary>
        HILIFEC2C,

        /// <summary>
        /// 萊爾富物流(B2C)
        /// </summary>
        HILIFE

        #endregion
    }
}
