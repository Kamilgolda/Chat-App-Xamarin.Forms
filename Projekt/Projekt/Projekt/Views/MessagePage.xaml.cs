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
    public partial class MessagePage : ContentPage
    {
        MessagePageViewModel viewModel;
        public MessagePage(MessagePageViewModel ViewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel = ViewModel;
        }

        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as MessagePageViewModel;

                   
                        
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        //vm.PendingMessageCount = 0;
                        //ChatList?.ScrollToFirst();
                    


                }

            }
        }
       
        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
           // chatInput.UnFocusEntry();
        }
    }
}
       