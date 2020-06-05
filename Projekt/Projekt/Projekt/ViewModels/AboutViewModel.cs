using Projekt.Models;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Projekt.ViewModels
{
    public class AboutViewModel : BaseViewModel
    { 
        public Users _zalogowany { get; set; }
        public string date { get; set; }
        public AboutViewModel()
        {
            Title = "Mój profil";
            _zalogowany = zalogowany;
            date= _zalogowany.Dateofbirth.ToShortDateString();
        }

       
    }
}