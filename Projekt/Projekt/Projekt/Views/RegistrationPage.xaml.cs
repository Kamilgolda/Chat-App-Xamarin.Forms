using Acr.UserDialogs;
using Projekt.Models;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            if(Item.Name=="" || Item.LastName=="" || Item.Email=="" || Item.Password=="" || passwordp.Text=="")
            {
                await UserDialogs.Instance.AlertAsync("Uzupełnij wszystkie pola", "Nie wszystkie pola zostały prawidłowo uzupełnione", "Spróbuj ponownie");
            }
            else if(Item.Password!=passwordp.Text)
                await UserDialogs.Instance.AlertAsync("Popraw pola haseł", "Podane hasła się różnią", "Spróbuj ponownie");
            else
            {
                await viewModel.DataStoreUsers.AddItemAsync(Item);
                UserDialogs.Instance.Toast("Konto zostało utworzone", TimeSpan.FromSeconds(5));
                await Navigation.PopAsync();
            }
            
        }
    }
}