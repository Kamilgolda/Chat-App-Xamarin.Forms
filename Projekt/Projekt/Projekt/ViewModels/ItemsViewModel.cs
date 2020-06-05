using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Projekt.Models;
using Projekt.Views;
using System.IO;

namespace Projekt.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Users> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ImageSource img = "https://image.ceneostatic.pl/data/products/58871271/i-4rooms-obrazek-na-plotnie-panda.jpg";
        public ItemsViewModel()
        {
            Title = "Użytkownicy";
            Items = new ObservableCollection<Users>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //MessagingCenter.Subscribe<RegistrationPage, Users>(this, "AddItem", async (obj, item) =>
            //{
            //    Users newItem = item as Users;
            //    Items.Add(newItem);
            //    await DataStoreUsers.AddItemAsync(newItem);
            //});
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStoreUsers.GetItemsAsync(true);
                foreach (var item in items)
                {
                    if (item.Image != null)
                        item.ImageSource = ImageSource.FromStream(() => new MemoryStream(item.Image));
                    else
                    {
                        item.ImageSource = "user.png";
                    }

                    if (item.IdUser != zalogowany.IdUser)
                    {
                        Items.Add(item);
                    }

                        
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