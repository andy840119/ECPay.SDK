using System;
using System.Collections.Generic;
using System.Text;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class CheckMobileBarCodeUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 16. 手機條碼驗證
        /// </summary>
        [TestMethod]
        public void TestCheckMobileBarCode()
        {
            MobileBarcode qinv = new MobileBarcode();

            qinv.MerchantID = "2000132";//廠商編號。
            qinv.BarCode = "/6G+X3LQ";
            qinv.BarCode = qinv.BarCode.Replace('+', ' '); //依API說明,把+號換成空白

            //3. 執行API的回傳結果
            var response = Client.Post(qinv);

            //TODO : convert to class

            //TODO : assert

            /*
             
            Invoice<MobileBarcode> inv = new Invoice<MobileBarcode>();

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
            */
        }
    }
}
