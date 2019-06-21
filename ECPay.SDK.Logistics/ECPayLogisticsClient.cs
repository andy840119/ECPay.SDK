using ECPay.SDK.Logistics.Models;
using System;
using System.Net;

namespace ECPay.SDK.Logistics
{
    public class ECPayLogisticsClient : BaseClient
    {
        #region Domain

        protected virtual string CVSMAP => RootUrl + "Express/map";
        protected virtual string CreateLogisticsOrder => RootUrl + "Express/Create";
        protected virtual string ReturnHome => RootUrl + "Express/ReturnHome";
        protected virtual string ReturnCVS => RootUrl + "Express/ReturnCVS";
        protected virtual string LogisticsCheckAccoounts => RootUrl + "Helper/LogisticsCheckAccoounts";
        protected virtual string ReturnHiLifeCVS => RootUrl + "Express/ReturnHiLifeCVS";
        protected virtual string UpdateShippingInfo => RootUrl + "Helper/UpdateShipmentInfo";
        protected virtual string UpdateStoreInfo => RootUrl + "Express/UpdateStoreInfo";
        protected virtual string CancelC2COrder => RootUrl + "Express/CancelC2COrder";
        protected virtual string QueryLogisticsTradeInfo => RootUrl + "Helper/QueryLogisticsTradeInfo/V2";
        protected virtual string PrintTradeDoc => RootUrl + "helper/printTradeDocument";
        protected virtual string PrintUniMartC2COrderInfo => RootUrl + "Express/PrintUniMartC2COrderInfo";
        protected virtual string PrintFAMIC2COrderInfo => RootUrl + "Express/PrintFAMIC2COrderInfo";

        #endregion

        #region Fields

        private readonly WebClient _webClient;
        private readonly ECPayLogisticsSettings _settings;

        #endregion

        #region Ctor

        public ECPayLogisticsClient(ECPayLogisticsSettings settings)
        {
            _webClient = new WebClient();

            //Check setting before
            CheckSetting(settings);
            _settings = settings;
        }

        #endregion

        #region Utilities

        protected virtual void CheckSetting(ECPayLogisticsSettings settings)
        {
            if (string.IsNullOrEmpty(settings.MerchantID) || settings.MerchantID.Length > 10)
            {
                throw new Exception("MerchantID can't be null or length > 10!");
            }
            if (string.IsNullOrEmpty(settings.HashKey) || string.IsNullOrEmpty(settings.HashIV))
            {
                throw new Exception("HashKey or HashIV can't be null or empty!");
            }
        }

        protected void ApplySettingToRequest(BaseECPayLogisticsRequest request)
        {
            request.HashKey = _settings.HashKey;
            request.HashIV = _settings.HashIV;
            request.MerchantID = _settings.MerchantID;
        }

        protected virtual T GetData<T>(BaseECPayLogisticsRequest request)
        {
            ApplySettingToRequest(request);

            //TODO : 

            return default(T);
        }

        #endregion

        #region Methods

        public string TestConnection()
        {
            //prepare request
            var request = new BaseECPayLogisticsRequest();

            //get result
            var result = GetData<string>(request);
            return result;
        }

        #endregion
    }
}
