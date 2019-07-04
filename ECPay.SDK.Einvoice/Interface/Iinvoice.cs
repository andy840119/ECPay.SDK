using ECPay.SDK.Einvoice.Enums;

namespace ECPay.SDK.Einvoice.Interface
{
    /// <summary>
    /// 發票類別
    /// </summary>
    public interface Iinvoice
    {
        InvoiceMethodEnum invM { get; }
    }
}