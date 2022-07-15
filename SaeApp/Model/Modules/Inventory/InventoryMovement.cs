using Newtonsoft.Json;
using SaeApp.Model.Modules.System.Entity;
using SaeApp.Model.Modules.System.Locations;
using SaeApp.Model.Modules.System.Security;
using SQLite;
using System;
using System.Collections.Generic;

namespace SaeApp.Model.Modules.Inventory
{
    public class InventoryMovement
    {
        [PrimaryKey, AutoIncrement]
        public int IdInventoryMovement { get; set; }

        public int IdInventoryMovementType { get; set; }

        public InventoryMovementType InventoryMovementType { get; set; }

        public int Number { get; set; }

        public string NumberInvoice { get; set; }

        public string Comments { get; set; }

        public string Concept { get; set; }

        [Ignore, JsonIgnore]
        public List<InventoryMovementItem> InventoryMovementItemList { get; set; }

        public int IdResponsibleUser { get; set; }

        [Ignore, JsonIgnore]
        public User ResponsibleUser { get; set; }

        public int IdInventoryMovementMotive { get; set; }

        [Ignore, JsonIgnore]
        public List<InventoryMovementMotive> InventoryMovementMotiveList { get; set; }

        public int IdLocal { get; set; }

        [Ignore, JsonIgnore]
        public Local Local { get; set; }

        public int IdStateEntity { get; set; }

        [Ignore, JsonIgnore]
        public StateEntity StateEntity { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public const string DATABASE_TABLE = "InventoryMovement";

    }
}
