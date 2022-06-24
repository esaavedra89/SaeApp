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
            try
            {
                return Database.Table<Item>().ToListAsync();
            }
            catch (global::System.Exception exc)
            {
                throw exc;
            }
        }

        public Task<Item> GetItemAsync(int idItem, int idCompany)
        {
            try
            {
                return Database.Table<Item>().Where(i => i.IdItem == idItem && i.IdCompany == idCompany).FirstOrDefaultAsync();
            }
            catch (global::System.Exception exc)
            {
                throw exc;
            }
        }

        public Task<Item> GetItemAsync(string code, int idCompany)
        {
            try
            {
                return Database.Table<Item>().Where(i => i.Internalcode == code && i.IdCompany == idCompany).FirstOrDefaultAsync();
            }
            catch (global::System.Exception exc)
            {
                throw exc;
            }
        }

        public Task<int> SaveItemAsync(Item item)
        {
            try
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
            catch (global::System.Exception exc)
            {
                throw exc;
            }
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            try
            {
                return Database.DeleteAsync(item);
            }
            catch (global::System.Exception exc)
            {
                throw exc;
            }
        }
    }
}
