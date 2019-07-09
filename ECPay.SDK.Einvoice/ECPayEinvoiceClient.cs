using ECPay.SDK.Einvoice.Attributes;
using ECPay.SDK.Einvoice.Helpers;
using ECPay.SDK.Einvoice.Interface;
using ECPay.SDK.Einvoice.Service;
using ECPay.SDK.Einvoice.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ECPay.SDK.Einvoice.Models;
using ECPay.SDK.Helpers;

namespace ECPay.SDK.Einvoice
{
    public class ECPayEinvoiceClient : IDisposable 
    {
        #region Fields

        private readonly ECPayEinvoiceSettings _settings;
        private IApiUrlModel _iapi;
        private string _parameters = string.Empty;

        /// <summary>
        /// 不加入驗證的參數
        /// </summary>
        private string[] IgnoreMacValues = { "CHECKMACVALUE", "ITEMNAME", "ITEMWORD", "REASON", "INVOICEREMARK", "SPECSOURCE", "ITEMREMARK", "POSBARCODE", "QRCODE_LEFT", "QRCODE_RIGHT" };

        #endregion

        #region Ctor

        public ECPayEinvoiceClient(ECPayEinvoiceSettings settings)
        {
            _settings = settings;
            _iapi = new ApiUrlModel();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// 驗證欄位並傳回字串
        /// </summary>
        /// <param name="obj">傳入需驗證的物件</param>
        /// <returns>回傳驗證後訊息</returns>
        private string Validate<T>(T obj)
            where T : Iinvoice
        {
            var result = new StringBuilder();
            var errList = new List<string>();

            errList.AddRange(ServerValidator.Validate(obj));

            if (errList.Count > 0)
            {
                foreach (var item in errList)
                {
                    result.Append(item + " ");
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 產生物件的參數字串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private void ObjectToNameValueCollection<T>(T obj)
            where T : Iinvoice
        {
            Type elemType = obj.GetType();
            string value = string.Empty;
            object attr = null;

            //取出物件的原型
            foreach (PropertyInfo item in elemType.GetProperties(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance)
                //.Where(x => !x.GetCustomAttributes(typeof(NonProcessValueAttribute),true).Any())
                .OrderBy(i => i.Name))
            {
                //如果Attribute有設定不處理就直接跳過
                attr = item.GetCustomAttributes(typeof(NonProcessValueAttribute), true).FirstOrDefault();
                if (attr != null)
                    continue;

                try
                {
                    if (item.PropertyType.IsEnum) //Enum
                    {
                        int enumVlue = (int)Enum.Parse(item.PropertyType, item.GetValue(obj, null).ToString());
                        value = enumVlue.ToString();
                    }
                    else if (item.PropertyType.IsClass && item.PropertyType.IsSerializable) //String
                        value = (string)item.GetValue(obj, null);
                    else if (item.PropertyType.IsValueType && item.PropertyType.IsSerializable && !item.PropertyType.IsEnum) //Int
                        value = item.GetValue(obj, null).ToString();
                    //else if (item.PropertyType.IsGenericType && typeof(ICollection<>).IsAssignableFrom(item.PropertyType.GetGenericTypeDefinition()) ||
                    //        item.PropertyType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>)))
                    //    continue;
                    else //本來要排除 Itemcollection, 不過上面的排除方法太費工, 所以改成找不到的就當作是 Itemcollection
                        continue;
                }
                catch
                {
                    throw new Exception("Failed to set property value for our Foreign Key");
                }

                // 特定 Attribute 不作Encode
                attr = item.GetCustomAttributes(typeof(NeedEncodeAttribute), true).FirstOrDefault();
                if (attr != null)
                    value = HttpUtility.UrlEncode(value);

                if (string.IsNullOrEmpty(_parameters))
                    _parameters = $"{item.Name}={value}";
                else
                    _parameters += $"&{item.Name}={value}";
            }
        }

        /// <summary>
        /// 產生檢查碼。
        /// 並排除不作驗證的字串
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        internal string BuildCheckMacValue(string param)
        {
            //排除不作驗證的字串
            string urlparams = RemoveIgnoreMacValues(param);

            //2. 參數最前面加上 HashKey、最後面加上 HashIV
            var szCheckMacValue = $"HashKey={_settings.HashKey}&{urlparams}&HashIV={_settings.HashIV}";

            //3. 將整串字串進行 URL encode
            //4. 轉為小寫
            szCheckMacValue = HttpUtility.UrlEncode(szCheckMacValue).ToLower();

            //5. 依 URLEncode 轉換表更換字元，在.net環境下不需要實作
            //6. 以 MD5 加密方式來產生雜凑值
            //7. 再轉大寫產生 CheckMacValue
            szCheckMacValue = MD5Encoder.Encrypt(szCheckMacValue);
            //轉換成大寫
            return szCheckMacValue.ToUpper();
        }

        /// <summary>
        /// 驗證回傳字串，並回覆結果字串
        /// </summary>
        /// <param name="returnString"></param>
        /// <returns>Json格式的字串</returns>
        private string validReturnString(string returnString)
        {
            //整理回傳結果
            NameValueCollection nvc = HttpUtility.ParseQueryString(returnString);

            //取出結果及驗證碼
            var rtnCode = nvc["RtnCode"];
            var checkMacValue = nvc["CheckMacValue"];
            //saveLog("結果:" + returnString);

            //回傳成功的資訊, 如果回覆成功就比對驗證碼確認資料正確
            if (rtnCode == "1")
            {
                string returnBuildCheckMacValue = BuildCheckMacValue(returnString);
                //saveLog("自己產生的驗證字串:" + returnBuildCheckMacValue);
                if (checkMacValue != returnBuildCheckMacValue)
                {
                    nvc["RtnCode"] = "1000001";
                    nvc["RtnMsg"] = "計算回傳檢核碼失敗";
                }
            }

            return JsonConvert.SerializeObject(nvc.AllKeys.ToDictionary(x => x, y => nvc[y]));
        }

        /// <summary>
        /// 將輸入的URL String 字串, 排除不加入驗證規則的參數
        /// </summary>
        /// <param name="urlstring"></param>
        /// <returns></returns>
        private string RemoveIgnoreMacValues(string urlstring)
        {
            //Regex regex = new Regex("(?<Key>[^= ]+)\\s*=\\s*\"(?<Value>[^\"]+)\"\\s+");
            string regexExam = @"([^=|^\&]+)\=([^\&]+)?";
            Regex regex = new Regex(regexExam);
            MatchCollection matches = regex.Matches(urlstring);

            NameValueCollection nvc = new NameValueCollection();
            foreach (Match m in matches)
            {
                string[] kv = m.Value.ToString().Split('=');
                string key = kv[0];
                string value = kv[1];
                if (key.ToUpper() == "IIS_CARRUER_NUM") value = value.Replace('+', ' ');
                if (!IgnoreMacValues.Contains(key.ToUpper()))
                    nvc.Add(key, value);
            }
            string param = string.Join("&", nvc.AllKeys.OrderBy(key => key).Select(key => key + "=" + nvc[key]).ToArray());
            return param;
        }

        /// <summary>
        /// 伺服器端傳送參數請求資料。
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="apiURL"></param>
        /// <returns></returns>
        private string ServerPost(string parameters, string apiURL)
        {
            string szResult;
            byte[] byContent = Encoding.UTF8.GetBytes(parameters);

            //saveLog("實際字串:" + parameters);

            WebRequest webRequest = WebRequest.Create(apiURL);
            {
                webRequest.Credentials = CredentialCache.DefaultCredentials;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                // SecurityProtocolType.Tls1.2;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                webRequest.ContentLength = byContent.Length;

                using (Stream oStream = webRequest.GetRequestStream())
                {
                    oStream.Write(byContent, 0, byContent.Length); //Push it out there
                    oStream.Close();
                }

                using (var webResponse = webRequest.GetResponse())
                {
                    using (StreamReader oReader = new StreamReader(webResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        szResult = oReader.ReadToEnd().Trim();
                    }
                    webResponse.Close();
                }
            }

            return szResult;
        }

        /// <summary>
        /// 紀錄參數 DeBug 用
        /// </summary>
        /// <param name="str"></param>
        private void saveLog(string str)
        {
            string fileName = "c://" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder fileContent = new StringBuilder();
            fileContent.Append("QueryString:").Append(str).AppendLine();
            fileContent.Append("Log建立時間:").Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")).AppendLine();
            fileContent.AppendLine();

            File.AppendAllText(fileName, fileContent.ToString());
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 開始執行發票功能, 並取得結果
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Post<T>(T obj)
            where T : Iinvoice
        {
            //清除掉之前的參數
            _parameters = string.Empty;

            //先作驗證
            string Valid = Validate(obj);

            if (!string.IsNullOrEmpty(Valid))
                return Valid;

            //組出傳送字串
            ObjectToNameValueCollection(obj);

            //取出API位置
            ApiUrl url = _iapi.GetList().FirstOrDefault(p => p.invM == obj.invM && p.env == _settings.Environment);

            //作壓碼字串
            string checkMacValue = BuildCheckMacValue(_parameters);

            //組出實際傳送的字串
            string urlString = $"{_parameters}&CheckMacValue={checkMacValue}";

            //執行api功能, 並取得回傳結果
            string result = ServerPost(urlString, url?.apiUrl);

            //回傳
            return validReturnString(result);
        }

        public R  Post<R,T>(T obj)
            where R : ReturnBase 
            where T : Iinvoice
        {
            var result = Post(obj);

            //轉換成json格式
            return JsonConvert.DeserializeObject<R>(result);
        }

        /// <summary>
        /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
        /// </summary>
        public void Dispose()
        {
            GC.Collect();
        }

        #endregion
    }
}
