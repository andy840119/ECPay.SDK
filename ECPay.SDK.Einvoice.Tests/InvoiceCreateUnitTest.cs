using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ECPay.SDK.Einvoice.Enumeration;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class InvoiceCreateUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 一般開立發票
        /// </summary>
        [TestMethod]
        public void TestInvoiceCreate()
        {
            //1. 設定開立發票資訊
            var invoice = new InvoiceCreate
            {
                //廠商編號。
                MerchantID = "2000132",
                //商家自訂訂單編號
                RelateNumber = "ecPay" + new Random().Next(0, 99999),
                //客戶代號
                CustomerID = "",
                //統一編號
                CustomerIdentifier = "",
                //客戶名稱
                CustomerName = "",
                //客戶地址
                CustomerAddr = "客戶地址",
                //客戶手機號碼
                CustomerPhone = "0912345678",
                //客戶電子信箱
                CustomerEmail = "test@ecpay.com.tw",
                //通關方式
                //ClearanceMark = CustomsClearanceMarkEnum.None;
                //列印註記
                Print = PrintEnum.No,
                //捐贈註記
                Donation = DonationEnum.No,
                //愛心碼
                LoveCode = "",
                //載具類別
                carruerType = CarruerTypeEnum.PhoneBarcode,
                //依API說明,把+號換成空白
                CarruerNum = "/6G+X3LQ".Replace('+', ' '),
                //課稅類別
                //TaxType = TaxTypeEnum.DutyFree;
                //發票金額。含稅總金額。
                SalesAmount = "300",
                //備註
                InvoiceRemark = "(qwrrg)",
                //發票字軌類別
                invType = TheWordTypeEnum.Normal,
                //商品單價是否含稅
                //vat = VatEnum.No,
            };

            //2. 商品資訊(Item)的集合類別。
            invoice.Items.Add(new Item
            {
                ItemName = "糧食",//商品名稱
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemPrice = "100.1",//商品單價
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
                ItemAmount = "100.1",//總金額
            });
            invoice.Items.Add(new Item
            {
                ItemName = "糧食",//商品名稱
                ItemPrice = "200",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "200",//總金額
                //ItemTaxType = TaxTypeEnum.DutyFree//商品課稅別
            });

            //3. 執行API的回傳結果
            var response = Client.Post<InvoiceCreateReturn, InvoiceCreate>(invoice);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //要有時間
            Assert.AreNotEqual("", response.InvoiceDate);

            //要有號碼
            Assert.AreNotEqual("", response.InvoiceNumber);

            //要有隨機碼
            Assert.AreNotEqual("", response.RandomNumber);
        }
    }
}
