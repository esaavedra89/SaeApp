using SaeApp.Model.Modules.Inventory;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaeApp.DataAccess.Modules.Inventory
{
    public class BrandDAO
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<BrandDAO> Instance = new AsyncLazy<BrandDAO>(async () =>
        {
            var instance = new BrandDAO();
            CreateTableResult result = await Database.CreateTableAsync<Brand>();
            return instance;
        });

        public BrandDAO()
        {
            Database = new SQLiteAsyncConnection(DBConn.DatabasePath, DBConn.Flags);
        }

        public Task<List<Brand>> GetItemsAsync()
        {
            return Database.Table<Brand>().ToListAsync();
        }

        public Task<Brand> GetItemAsync(int id)
        {
            return Database.Table<Brand>().Where(i => i.IdBrand == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Brand item)
        {
            if (item.IdBrand > 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Brand item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
