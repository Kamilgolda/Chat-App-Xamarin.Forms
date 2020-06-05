using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using zadApi.Models;

namespace zadApi.Services
{
   public class CovidDataStore:IDataStore<Rows>
    {
        protected HttpClient client;
        string k;
        protected bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public CovidDataStore()
        {
            client = new HttpClient();//GetInsecureHandler());
            client.BaseAddress = new Uri($"{App.CovidUrl}/");
        }

        IEnumerable<Rows> items;

        public async Task<IEnumerable<Rows>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"/api/v1/cases/countries-search?limit=220");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Rows>>(json));
                k = items.ToString();
            }

            return items;
        }

        public Task<bool> AddItemAsync(Rows item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Rows item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Rows> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
