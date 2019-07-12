using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var queryAllowanceInvalid = new QueryAllowanceInvalid
            {
                //廠商編號。
                MerchantID = "2000132",

                //發票號碼。
                InvoiceNo = "XK00024189",

                //折讓編號。
                AllowanceNo = "2017121415015512"
            };
            
            /***折讓單號忘記了請到後台按列印確認***/

            //2. 執行API的回傳結果
            var response = Client.Post<QueryAllowanceInvalidReturn, QueryAllowanceInvalid>(queryAllowanceInvalid);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //要有時間
            Assert.AreNotEqual("", response.AI_Date);

            //要有時間
            Assert.AreNotEqual("", response.AI_Allow_Date);

            //要有序號
            Assert.AreNotEqual("", response.AI_Allow_No);

            //作廢發票號碼要一樣
            Assert.AreEqual(queryAllowanceInvalid.InvoiceNo, response.AI_Invoice_No);

            //商家號碼要一樣
            Assert.AreEqual(queryAllowanceInvalid.MerchantID, response.AI_Mer_ID);
        }
    }
}
