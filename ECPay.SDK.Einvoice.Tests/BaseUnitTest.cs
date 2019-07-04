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
                HashKey = "5294y06JbISpM5x9",
                HashIV = "v77hoKGq4kWxNNIS ",
                Environment = EnvironmentEnum.Stage
            };

            //initialize client
            _client = new ECPayEinvoiceClient<T>(_setting);
        }
    }
}
