using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class InvoiceAllowanceInvalidUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 08.折讓作廢
        /// </summary>
        [TestMethod]
        public void TestInvoiceAllowanceInvalid()
        {
            //1. 設定開立折讓作廢資訊
            var allowanceInvalid = new AllowanceInvalid
            {
                //廠商編號。
                MerchantID = "2000132",

                //發票號碼。
                InvoiceNo = "XK00024189",

                //折讓單號。
                AllowanceNo = "2017121415015512",

                //作廢原因，必填
                Reason = "打錯了"
            };

            //3. 執行API的回傳結果
            var response = Client.Post<AllowanceInvalidReturn, AllowanceInvalid>(allowanceInvalid);

            //因為這是很久以前的訂單，所以已經過期了
            Assert.AreEqual("2000041", response.RtnCode);
        }
    }
}
