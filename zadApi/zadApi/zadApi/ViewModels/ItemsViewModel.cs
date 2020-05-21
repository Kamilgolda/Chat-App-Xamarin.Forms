using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using zadApi.Models;
using zadApi.Views;

namespace zadApi.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Student> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Lista studentów";
            Items = new ObservableCollection<Student>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Student>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Student;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<ItemDetailPage, Student>(this, "UpdateItem", async (obj, item) =>
            {
                var newItem = item as Student;
            // Items.Add(newItem);
            foreach (Student s in Items)
                {
                    if(s.Id==newItem.Id)
                    {
                        s.Imie = newItem.Imie;
                        s.Nazwisko = newItem.Nazwisko;
                        s.NrAlbumu = newItem.NrAlbumu;
                        s.Plec = newItem.Plec;
                    }
                }
                await DataStore.UpdateItemAsync(newItem);
            });

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                 var items = await DataStore.GetItemsAsync(true);
               // var items = await DataStore.GetStudentsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}