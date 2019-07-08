//using System.Linq.Expressions;

namespace ECPay.SDK.Payment.Metadata
{
    /// <summary>
    /// 全功能介接參數的類別。
    /// </summary>
    public partial class AllInOneMetadata
    {
        /// <summary>
        /// 介接訂單查詢的資料傳遞成員類別。
        /// </summary>
        public new class QueryArguments : CommonMetadata.QueryArguments
        {
            /// <summary>
            /// 介接訂單查詢的資料建構式。
            /// </summary>
            public QueryArguments() : base()
            {
            }
        }
    }
}
