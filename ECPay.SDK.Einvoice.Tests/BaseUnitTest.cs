using ECPay.SDK.Einvoice.Settings;
using ECPay.SDK.Einvoice.Enums;
using ECPay.SDK.Einvoice.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class BaseUnitTest<T> where T : Iinvoice
    {
        protected ECPayEinvoiceSettings _setting;

        protected ECPayEinvoiceClient<T> _client;

        [TestInitialize]
        public void Initialize()
        {
            //https://www.ecpay.com.tw/Content/files/ecpay_004.pdf
            _setting = new ECPayEinvoiceSettings
            {
                //MerchantID = 2000132
                HashKey = "ejCk326UnaZWKisg",
                HashIV = "q9jcZX8Ib9LM8wYk ",
                Environment = EnvironmentEnum.Stage
            };

            //initialize client
            _client = new ECPayEinvoiceClient<T>(_setting);
        }
    }
}
