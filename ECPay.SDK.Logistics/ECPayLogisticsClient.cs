using ECPay.SDK.Logistics.Helpers;
using ECPay.SDK.Logistics.Models;
using ECPay.SDK.Logistics.Validator;
using System;
using System.Net;
using System.Net.Http;

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

        private readonly HttpClient _webClient;
        private readonly ECPayLogisticsSettings _settings;

        #endregion

        #region Ctor

        public ECPayLogisticsClient(ECPayLogisticsSettings settings)
        {
            _webClient = new HttpClient();

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

        protected virtual T GetData<T>(string url,BaseECPayLogisticsRequest request)
        {
            ApplySettingToRequest(request);

            //Check parameter valid
            ValidatorChecker.ValidateParameter(request);

            //converto request to form
            var httpContent = HttptHelper.ConvertObjectToForm(request);

            //prepare
            _webClient.BaseAddress = new Uri(url);
            _webClient.DefaultRequestHeaders.Accept.Clear();

            //query
            HttpResponseMessage httpResponse = _webClient.PostAsync("", httpContent).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                response.IsSuccess = true;
                response.Data = httpResponse.Content.ReadAsStringAsync().Result;
            }
            else
            {
                response.ErrorMessage = httpResponse.Content.ReadAsStringAsync().Result;
            }
            

            return default(T);
        }

        protected void ApplySettingToRequest(BaseECPayLogisticsRequest request)
        {
            request.HashKey = _settings.HashKey;
            request.HashIV = _settings.HashIV;
            request.MerchantID = _settings.MerchantID;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 查詢物流訂單
        /// </summary>
        /// <param name="trackingId">綠界科技的物流交易碼</param>
        /// <returns></returns>
        public string CheckShippingProgress(string trackingId)
        {
            //prepare request
            var request = new CheckShippingProgressRequest
            {
                AllPayLogisticsID = trackingId,
                PlatformID = "",//保留
            };

            //get result
            var result = GetData<string>(QueryLogisticsTradeInfo,request);
            return result;
        }

        #endregion
    }
}
