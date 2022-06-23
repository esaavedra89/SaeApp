using SaeApp.Model.Modules.Inventory;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaeApp.DataAccess.Modules.Inventory
{
    public class ItemDAO
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ItemDAO> Instance = new AsyncLazy<ItemDAO>(async () =>
        {
            var instance = new ItemDAO();
            CreateTableResult result = await Database.CreateTableAsync<Item>();
            return instance;
        });

        public ItemDAO()
        {
            Database = new SQLiteAsyncConnection(DBConn.DatabasePath, DBConn.Flags);
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return Database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(int idItem)
        {
            return Database.Table<Item>().Where(i => i.IdItem == idItem).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.IdItem > 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
