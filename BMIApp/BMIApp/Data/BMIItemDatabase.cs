using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using BMIApp.Models;

namespace BMIApp.Data
{
    public class BMIItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<BMIItemDatabase> Instance = new AsyncLazy<BMIItemDatabase>(async () =>
        {
            var instance = new BMIItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<BmiItem>();
            return instance;
        });

        public BMIItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<BmiItem>> GetItemsAsync()
        {
            return Database.Table<BmiItem>().ToListAsync();
        }



        public Task<BmiItem> GetItemAsync(int id)
        {
            return Database.Table<BmiItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }


        public Task<int> SaveItemAsync(BmiItem item)
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

    }
}
