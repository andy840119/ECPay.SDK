using System.ComponentModel.DataAnnotations;

namespace ECPay.SDK.Einvoice.Models
{
    /// <summary>
    /// 商品項目。
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 商品名稱。
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        public string ItemName { get; set; }

        /// <summary>
        /// 商品訂購數量。
        /// </summary>
        //[Range(1, int.MaxValue, ErrorMessage = "{0} is out of range. ")]
        public string ItemCount { get; set; }

        /// <summary>
        /// 商品單位(當 InvoiceMark=Yes 時，則必填)
        /// </summary>
        //[RequiredByInvoiceMark(ErrorMessage = "{0} is required.")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(6, ErrorMessage = "{0} max length as {1}.")]
        public string ItemWord { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "{0} is incorrect format.")]
        public string ItemPrice { get; set; }

        /// <summary>
        /// 商品課稅別(當 InvoiceMark=Yes 時，則必填)。
        /// </summary>
        //[RequiredByInvoiceMark(ErrorMessage = "{0} is required.")]
        public string ItemTaxType { get; set; }

        /// <summary>
        /// 商品合計
        /// </summary>
        [Required(ErrorMessage = "{0} is required.")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "{0} is incorrect format.")]
        public string ItemAmount { get; set; }

        /// <summary>
        /// 商品項目的建構式。
        /// </summary>
        public Item()
        {
            //this.ItemTaxType = TaxTypeEnum.Taxable;
        }
    }
}
