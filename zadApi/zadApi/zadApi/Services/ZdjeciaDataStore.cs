using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using zadApi.Models;

namespace zadApi.Services
{
    class ZdjeciaDataStore : Client, IDataStore<Zdjęcia>
    {
        IEnumerable<Zdjęcia> zdjecia;

        public async Task<bool> AddItemAsync(Zdjęcia item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/Zdjecia", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return response.IsSuccessStatusCode;
            return false;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Zdjęcia> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Zdjecia/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Zdjęcia>(json));
            }
            return null;
        }

        public async Task<IEnumerable<Zdjęcia>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Zdjecia");
                zdjecia = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Zdjęcia>>(json));
            }

            return zdjecia;
        }

        public async Task<bool> UpdateItemAsync(Zdjęcia item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            //         var buffer = Encoding.UTF8.GetBytes(serializedItem);
            //         var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync($"api/Zdjecia/{item.Id}", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}
