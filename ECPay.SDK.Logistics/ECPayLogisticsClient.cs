using ECPay.SDK.Logistics.Helpers;
using ECPay.SDK.Logistics.Models;
using ECPay.SDK.Logistics.Validator;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;

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
            if (string.IsNullOrEmpty(settings.MerchantID) || settings.MerchantID.Length > 10)
            {
                throw new Exception("MerchantID can't be null or length > 10!");
            }
            if (string.IsNullOrEmpty(settings.HashKey) || string.IsNullOrEmpty(settings.HashIV))
            {
                throw new Exception("HashKey or HashIV can't be null or empty!");
            }

            _settings = settings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// 把預設結果 轉換成 Dictionary格式
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IDictionary<string, string> ConvertResultToDictionaty(string result)
        {
            var _strData = result.Split('|');

            var Code = "";
            NameValueCollection DictionData = new NameValueCollection();

            if (_strData != null && _strData.Length > 1)
            {
                Code = _strData[0];
                DictionData = HttpUtility.ParseQueryString(_strData[1]);
            }
            else
            {
                DictionData = HttpUtility.ParseQueryString(_strData[0]);
            }
            if (DictionData["LogisticsType"] != null && DictionData["LogisticsType"].Contains('_'))
            {
                var _strValueAry = DictionData["LogisticsType"].Split('_');
                if (_strValueAry.Length > 1)
                {
                    DictionData["LogisticsType"] = _strValueAry[0];
                    DictionData["LogisticsSubType"] = _strValueAry[1];
                }
            }

            //convert to diceionaty
            return DictionData.ToDictionary();
        }

        protected virtual T ConvertResultToObject<T>(string result) 
            where T : class, new()
        {
            var dictionary = ConvertResultToDictionaty(result);

            return dictionary.ToObject<T>();
        }

        protected virtual HttpResponseMessage GetResponse(string url, BaseECPayLogisticsRequest request)
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

            return httpResponse;
        }

        protected virtual Response<T> GetData<T>(string url, BaseECPayLogisticsRequest request, Func<string, T> convert = null)
            where T : class, new()
        {
            var httpResponse = GetResponse(url, request);
            var response = new Response<T>();

            if (httpResponse.IsSuccessStatusCode)
            {
                //Prepare data
                var stringData = httpResponse.Content.ReadAsStringAsync().Result;

                //apply data
                response.Data = convert != null ? convert.Invoke(stringData) : ConvertResultToObject<T>(stringData);
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = httpResponse.Content.ReadAsStringAsync().Result;
            }

            return response;
        }

        protected virtual Response<string> GetData(string url, BaseECPayLogisticsRequest request, Func<string, string> convert = null)
        {
            var httpResponse = GetResponse(url, request);
            var response = new Response<string>();

            if (httpResponse.IsSuccessStatusCode)
            {
                //Prepare data
                var stringData = httpResponse.Content.ReadAsStringAsync().Result;

                //apply data
                response.Data = stringData;
                response.IsSuccess = true;

            }
            else
            {
                response.ErrorMessage = httpResponse.Content.ReadAsStringAsync().Result;
            }

            return response;
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
        public Response<CheckShippingProgressResponse> CheckShippingProgress(string trackingId)
        {
            //prepare request
            var request = new CheckShippingProgressRequest
            {
                AllPayLogisticsID = trackingId,
                PlatformID = "",//保留
            };

            //get result
            var result = GetData<CheckShippingProgressResponse>(QueryLogisticsTradeInfo,request);
            return result;
        }

        public Response<string> GetDisplayMap(DisplayMapRequest request)
        {
            var result = GetData(QueryLogisticsTradeInfo, request);
            return result;
        }

        #endregion
    }
}
