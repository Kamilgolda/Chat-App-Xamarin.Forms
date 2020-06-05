using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using zadApi.Models;

namespace zadApi.ViewModels
{
   public class CovidViewModel :BaseViewModel 
    {
        public ObservableCollection<Rows> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

       public CovidViewModel()
        {
            Items = new ObservableCollection<Rows>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            
            try
            {
                Items.Clear();

                var items = await CovidStore.GetItemsAsync(true);

                foreach (var item in items)
                {
                   

                    Items.Add(item);
                }

            }
            catch (TargetInvocationException ex)
            {
                Debug.WriteLine(ex);
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
