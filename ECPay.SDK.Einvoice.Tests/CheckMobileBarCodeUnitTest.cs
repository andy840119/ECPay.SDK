﻿using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class CheckMobileBarCodeUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 16. 手機條碼驗證
        /// </summary>
        [TestMethod]
        public void TestCheckMobileBarCode()
        {
            //1. 產生條碼物件
            var mobileBarcode = new MobileBarcode
            {
                //廠商編號。
                MerchantID = "2000132",

                //依API說明,把+號換成空白
                BarCode = "/6G+X3LQ".Replace('+', ' ')
            };

            //2. 執行API的回傳結果
            var response = Client.Post<MobileBarcodeReturn, MobileBarcode>(mobileBarcode);

            //表示成功
            Assert.AreEqual("1", response.RtnCode);

            //表示存在
            Assert.AreEqual("Y", response.IsExist);

            //表示存在
            Assert.AreEqual("B12E2D8EBEAEC0EA37173BB65B77150F", response.CheckMacValue);
        }
    }
}
