using Projekt.ViewModels;
using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projekt.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        AboutViewModel viewModel;

        
        public AboutPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AboutViewModel();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           //viewModel.Image = ImageSource.FromStream(() => new MemoryStream(viewModel._zalogowany.Image));
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPage());
        }
    }
}