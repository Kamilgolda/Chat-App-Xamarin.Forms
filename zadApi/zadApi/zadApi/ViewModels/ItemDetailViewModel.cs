using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using zadApi.Models;

namespace zadApi.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Student Item { get; set; }
        
        
        public ItemDetailViewModel(Student item = null)
        {
            Title = item?.Imie + " " + item?.Nazwisko;
            Item = item;

        }
       //public async Task PutItem()
       // {
       //     IsBusy = true;

       //     try
       //     {
                
       //         await DataStore.UpdateItemAsync(Item);
       //         // var items = await DataStore.GetStudentsAsync();
       //         //foreach (var item in items)
       //         //{
       //         //    Items.Add(item);
       //         //}
       //     }
       //     catch (Exception ex)
       //     {
       //         Debug.WriteLine(ex);
       //     }
       //     finally
       //     {
       //         IsBusy = false;
       //     }
       // }

    }
}
