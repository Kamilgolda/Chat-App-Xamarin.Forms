using Acr.UserDialogs;
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
    public partial class LoginPage : ContentPage
    {
        ItemsViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            viewModel = new ItemsViewModel();


            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(true);
            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

        private async void Zaloguj_Clicked(object sender, EventArgs e)
        {
            bool zalogowano = false;
            foreach (Users x in viewModel.Items)
            {
                if (x.Email == Login.Text && x.Password == Haslo.Text)
                {
                    x.Password = "";
                    BaseViewModel.zalogowany = x;
                  await Navigation.PushAsync(new ItemsPage());
                    Navigation.RemovePage(Navigation.NavigationStack.First());
                    zalogowano = true;
                    break;
                }
            }
            if(zalogowano == false) await UserDialogs.Instance.AlertAsync("Podano błędny login/hasło", "Błąd logowania", "Spróbuj ponownie");

        }

        private async void Rejestruj_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}