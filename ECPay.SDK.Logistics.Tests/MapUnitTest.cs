using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Tests
{
    /// <summary>
    /// 電子地圖
    /// </summary>
    [TestClass]
    public class MapUnitTest : BaseUnitTest
    {
        [TestMethod]
        public void TestMap()
        {
            var result = _client.TestConnection();
        }
    }
}
