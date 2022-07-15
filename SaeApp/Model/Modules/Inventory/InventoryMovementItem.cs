using Newtonsoft.Json;
using SQLite;

namespace SaeApp.Model.Modules.Inventory
{
    public class InventoryMovementItem
    {
        [PrimaryKey, AutoIncrement]
        public int IdInventoryMovementItem { get; set; }

        public int IdItem { get; set; }

        [Ignore, JsonIgnore]
        public Item Item { get; set; }

        public decimal Amount { get; set; }

        public decimal TotalCost { get; set; }

        public decimal UnitCost { get; set; }

        public int Position { get; set; }

        public const string DATABASE_TABLE   = "InventoryMovementItem";
    }
}
