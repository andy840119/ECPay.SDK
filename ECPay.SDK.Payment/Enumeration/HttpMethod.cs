namespace ECPay.SDK.Payment.Enumeration
{
    /// <summary>
    /// 傳遞服務的方法。
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// GET。
        /// </summary>
        HttpGET = 0,
        /// <summary>
        /// POST。
        /// </summary>
        HttpPOST = 1,
        /// <summary>
        /// Server POST。
        /// </summary>
        ServerPOST = 2,
        /// <summary>
        /// SOAP(WebService)。
        /// </summary>
        HttpSOAP = 3
    }
}
