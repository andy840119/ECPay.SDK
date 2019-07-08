# ECPay.SDK.Einvoice

[![NuGet](https://img.shields.io/nuget/v/ECPay.SDK.Einvoice.svg)](https://www.nuget.org/packages/ECPay.SDK.Einvoice)
[![NuGet](https://img.shields.io/nuget/dt/ECPay.SDK.Einvoice.svg)](https://www.nuget.org/packages/ECPay.SDK.Einvoice)

ECPay開立發票用的套件

## 套件連結

[Nuget](https://www.nuget.org/packages/ECPay.SDK.Einvoice)

## 範例

開立發票 :

```csharp

//1. 準備發票
var invc = new InvoiceCreate
{
    //範例測試商家代碼
    MerchantID = "2000132",
    //other property
};

//2. 在發票中加上商品資訊
invc.Items.Add(new Item
{
    ItemName = "糧食",//商品名稱
    ItemCount = "1",//商品數量
    ItemWord = "個",//單位
    ItemPrice = "100.1",//商品單價
    ItemAmount = "100.1",//總金額
});

//3. 設定
var setting = new ECPayEinvoiceSettings
{
    //範例測試序號
    //MerchantID = 2000132
    HashKey = "ejCk326UnaZWKisg",
    HashIV = "q9jcZX8Ib9LM8wYk",
    Environment = EnvironmentEnum.Stage
}

//4. 建立Client
var client = new ECPayLogisticsClient(setting);

//5. 從Client中取得結果
var result = client.Post<InvoiceCreateReturn, InvoiceCreate>(invc);

//6. 如果回傳代碼是1，表示成功
Assert.AreEqual("1", obj.RtnCode);

```

更多範例可以查看單元測試

## 單元測試

[ECPay.SDK.Einvoice.Tests](../ECPay.SDK.Einvoice.Tests)

## 官網

https://www.ecpay.com.tw/Service/API_Dwnld

## 官方說明文件

https://www.ecpay.com.tw/Content/files/ecpay_004.pdf

## 官方SDK

https://github.com/ECPay/Invoice_Net

