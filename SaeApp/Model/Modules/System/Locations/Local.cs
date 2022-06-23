using SQLite;

namespace SaeApp.Model.Modules.System.Locations
{
    public class Local
    {
        [PrimaryKey, AutoIncrement]
        public int IdLocal { get; set; }
        public string Name { get; set; }
        //public Company Company { get; set; }
    }
}
