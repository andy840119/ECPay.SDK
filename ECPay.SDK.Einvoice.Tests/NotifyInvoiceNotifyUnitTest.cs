using ECPay.SDK.Einvoice.Enumeration;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class NotifyInvoiceNotifyUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 13.發送通知
        /// </summary>
        [TestMethod]
        public void TestNotifyInvoiceNotify()
        {
            //1. 設定發送通知資訊
            InvoiceNotify invoiceNotify = new InvoiceNotify
            {
                //廠商編號。
                MerchantID = "2000132",
                //發票號碼。
                InvoiceNo = "XK00023301",
                //折讓編號。
                //AllowanceNo = "2016010615502774";
                //發送簡訊號碼。
                Phone = "0912345678",
                //發送電子信箱。
                NotifyMail = "vicky.lan@ecpay.com.tw",
                //發送方式。
                notify = InvoiceNotifyEnum.Email,
                //發送內容類型。 
                invoiceTag = InvoiceTagEnum.Create,
                //發送對象。
                notified = NotifiedObjectEnum.All
            };

            //2. 執行API的回傳結果
            var response = Client.Post<InvoiceNotifyReturn, InvoiceNotify>(invoiceNotify);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //發票要一樣
            Assert.AreEqual(invoiceNotify.MerchantID, response.MerchantID);
        }
    }
}
