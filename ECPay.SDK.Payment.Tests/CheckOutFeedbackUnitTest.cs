using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ECPay.Payment.Integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECPay.SDK.Payment.Tests
{
    [TestClass]
    public class CheckOutFeedbackUnitTest : BaseUnitTest
    {
        /// <summary>
        /// 5.2.1
        /// 一般付款結果通知
        /// </summary>
        [TestMethod]
        public void TestCheckOutFeedback5_2_1()
        {
            List<string> enErrors = new List<string>();
            Hashtable htFeedback = null;
            try
            {

                using (AllInOne oPayment = new AllInOne())
                {
                    oPayment.HashKey = "5294y06JbISpM5x9"; //ECPay 提供的 HashKey
                    oPayment.HashIV = "v77hoKGq4kWxNNIS"; //ECPay 提供的 HashIV
                    /* 取回付款結果 */
                    enErrors.AddRange(oPayment.CheckOutFeedback(ref htFeedback));
                }

                // 取回所有資料
                if (enErrors.Count() == 0)
                {
                    /* 支付後的回傳的基本參數 */
                    string szMerchantID = String.Empty;
                    string szMerchantTradeNo = String.Empty;
                    string szPaymentDate = String.Empty;
                    string szPaymentType = String.Empty;
                    string szPaymentTypeChargeFee = String.Empty;
                    string szRtnCode = String.Empty;
                    string szRtnMsg = String.Empty;
                    string szSimulatePaid = String.Empty;
                    string szTradeAmt = String.Empty;
                    string szTradeDate = String.Empty;
                    string szTradeNo = String.Empty;
                    // 取得資料
                    foreach (string szKey in htFeedback.Keys)
                    {
                        switch (szKey)
                        {
                            /* 支付後的回傳的基本參數 */
                            case "MerchantID":
                                szMerchantID = htFeedback[szKey].ToString();
                                break;
                            case "MerchantTradeNo":
                                szMerchantTradeNo = htFeedback[szKey].ToString();
                                break;
                            case "PaymentDate":
                                szPaymentDate = htFeedback[szKey].ToString();
                                break;
                            case "PaymentType":
                                szPaymentType = htFeedback[szKey].ToString();
                                break;
                            case "PaymentTypeChargeFee":
                                szPaymentTypeChargeFee = htFeedback[szKey].ToString();
                                break;
                            case "RtnCode":
                                szRtnCode = htFeedback[szKey].ToString();
                                break;
                            case "RtnMsg":
                                szRtnMsg = htFeedback[szKey].ToString();
                                break;
                            case "SimulatePaid":
                                szSimulatePaid = htFeedback[szKey].ToString();
                                break;
                            case "TradeAmt":
                                szTradeAmt = htFeedback[szKey].ToString();
                                break;
                            case "TradeDate":
                                szTradeDate = htFeedback[szKey].ToString();
                                break;
                            case "TradeNo":
                                szTradeNo = htFeedback[szKey].ToString();
                                break;
                            default: break;
                        }
                    }
                }
                else
                {
                    // 其他資料處理。
                }
            }
            catch (Exception ex)
            {
                // 例外錯誤處理。
                enErrors.Add(ex.Message);
            }
            finally
            {
                //TODO : doing some test with error
                var errors = String.Format("0|{0}", String.Join("\\r\\n", enErrors));
            }
        }

        /// <summary>
        /// 5.2.4
        /// Credit定期定額授權成功通知
        /// </summary>
        [TestMethod]
        public void TestCheckOutFeedback5_2_4()
        {
            List<string> enErrors = new List<string>();
            Hashtable htFeedback = null;

            try
            {
                using (AllInOne oPayment = new AllInOne())
                {
                    oPayment.HashKey = "";//ECPay 提供的 HashKey
                    oPayment.HashIV = "";//ECPay 提供的 HashIV
                                         /* 取回付款結果 */
                    enErrors.AddRange(oPayment.CheckOutFeedback(ref htFeedback));
                }
                // 取回所有資料
                if (enErrors.Count() == 0)
                {
                    /* 支付後的回傳的基本參數 */
                    string szMerchantID = String.Empty;
                    string szMerchantTradeNo = String.Empty;
                    string szRtnCode = String.Empty;
                    string szRtnMsg = String.Empty;
                    /* 使用定期定額交易時，回傳的額外參數 */
                    string szPeriodType = String.Empty;
                    string szFrequency = String.Empty;
                    string szExecTimes = String.Empty;
                    string szAmount = String.Empty;
                    string szGwsr = String.Empty;
                    string szProcessDate = String.Empty;
                    string szAuthCode = String.Empty;
                    string szFirstAuthAmount = String.Empty;
                    string szTotalSuccessTimes = String.Empty;
                    // 取得資料於畫面
                    foreach (string szKey in htFeedback.Keys)
                    {
                        switch (szKey)
                        {
                            /* 使用定期定額交易時回傳的參數 */
                            case "MerchantID": szMerchantID = htFeedback[szKey].ToString(); break;
                            case "MerchantTradeNo":
                                szMerchantTradeNo = htFeedback[szKey].ToString();
                                break;
                            case "RtnCode": szRtnCode = htFeedback[szKey].ToString(); break;
                            case "RtnMsg": szRtnMsg = htFeedback[szKey].ToString(); break;
                            case "PeriodType": szPeriodType = htFeedback[szKey].ToString(); break;
                            case "Frequency": szFrequency = htFeedback[szKey].ToString(); break;
                            case "ExecTimes": szExecTimes = htFeedback[szKey].ToString(); break;
                            case "Amount": szAmount = htFeedback[szKey].ToString(); break;
                            case "Gwsr": szGwsr = htFeedback[szKey].ToString(); break;
                            case "ProcessDate": szProcessDate = htFeedback[szKey].ToString(); break;
                            case "AuthCode": szAuthCode = htFeedback[szKey].ToString(); break;
                            case "FirstAuthAmount":
                                szFirstAuthAmount = htFeedback[szKey].ToString();
                                break;
                            case "TotalSuccessTimes":
                                szTotalSuccessTimes = htFeedback[szKey].ToString();
                                break;
                            default: break;
                        }
                    }
                    // 其他資料處理。

                }
                else
                {
                    // 其他資料處理。

                }
            }
            catch (Exception ex)
            {
                enErrors.Add(ex.Message);
            }
            finally
            {
                //TODO : doing with errors
            }
        }
    }
}
