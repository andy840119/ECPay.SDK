using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Tests
{
    /// <summary>
    /// 物流訂單
    /// </summary>
    [TestClass]
    public class ShippingUnitTest : BaseUnitTest
    {
        [TestMethod]
        public void TestConnection()
        {
            var result = _client.TestConnection();
        }
    }
}
