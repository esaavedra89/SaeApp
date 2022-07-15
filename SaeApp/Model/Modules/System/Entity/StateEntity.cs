using SQLite;

namespace SaeApp.Model.Modules.System.Entity
{
    public class StateEntity
    {
        [PrimaryKey, AutoIncrement]
        public int IdStateEntity { get; set; }

        public string Name { get; set; }

        public int IdCompany { get; set; }
    }
}
