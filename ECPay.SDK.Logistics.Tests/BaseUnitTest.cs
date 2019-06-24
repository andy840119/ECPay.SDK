using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Logistics.Tests
{
    [TestClass]
    public class BaseUnitTest
    {
        protected ECPayLogisticsSettings _setting;

        protected ECPayLogisticsClient _client;

        [TestInitialize]
        public void Initialize()
        {
            //https://www.ecpay.com.tw/Content/files/ecpay_030.pdf
            //目前測試是B2C的部分
            _setting = new ECPayLogisticsSettings
            {
                MerchantID = "2000132",
                HashKey = "5294y06JbISpM5x9",
                HashIV = "v77hoKGq4kWxNNIS "
            };

            //initialize client
            _client = new ECPayLogisticsClient(_setting);
        }
    }
}
