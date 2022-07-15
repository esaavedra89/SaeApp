using SaeApp.Model.Modules.Inventory;
using SaeApp.Model.Modules.System.Finance;
using SQLite;

namespace SaeApp.Model.Modules.Sell
{
    public class InvoiceItem
    {
        [PrimaryKey, AutoIncrement]
        public int IdInvoiceItem { get; set; }
        public int IdInvoice { get; set; }
        public int IdItem { get; set; }
        [Ignore]
        public Item Item { get; set; }
        public string Comments { get; set; }
        public int IdTax { get; set; }
        [Ignore]
        public Tax Tax { get; set; }
        public decimal DiscountAmoun { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPriceWithoutTax { get; set; }
        public decimal UnitPriceWithTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal Total { get; set; }
    }
}
