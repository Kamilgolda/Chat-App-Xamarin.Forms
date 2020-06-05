using FFImageLoading;
using Projekt.Models;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchUsersPage : ContentPage
    {
        ItemsViewModel viewModel;
        public SearchUsersPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            viewModel.LoadItemsCommand.Execute(true);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            string tekst = searchBar.Text;
            IEnumerable<Users> users;
            users =viewModel.Items.Where(x => (x.Name.ToLower() +" "+ x.LastName.ToLower()).Contains(tekst) );
            searchResults.ItemsSource = users;
        }

        private async void OnItemSelected(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Users)layout.BindingContext;
            await Navigation.PushAsync(new MessagePage(new MessagePageViewModel(item)));
        }
    }
}