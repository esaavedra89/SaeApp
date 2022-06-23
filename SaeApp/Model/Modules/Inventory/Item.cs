using SQLite;
using System;

namespace SaeApp.Model.Modules.Inventory
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int IdItem { get; set; }
        public int IdCompany { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdBrand { get; set; }
        public string Supplier { get; set; }
        public string Internalcode { get; set; }
        public decimal Amount { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public decimal CostPrice { get; set; }
        public decimal ProfitPercentage { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
