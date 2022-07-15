
namespace SaeApp.Model.Modules.Inventory
{
    public class InventoryMovementMotive
    {
        public const int INVENTORY_MOVEMENT_MOTIVE_ADJUSTMENT = 1;
        public const int INVENTORY_MOVEMENT_MOTIVE_INVENTORYCLOSING = 2;
        public const int INVENTORY_MOVEMENT_MOTIVE_PURCHASE = 3;
        public const int INVENTORY_MOVEMENT_MOTIVE_RETURN = 4;
        public const int INVENTORY_MOVEMENT_MOTIVE_DECREASE = 5;
        public const int INVENTORY_MOVEMENT_MOTIVE_TRANSFER = 6;
        public const int INVENTORY_MOVEMENT_MOTIVE_SALE = 7;

        public int IdInventoryMovementMotive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
