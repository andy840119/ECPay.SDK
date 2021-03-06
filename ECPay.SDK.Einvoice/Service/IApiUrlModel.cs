﻿using System.Collections.Generic;
using ECPay.SDK.Einvoice.Enumeration;

namespace ECPay.SDK.Einvoice.Service
{
    internal interface IApiUrlModel
    {
        List<ApiUrl> GetList();
    }

    internal class ApiUrl
    {
        /// <summary>
        /// API 的模式
        /// </summary>
        public InvoiceMethodEnum invM { get; set; }

        /// <summary>
        /// API位置
        /// </summary>
        public string apiUrl { get; set; }

        /// <summary>
        /// API環境
        /// </summary>
        public EnvironmentEnum env { get; set; }
    }
}