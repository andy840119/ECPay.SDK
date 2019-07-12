using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class InvoiceQueryAllowanceUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 11.查詢折讓明細
        /// </summary>
        [TestMethod]
        public void TestInvoiceQueryAllowance()
        {
            //1. 設定開立折讓資訊
            var queryAllowance = new QueryAllowance
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
            var response = Client.Post<QueryAllowanceReturn, QueryAllowance>(queryAllowance);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //要有時間
            Assert.AreNotEqual("", response.IA_Date);

            //要有時間
            Assert.AreNotEqual("", response.IA_Invoice_Issue_Date);

            //要有序號
            Assert.AreNotEqual("", response.IA_Allow_No);

            //作廢發票號碼要一樣
            Assert.AreEqual(queryAllowance.InvoiceNo, response.IA_Invoice_No);

            //商家號碼要一樣
            Assert.AreEqual(queryAllowance.MerchantID, response.IA_Mer_ID);
        }
    }
}
