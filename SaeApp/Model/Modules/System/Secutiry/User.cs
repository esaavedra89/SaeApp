using SQLite;

namespace SaeApp.Model.Modules.System.Security
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int IdLocal { get; set; }

    }
}
