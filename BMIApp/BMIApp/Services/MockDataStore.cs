using BMIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMIApp.Services
{
    public class MockDataStore : IDataStore<User>
    {
        readonly List<User> items;

        public MockDataStore()
        {
            items = new List<User>()
            {
                new User { Id = Guid.NewGuid().ToString(), UserName = "First item", Description="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), UserName = "Second item", Description="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), UserName = "Third item", Description="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), UserName = "Fourth item", Description="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), UserName = "Fifth item", Description="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), UserName = "Sixth item", Description="This is an item description." }
            };


        }

        public async Task<bool> AddItemAsync(User item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = items.Where((User arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((User arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}