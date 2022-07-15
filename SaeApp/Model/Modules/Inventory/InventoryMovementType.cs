

namespace SaeApp.Model.Modules.Inventory
{
    public class InventoryMovementType
    {
        public const int INVENTORY_MOVEMENT_TYPE_IN = 1;
        public const int INVENTORY_MOVEMENT_TYPE_OUT = 2;

        public int IdInventoryMovementType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
