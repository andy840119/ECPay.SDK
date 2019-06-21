using System;

namespace ECPay.SDK
{
    public class BaseClient
    {
        #region Domain

        public virtual string RootUrl
        {
            get
            {
                if (IsDebug == true)
                {
                    return "https://logistics-stage.ecpay.com.tw/";
                }
                else
                {
                    return "https://logistics.ecpay.com.tw/";
                }
            }
        }

        #endregion

        private static bool _isDebug = false;

        /// <summary>是否為Debug</summary>
        /// <remarks>
        /// 當使用IsDebug == true 時，呼叫測試機服務
        /// 當使用IsDebug == false 時，呼叫正式機服務
        /// </remarks>
        public bool IsDebug
        {
            set
            {
                _isDebug = value;
            }
            get
            {
                return _isDebug;
            }
        }
    }
}
