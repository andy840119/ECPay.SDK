using System;
using System.Collections.Generic;
using System.Text;
using ECPay.SDK.Einvoice.Enumeration;
using ECPay.SDK.Einvoice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ECPay.SDK.Einvoice.Tests
{
    [TestClass]
    public class DelayIssueUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 延遲或觸發開立發票
        /// </summary>
        [TestMethod]
        public void TestDelayIssue()
        {
            //1. 設定觸發或延遲開立發票資訊
            InvoiceDelay invc = new InvoiceDelay();
            invc.MerchantID = "2000132";//廠商編號
            invc.DelayFlag = DelayFlagEnum.NormalDelay;//延遲註記
            invc.RelateNumber = "ecPaytest" + new Random().Next(0, 99999).ToString();//商家自訂訂單編號
            invc.CustomerID = "";//客戶代號
            invc.CustomerIdentifier = "";//統一編號            
            invc.CustomerName = "";//客戶名稱
            invc.CustomerAddr = "";//客戶地址
            invc.CustomerPhone = "0912345678";//客戶手機號碼
            invc.CustomerEmail = "test@allpay.com.tw";//客戶電子信箱
            //invc.ClearanceMark = CustomsClearanceMarkEnum.None;//通關方式
            invc.Print = PrintEnum.No;//列印註記
            invc.Donation = DonationEnum.No;//捐贈註記
            //invc.LoveCode = "930";//愛心碼
            invc.carruerType = CarruerTypeEnum.PhoneBarcode;//載具類別
            invc.CarruerNum = "/6G+X3LQ";//載具編號
            invc.CarruerNum = invc.CarruerNum.Replace('+', ' '); //依API說明,把+號換成空白
            invc.TaxType = TaxTypeEnum.DutyFree;//課稅類別
            invc.SalesAmount = "200";//發票金額。含稅總金額
            invc.InvoiceRemark = "";//備註
            invc.DelayDay = "0";//延遲天數
            //invc.ECBankID = "";//ECBank 代號          
            invc.Tsr = "ecPaytest" + new Random().Next(0, 99999).ToString();//交易單號
            invc.PayType = PayTypeEnum.ECPAY;//交易類別
            //invc.NotifyURL = "";//開立完成時通知廠商的網址
            //invc.invType = TheWordTypeEnum.Normal;//發票字軌類別
            //invc.vat = VatEnum.No;//商品單價是否含稅

            //商品資訊(Item)的集合類別。
            invc.Items.Add(new Item()
            {
                ItemName = "1111111",//商品名稱
                ItemPrice = "100",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "100",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });
            invc.Items.Add(new Item()
            {
                ItemName = "1111111",//商品名稱
                ItemPrice = "100",//商品單價
                ItemCount = "1",//商品數量
                ItemWord = "個",//單位
                ItemAmount = "100",//總金額
                //ItemTaxType  =TaxTypeEnum.DutyFree//商品課稅別
            });

            
            //5. 執行API的回傳結果(JSON)字串 
            var response = Client.Post<InvoiceCreateReturn, InvoiceDelay>(invc);

            //TODO : check
            /*
            if (check)   //判斷是不是json格式
            {
                //6. 解序列化，還原成物件使用
                InvoiceCreateReturn obj = new InvoiceCreateReturn();

                obj = JsonConvert.DeserializeObject<InvoiceCreateReturn>(json);

                temp = string.Format("開立發票結果<br> InvoiceDate={0}<br> InvoiceNumber={1}<br> RandomNumber={2}<br> RtnCode={3} <br> RtnCode={4} ", obj.InvoiceDate, obj.InvoiceNumber, obj.RandomNumber, obj.RtnCode, obj.RtnMsg);


            }
            else
            {
                temp = json;
            }
            */
        }
    }
}
