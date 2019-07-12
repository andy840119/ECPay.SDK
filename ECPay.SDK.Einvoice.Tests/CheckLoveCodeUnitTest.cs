using System;
using System.Collections.Generic;
using System.Text;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class CheckLoveCodeUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 15. 愛心碼驗證
        /// </summary>
        [TestMethod]
        public void TestCheckLoveCodeUnit()
        {
            InvoiceLoveCode qinv = new InvoiceLoveCode();
            qinv.MerchantID = "2000132";//廠商編號。
            qinv.LoveCode = "329580";

            //3. 執行API的回傳結果
            var response = Client.Post(qinv);

            //TODO : convert to class

            //TODO : assert

            /*
            Invoice<InvoiceLoveCode> inv = new Invoice<InvoiceLoveCode>();
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            string json = inv.post(qinv);

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);


            string temp = string.Empty;
            temp = string.Format("結果<br> Data={0} ", values["IsExist"].ToString());
            Response.Write(temp);
            temp = string.Format("結果<br> RtnCode={0} ", values["RtnCode"].ToString());
            Response.Write(temp);
            // temp = string.Format("結果<br> RtnMsg={2} ", values["RtnMsg "].ToString());
            // Response.Write(temp);
            */
        }
    }
}
