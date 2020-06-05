using Plugin.Media;
using Plugin.Media.Abstractions;
using Projekt.Models;
using Projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        EditViewModel viewModel;
        
        
                        
        public EditPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EditViewModel();
            
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
           
            BaseViewModel.zalogowany.Name = viewModel._zalogowany.Name;
            BaseViewModel.zalogowany.LastName = viewModel._zalogowany.LastName;
            BaseViewModel.zalogowany.Image = viewModel._zalogowany.Image;
            BaseViewModel.zalogowany.Email = viewModel._zalogowany.Email;
            BaseViewModel.zalogowany.Dateofbirth = viewModel._zalogowany.Dateofbirth;
            BaseViewModel.zalogowany.Password = viewModel._zalogowany.Password;
            BaseViewModel.zalogowany.ImageSource = viewModel._zalogowany.ImageSource;


            
            await viewModel.DataStoreUsers.UpdateItemAsync(BaseViewModel.zalogowany);
            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
    }
}