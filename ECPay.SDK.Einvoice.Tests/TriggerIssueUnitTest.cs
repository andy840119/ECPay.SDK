﻿using System;
using System.Collections.Generic;
using System.Text;
using ECPay.SDK.Einvoice.Enumeration;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class TriggerIssueUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 14.付款完成觸發或延遲開立發票
        /// </summary>
        [TestMethod]
        public void TestTriggerIssue()
        {
            //1. 設定付款完成觸發或延遲開立發票資訊
            InvoiceTrigger invt = new InvoiceTrigger();
            invt.MerchantID = "2000132";//廠商編號
            invt.Tsr = "ecPaytest3409";//交易單號
            invt.PayType = PayTypeEnum.ECPAY;//交易類別
            //2. 初始化發票Service物件

            //3. 執行API的回傳結果
            var response = Client.Post<InvoiceTriggerReturn, InvoiceTrigger>(invt);

            //TODO : assert

            /*
            Invoice<InvoiceTrigger> inv = new Invoice<InvoiceTrigger>();
            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = Ecpay.EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;
            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";
            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invt);
            //6. 解序列化，還原成物件使用
            InvoiceTriggerReturn obj = new InvoiceTriggerReturn();
            obj = JsonConvert.DeserializeObject<InvoiceTriggerReturn>(json);
            //資料顯示
            string temp = string.Empty;
            //obj.Tsr
            temp = string.Format("付款完成觸發或延遲開立發票結果:<br> Tsr = {0} <br> RtnCode={1} <br> RtnMsg={2}", obj.Tsr, obj.RtnCode, obj.RtnMsg);
            Response.Write(temp);
            */
        }
    }
}
