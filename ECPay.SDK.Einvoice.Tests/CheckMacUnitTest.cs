using ECPay.SDK.Einvoice.Enumeration;
using ECPay.SDK.Einvoice.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class CheckMacUnitTest : BaseUnitTest
    {
        protected override ECPayEinvoiceSettings Setting => new ECPayEinvoiceSettings
        {
            //MerchantID = 2000132
            HashKey = "ejCk326UnaZWKisg",
            HashIV = "q9jcZX8Ib9LM8wYk",
            Environment = EnvironmentEnum.Stage
        };

        [TestMethod]
        public void TestCheckMacFunction()
        {
            var param = "CarruerNum=/6G X3LQ&CarruerType=3&ClearanceMark=0&CustomerAddr=%e5%ae%a2%e6%88%b6%e5%9c%b0%e5%9d%80&CustomerEmail=test%40ecpay.com.tw&CustomerID=&CustomerIdentifier=&CustomerName=&CustomerPhone=0912345678&Donation=2&InvCreateDate=&InvoiceRemark=(qwrrg)&InvType=07&ItemAmount=100.1|200&ItemCount=1|1&ItemName=%e7%b3%a7%e9%a3%9f%7c%e7%b3%a7%e9%a3%9f&ItemPrice=100.1|200&ItemTaxType=&ItemWord=%e5%80%8b%7c%e5%80%8b&LoveCode=&MerchantID=2000132&Print=0&RelateNumber=ecPay31189&SalesAmount=300&TaxType=1&TimeStamp=1562235010&vat=1";

            var checkMacValue = Client.BuildCheckMacValue(param);

            Assert.AreEqual("735E83C646BD8EFD61DB2CE6CB45ED70", checkMacValue);
        }
    }
}
