using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ECPay.SDK.Einvoice.Enumeration;

namespace ECPay.SDK.Einvoice.Tests
{
    /// <summary>
    /// 開立發票
    /// </summary>
    [TestClass]
    public class InvoiceCreateUnitTest : BaseUnitTest
    {
        [TestMethod]
        public void TestInvoiceCreate()
        {
            //1. 設定開立發票資訊
            InvoiceCreate invc = new InvoiceCreate();
            invc.MerchantID = "2000132";//廠商編號。
            invc.RelateNumber = "ecPay" + new Random().Next(0, 99999).ToString();//商家自訂訂單編號
            invc.CustomerID = "";//客戶代號
            invc.CustomerIdentifier = "";//統一編號
            invc.CustomerName = "";//客戶名稱
            invc.CustomerAddr = "客戶地址";//客戶地址
            invc.CustomerPhone = "0912345678";//客戶手機號碼
            invc.CustomerEmail = "test@ecpay.com.tw";//客戶電子信箱
            //invc.ClearanceMark = CustomsClearanceMarkEnum.None;//通關方式
            invc.Print = PrintEnum.No;//列印註記
            invc.Donation = DonationEnum.No;//捐贈註記
            invc.LoveCode = "";//愛心碼
            invc.carruerType = CarruerTypeEnum.PhoneBarcode;//載具類別
            invc.CarruerNum = "/6G+X3LQ";
            invc.CarruerNum = invc.CarruerNum.Replace('+', ' '); //依API說明,把+號換成空白
            //invc.TaxType = TaxTypeEnum.DutyFree;//課稅類別
            invc.SalesAmount = "300";//發票金額。含稅總金額。
            invc.InvoiceRemark = "(qwrrg)";//備註

            invc.invType = TheWordTypeEnum.Normal;//發票字軌類別
            //invc.vat = VatEnum.No;//商品單價是否含稅

            //2. 商品資訊(Item)的集合類別。
            invc.Items.Add(new Item
            {
                ItemName = "糧食",//商品名稱
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemPrice = "100.1",//商品單價
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
                ItemAmount = "100.1",//總金額
            });
            invc.Items.Add(new Item
            {
                ItemName = "糧食",//商品名稱
                ItemPrice = "200",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "200",//總金額
                //ItemTaxType = TaxTypeEnum.DutyFree//商品課稅別
            });

            //3. 執行API的回傳結果
            var obj = _client.Post<InvoiceCreateReturn, InvoiceCreate>(invc);

            //表示成功
            Assert.AreEqual("1", obj.RtnCode);

            //要有時間
            Assert.AreNotEqual("", obj.InvoiceDate);

            //要有號碼
            Assert.AreNotEqual("", obj.InvoiceNumber);

            //要有隨機碼
            Assert.AreNotEqual("", obj.RandomNumber);
        }
    }
}
