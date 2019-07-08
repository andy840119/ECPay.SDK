namespace ECPay.SDK.Payment.Metadata
{
    /// <summary>
    /// 履約保證介接參數的類別。
    /// </summary>
    public partial class AllInEscrowMetadata
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
