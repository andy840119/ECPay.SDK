﻿using System;
using System.Collections.Generic;
using System.Text;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class InvoiceQueryAllowanceInvalidUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 12.查詢折讓作廢明細
        /// </summary>
        [TestMethod]
        public void TestInvoiceQueryAllowanceInvalid()
        {
            //1. 設定開立折讓作廢資訊
            QueryAllowanceInvalid qai = new QueryAllowanceInvalid();
            qai.MerchantID = "2000132";//廠商編號。
            qai.InvoiceNo = "XK00024189";//發票號碼。
            qai.AllowanceNo = "2017121415015512";//折讓編號。
            /***折讓單號忘記了請到後台按列印確認***/

            //3. 執行API的回傳結果
            var response = Client.Post<QueryAllowanceInvalidReturn, QueryAllowanceInvalid>(qai);

            //TODO : assert

            /*
            //2. 初始化發票Service物件
            Invoice<QueryAllowanceInvalid> inv = new Invoice<QueryAllowanceInvalid>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qai);
            //6. 解序列化，還原成物件使用
            QueryAllowanceInvalidReturn obj = new QueryAllowanceInvalidReturn();
            obj = JsonConvert.DeserializeObject<QueryAllowanceInvalidReturn>(json);

            //7.印出結果
            string temp = string.Empty;

            temp = string.Format("查詢折讓發票<br> AI_Allow_No={0} <br> RtnCode={1} <br> RtnMsg={2} <br> Reason={3}", obj.AI_Allow_No, obj.RtnCode, obj.RtnMsg, obj.Reason);
            Response.Write(temp);
            */
        }
    }
}
