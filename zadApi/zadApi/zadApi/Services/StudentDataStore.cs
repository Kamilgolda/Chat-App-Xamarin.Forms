using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using zadApi.Models;
using zadApi.Services;
using Xamarin.Essentials;

namespace zadApi.Services
{
    class StudentDataStore :Client,IDataStore<Student>
    {
        IEnumerable<Student> items;
        
        public async Task<Student> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Students/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Student>(json));
            }

            return null;
        }

        //public async Task<IEnumerable<Student>> GetStudentsAsync()
        //{
        //    var url = @"https://192.168.100.4:45455/api/Students";

        //    var response = await client.GetAsync(url);
        //    if(response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<IEnumerable<Student>>(content);

        //      //  var json = await client.GetStringAsync($"api/Students");
        //       // items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Student>>(content));
                
        //    }
        //    // return new List<Student>();
        //    return items;
        //}
        public async Task<IEnumerable<Student>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Students");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Student>>(json));
            }

            return items;
        }

        public async Task<bool> AddItemAsync(Student item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/Students", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if(response.IsSuccessStatusCode)
            return response.IsSuccessStatusCode;
            return false;
        }

        public async Task<bool> UpdateItemAsync(Student item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
   //         var buffer = Encoding.UTF8.GetBytes(serializedItem);
   //         var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync($"api/Students/{item.Id}", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/Students/{id}");

            return response.IsSuccessStatusCode;
        }
       

    }
}
