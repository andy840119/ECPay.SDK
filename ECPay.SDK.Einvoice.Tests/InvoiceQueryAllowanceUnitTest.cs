using System;
using System.Collections.Generic;
using System.Text;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class InvoiceQueryAllowanceUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 11.查詢折讓明細
        /// </summary>
        [TestMethod]
        public void TestInvoiceQueryAllowance()
        {
            //1. 設定開立折讓資訊
            QueryAllowance qa = new QueryAllowance();
            qa.MerchantID = "2000132";//廠商編號。
            qa.InvoiceNo = "XK00024189";//發票號碼。
            qa.AllowanceNo = "2017121415015512";//折讓編號。

            //3. 執行API的回傳結果
            var response = Client.Post<QueryAllowanceReturn, QueryAllowance>(qa);

            //TODO : assert

            /***折讓單號忘記了請到後台按列印確認***/
            /*
            //2. 初始化發票Service物件
            Invoice<QueryAllowance> inv = new Invoice<QueryAllowance>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qa);
            //6. 解序列化，還原成物件使用
            QueryAllowanceReturn obj = new QueryAllowanceReturn();
            obj = JsonConvert.DeserializeObject<QueryAllowanceReturn>(json);

            //7.印出結果
            string temp = string.Empty;
            //obj.IA_Allow_No
            //obj.IA_Invoice_No
            //obj.RtnCode
            //obj.RtnMsg

            temp = string.Format("查詢折讓發票<br> IA_Invoice_No={0} <br> RtnCode={1} <br> RtnMsg={2}", obj.IA_Invoice_No, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);
            */
        }
    }
}
