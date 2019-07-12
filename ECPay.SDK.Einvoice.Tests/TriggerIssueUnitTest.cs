using ECPay.SDK.Einvoice.Enumeration;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class TriggerIssueUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 14.付款完成觸發或延遲開立發票
        /// </summary>
        [TestMethod]
        public void TestTriggerIssue()
        {
            //1. 設定付款完成觸發或延遲開立發票資訊
            InvoiceTrigger invoiceTrigger = new InvoiceTrigger
            {
                //廠商編號
                MerchantID = "2000132",
                //交易單號
                //TODO : 弄上一個存在的交易單號
                Tsr = "ecPaytest3409",
                //交易類別
                PayType = PayTypeEnum.ECPAY
            };

            //2. 執行API的回傳結果
            var response = Client.Post<InvoiceTriggerReturn, InvoiceTrigger>(invoiceTrigger);

            //TODO : 弄上一個存在的交易單號

            //交易單號不存在
            Assert.AreEqual("4000001", response.RtnCode);
        }
    }
}
