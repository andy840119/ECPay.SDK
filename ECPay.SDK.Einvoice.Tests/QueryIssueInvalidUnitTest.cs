using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class QueryIssueInvalidUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 10.查詢作廢發票
        /// </summary>
        [TestMethod]
        public void TestQueryIssueInvalid()
        {
            //1. 設定發票作廢資訊
            QueryInvoiceInvalid queryInvoiceInvalid = new QueryInvoiceInvalid
            {
                //廠商編號。
                MerchantID = "2000132",

                //商家自訂訂單編號。
                RelateNumber = "bffb2f1952564c32973c139b8b1925"
            };

            //2. 執行API的回傳結果
            var response = Client.Post<QueryInvoiceInvalidReturn, QueryInvoiceInvalid>(queryInvoiceInvalid);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //廠商編號 要相同
            Assert.AreEqual(queryInvoiceInvalid.MerchantID, response.II_Mer_ID);

            //要有時間
            Assert.AreNotEqual("", response.II_Date);

            //要有買家ID
            Assert.AreNotEqual("", response.II_Buyer_Identifier);

            //要有賣家ID
            Assert.AreNotEqual("", response.II_Seller_Identifier);
        }
    }
}
