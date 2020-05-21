using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

using zadApi.Models;
using zadApi.ViewModels;

namespace zadApi.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public ItemDetailPage(ItemDetailViewModel viewModel)
        
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

        }

        public ItemDetailPage()
        {
            InitializeComponent();
            
            var item = new Student
            {
                Imie = "Item 1",
                Nazwisko = "This is an item description.",
                NrAlbumu = "This is an item description.",
                Plec = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            ToolbarItem ed = edit;
            ToolbarItems.Clear();
            ed.Text = "Zapisz";
            ed.Clicked -= Edit_Clicked;
            ed.Clicked += Save_Clicked;
            ToolbarItems.Add(ed);
            dane.IsVisible = false;
            edycja.IsVisible = true;

        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            // await viewModel.PutItem();
            MessagingCenter.Send(this, "UpdateItem", viewModel.Item);
            await Navigation.PopToRootAsync();

        }
    }
}