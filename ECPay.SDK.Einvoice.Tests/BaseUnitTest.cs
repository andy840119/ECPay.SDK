using ECPay.SDK.Einvoice.Settings;
using ECPay.SDK.Einvoice.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class BaseUnitTest
    {
        //https://www.ecpay.com.tw/Content/files/ecpay_004.pdf
        protected virtual ECPayEinvoiceSettings Setting => new ECPayEinvoiceSettings
        {
            //MerchantID = 2000132
            HashKey = "ejCk326UnaZWKisg",
            HashIV = "q9jcZX8Ib9LM8wYk",
            Environment = EnvironmentEnum.Stage
        };

        protected ECPayEinvoiceClient _client;

        [TestInitialize]
        public virtual void Initialize()
        {
            //initialize client
            _client = new ECPayEinvoiceClient(Setting);
        }
    }
}
