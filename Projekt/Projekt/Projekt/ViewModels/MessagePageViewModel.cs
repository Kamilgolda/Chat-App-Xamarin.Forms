using Acr.UserDialogs;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projekt.ViewModels
{
    public class MessagePageViewModel:BaseViewModel
    {
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public Users rUser { get; set; }
        public ObservableCollection<Messages> Messages { get; set; } = new ObservableCollection<Messages>();
        private string textosend;
        public string TextToSend { get { return textosend; } set { textosend = value; OnPropertyChanged(); } }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand LoadItemsCommand { get; set; }
        public ICommand BlokujCommand { get; set; }
        private Messages newMessage;
        private string blokujtxt;
        public string Blokujtxt { get { return blokujtxt; } set { blokujtxt = value; OnPropertyChanged(); } }


        public MessagePageViewModel(Users item)
        {
            
            rUser = item;
            MessageAppearingCommand = new Command<Messages>(OnMessageAppearing);
            Title = "Chat z " + item.Name;
            

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                ExecuteLoadItemsCommand();


                return true;
            });

            OnSendCommand = new Command(async () => await ExecuteOnSendCommand());
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            BlokujCommand = new Command(async () => await ExecuteBlokujCommand());
            Blokujtxt = "Zablokuj";
            ExecuteLoadItemsCommand();
        }

        void OnMessageAppearing(Messages message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    
                    ShowScrollTap = true;
                    LastMessageVisible = true;
                });
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        async Task ExecuteOnSendCommand()
        {

            if (!string.IsNullOrEmpty(TextToSend) && Blokujtxt=="Zablokuj")
            {
                newMessage = new Messages() { Date = DateTime.Now, IdSender = zalogowany.IdUser, IdReceiver = rUser.IdUser, Text = TextToSend, Received = false, Blocked = false };
                DataStoreMessages.AddItemAsync(newMessage);
                TextToSend = string.Empty;
            }
            else
            {
                UserDialogs.Instance.Toast("Nie możesz wysłać wiadomości",TimeSpan.FromSeconds(10));
             
            }


        }
        async Task ExecuteBlokujCommand()
        {
            IsBusy = true;

            try
            {
                var items = await DataStoreMessages.GetItemsAsync(zalogowany.IdUser, rUser.IdUser);
                if (Blokujtxt == "Zablokuj")
                {

                    Messages item = items.ElementAt(0);
                    items.ElementAt(0).Blocked = true;
                    DataStoreMessages.UpdateItemAsync(items.ElementAt(0));

                    return;
                }
                if (Blokujtxt == "Odblokuj")
                {
                    items.ElementAt(0).Blocked = false;
                    DataStoreMessages.UpdateItemAsync(items.ElementAt(0));
                    return;
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

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var items = await DataStoreMessages.GetItemsAsync(zalogowany.IdUser, rUser.IdUser);
                foreach (var item in items)
                {
                    if (item.IdSender == zalogowany.IdUser)
                    {
                        if (item.Blocked == false)
                            Blokujtxt = "Zablokuj";
                        else
                        {
                            Blokujtxt = "Odblokuj";
                        }
                    }
                    else
                    {
                        if (item.Blocked == true)
                        {
                            Blokujtxt = "Zostałeś zablokowany";
                            return;
                        }
                    }
                }



                if (items.Count() > Messages.Count() && blokujtxt=="Zablokuj")
                {

                    for (int i = Messages.Count; i < items.Count(); i++)
                    {
                        Messages.Insert(0, items.ElementAt(i));


                    }
                    //Odblokuj aby pisac
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