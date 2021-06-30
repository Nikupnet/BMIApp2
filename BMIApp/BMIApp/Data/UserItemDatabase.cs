using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using BMIApp.Models;

namespace BMIApp.Data
{
    public class UserItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<UserItemDatabase> Instance = new AsyncLazy<UserItemDatabase>(async () =>
        {
            var instance = new UserItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<UserItem>();

            return instance;
        });

        public UserItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<UserItem>> GetItemsAsync()
        {
            return Database.Table<UserItem>().ToListAsync();
        }



        public Task<UserItem> GetItemAsync(int id)
        {
            return Database.Table<UserItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(UserItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(UserItem item)
        {
            return Database.DeleteAsync(item);
        }


    }
}
