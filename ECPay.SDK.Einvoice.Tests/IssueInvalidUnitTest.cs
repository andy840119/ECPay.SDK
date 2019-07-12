using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class IssueInvalidUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 07.發票作廢
        /// </summary>
        [TestMethod]
        public void TestIssueInvalid()
        {
            //1. 設定發票作廢資訊
            var invoiceInvalid = new InvoiceInvalid
            {
                //廠商編號。
                MerchantID = "2000132",
                //發票號碼。
                InvoiceNumber = "XK00024189",
                //作廢原因。
                Reason = "test"
            };

            //3. 執行API的回傳結果
            var response = Client.Post<InvoiceInvalidReturn, InvoiceInvalid>(invoiceInvalid);

            //TODO : 發票已經過期

            /*
            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //發票要一樣
            Assert.AreEqual(invoiceInvalid.InvoiceNumber, response.InvoiceNumber);
            */
        }
    }
}
