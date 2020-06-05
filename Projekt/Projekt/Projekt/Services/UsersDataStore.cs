using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Projekt.Models;

namespace Projekt.Services
{
    public class UsersDataStore : Client,IDataStore<Users>
    {
        IEnumerable<Users> items;

        public UsersDataStore()
        {
            items = new List<Users>();
        }

        public async Task<IEnumerable<Users>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Users");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Users>>(json));
            }

            return items;
        }

        public async Task<Users> GetItemAsync(int id)
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync($"api/Users/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Users>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Users item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/Users", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return response.IsSuccessStatusCode;
            return false;
        }

        public async Task<bool> UpdateItemAsync(Users item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            //var buffer = Encoding.UTF8.GetBytes(serializedItem);
            //var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync($"api/Users", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            if (!IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/Users/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
