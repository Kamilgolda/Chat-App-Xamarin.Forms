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
    public class MessagesDataStore : Client
    {
        IEnumerable<Messages> items;

        public MessagesDataStore()
        {
            items = new List<Messages>();
        }

        public async Task<IEnumerable<Messages>> GetItemsAsync(int idsender,int idreceiver)
        {
            if (idsender!=null && idreceiver!=null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Messages/"+idsender+"/"+idreceiver);
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Messages>>(json));
            }

            return items;
        }

        public async Task<Messages> GetItemAsync(int id)
        {
            if (IsConnected)
            {
                var json = await client.GetStringAsync($"api/Users/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Messages>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Messages item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/Messages", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return response.IsSuccessStatusCode;
            return false;
        }

        public async Task<bool> UpdateItemAsync(Messages item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            //var buffer = Encoding.UTF8.GetBytes(serializedItem);
            //var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync($"api/Messages", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

    //    public async Task<bool> DeleteItemAsync(int id)
    //    {
    //        if (!IsConnected)
    //            return false;

    //        var response = await client.DeleteAsync($"api/Messages/{id}");

    //        return response.IsSuccessStatusCode;
    //    }
    }
}
