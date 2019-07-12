using System;
using ECPay.SDK.Einvoice.Enumeration;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class DelayIssueUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 延遲或觸發開立發票
        /// </summary>
        [TestMethod]
        public void TestDelayIssue()
        {
            //1. 設定觸發或延遲開立發票資訊
            var invoiceDelay = new InvoiceDelay
            {
                //廠商編號
                MerchantID = "2000132",
                //延遲註記
                DelayFlag = DelayFlagEnum.NormalDelay,
                //商家自訂訂單編號
                RelateNumber = "ecPaytest" + new Random().Next(0, 99999),
                //客戶代號
                CustomerID = "",
                //統一編號      
                CustomerIdentifier = "",
                //客戶名稱
                CustomerName = "",
                //客戶地址
                CustomerAddr = "",
                //客戶手機號碼
                CustomerPhone = "0912345678",
                //客戶電子信箱
                CustomerEmail = "test@allpay.com.tw",
                //通關方式
                //ClearanceMark = CustomsClearanceMarkEnum.None,
                //列印註記
                Print = PrintEnum.No,
                //捐贈註記
                Donation = DonationEnum.No,
                //愛心碼
                LoveCode = "930",
                //載具類別
                carruerType = CarruerTypeEnum.PhoneBarcode,
                //載具編號
                //依API說明,把+號換成空白
                CarruerNum = "/6G+X3LQ".Replace('+', ' '),
                //課稅類別
                TaxType = TaxTypeEnum.DutyFree,
                //發票金額。含稅總金額
                SalesAmount = "200",
                //備註
                InvoiceRemark = "",
                //延遲天數
                DelayDay = "5",
                //ECBank 代號
                //ECBankID = "",
                //交易單號
                Tsr = "ecPaytest" + new Random().Next(0, 99999),
                //交易類別
                PayType = PayTypeEnum.ECPAY,
                //開立完成時通知廠商的網址
                //NotifyURL = "",
                //發票字軌類別
                //invType = TheWordTypeEnum.Normal,
                //商品單價是否含稅
                //vat = VatEnum.No
            };

            //2. 商品資訊(Item)的集合類別。
            invoiceDelay.Items.Add(new Item
            {
                ItemName = "1111111",//商品名稱
                ItemPrice = "100",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "100",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });
            invoiceDelay.Items.Add(new Item
            {
                ItemName = "1111111",//商品名稱
                ItemPrice = "100",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "100",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });

            //3. 執行API的回傳結果
            var response = Client.Post<InvoiceDelayReturn, InvoiceDelay>(invoiceDelay);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //交易單號要一樣
            Assert.AreEqual(invoiceDelay.Tsr, response.OrderNumber);
        }
    }
}
