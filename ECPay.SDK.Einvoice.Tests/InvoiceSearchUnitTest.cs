using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class InvoiceSearchUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 查詢發票
        /// </summary>
        [TestMethod]
        public void TestInvoiceSearch()
        {
            //1. 準備物件
            var query = new QueryInvoice
            {
                //廠商編號。
                MerchantID = "2000132",
                //商家自訂訂單編號。
                RelateNumber = "ecPay31773",
            };

            //2. 執行API的回傳結果
            var response = Client.Post<QueryInvoiceReturn, QueryInvoice>(query);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //確認是同一個編號
            Assert.AreEqual("ecPay31773",response.IIS_Relate_Number);

            //發票號碼
            Assert.AreEqual("YM00000055", response.IIS_Number);
            
            //總共售價
            Assert.AreEqual("300",response.IIS_Sales_Amount);

            //單一項目價格
            Assert.AreEqual("100|200", response.ItemPrice);

            //隨機碼
            Assert.AreEqual("4988", response.IIS_Random_Number);
        }
    }
}
