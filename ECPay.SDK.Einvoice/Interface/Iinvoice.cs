using ECPay.SDK.Einvoice.Enumeration;

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