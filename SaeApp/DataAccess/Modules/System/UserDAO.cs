using SaeApp.Model.Modules.System.Security;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaeApp.DataAccess.Modules.System
{
    public class UserDAO
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<UserDAO> Instance = new AsyncLazy<UserDAO>(async () =>
        {
            var instance = new UserDAO();
            CreateTableResult result = await Database.CreateTableAsync<User>();
            return instance;
        });

        public UserDAO()
        {
            Database = new SQLiteAsyncConnection(DBConn.DatabasePath, DBConn.Flags);
        }

        public Task<List<User>> GetItemsAsync()
        {
            return Database.Table<User>().ToListAsync();
        }

        public Task<User> GetItemAsync(int id)
        {
            return Database.Table<User>().Where(i => i.IdUser == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(User item)
        {
            if (item.IdUser != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(User item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<User> LoginUserAsync(string login, string pass)
        {
            return Database.Table<User>().Where(x => x.Login == login && x.Password == pass).FirstOrDefaultAsync();
        }
    }
}
