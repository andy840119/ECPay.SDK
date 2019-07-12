using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class CheckLoveCodeUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 15. 愛心碼驗證
        /// </summary>
        [TestMethod]
        public void TestCheckLoveCodeUnit()
        {
            //1. 建立愛心碼驗證物件
            var invoiceLoveCode = new InvoiceLoveCode
            {
                //廠商編號。
                MerchantID = "2000132",

                //愛心碼
                LoveCode = "329580"
            };

            //2. 執行API的回傳結果
            var response = Client.Post<InvoiceLoveCodeReturn, InvoiceLoveCode>(invoiceLoveCode);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //表示存在
            Assert.AreEqual("Y", response.IsExist);

            Assert.AreEqual("B12E2D8EBEAEC0EA37173BB65B77150F", response.CheckMacValue);
        }
    }
}
