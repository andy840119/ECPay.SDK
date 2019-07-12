using System;
using System.Collections.Generic;
using System.Text;
using ECPay.SDK.Einvoice.Enumeration;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class InvoiceAllowanceUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 開立折讓
        /// </summary>
        [TestMethod]
        public void TestInvoiceAllowance()
        {

            //1. 設定開立折讓資訊
            var allowance = new Allowance
            {
                //廠商編號。
                MerchantID = "2000132",

                //發票號碼。
                InvoiceNo = "XW00006065",

                //通知類別
                allowanceNotify = AllowanceNotifyEnum.SMS,

                //客戶名稱
                CustomerName = "客戶名稱",

                //客戶手機號碼
                NotifyPhone = "0912345678",

                //客戶電子信箱
                NotifyMail = "",

                //折讓單總金額(含稅總金額)。
                AllowanceAmount = "10"
            };

            //2. 商品資訊的集合類別
            allowance.Items.Add(new Item
            {
                ItemName = "糧食",//商品名稱
                ItemPrice = "10",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "10",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });

            //3. 執行API的回傳結果
            var response = Client.Post<AllowanceReturn, Allowance>(allowance);

            //TODO : 會因為測試讓金額變得越小

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //要有時間
            Assert.AreNotEqual("", response.IA_Date);

            //折讓單號
            Assert.AreNotEqual("", response.IA_Allow_No);

            //發票號碼要和送出時一樣
            Assert.AreEqual(allowance.InvoiceNo, response.IA_Invoice_No);
        }
    }
}
