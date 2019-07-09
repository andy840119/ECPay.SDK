using System.ServiceModel;

namespace ECPay.SDK.Payment.WCF
{
    [ServiceContract(Namespace = "http://Payment.allpay.com.tw/")]
    internal interface IAllPayService
    {
        [OperationContract(Name = "QueryTrade", Action = "http://Payment.allpay.com.tw/QueryTrade", ReplyAction = "*")]
        string QueryTrade(string MerchantID, string XmlData);
        [OperationContract(Name = "QueryTradeInfo", Action = "http://Payment.allpay.com.tw/QueryTradeInfo", ReplyAction = "*")]
        string QueryTradeInfo(string MerchantID, string MerchantTradeNo, int TimeStamp, string CheckMacValue);
    }
}
