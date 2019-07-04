using System;
using System.Collections.Generic;
using System.Text;

namespace ECPay.SDK.Logistics.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }

        public T Data { get; set; }

        public string Code { get; set; }

        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public Exception ErrorException { get; set; }
    }
}
