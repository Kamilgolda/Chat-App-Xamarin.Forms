using Projekt.Models;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public Users Item { get; set; }
        
        ItemsViewModel viewModel;
        public RegistrationPage()
        {
            InitializeComponent();
            viewModel = new ItemsViewModel();
            viewModel.LoadItemsCommand.Execute(true);
            Item = new Users
            {
                Name = "",
                LastName = "",
                Email = "",
                Password = "",

            };

            BindingContext = this;
        }

        private async void Zarejestruj_Clicked(object sender, EventArgs e)
        {
           await viewModel.DataStoreUsers.AddItemAsync(Item);
            await Navigation.PopAsync();
        }
    }
}