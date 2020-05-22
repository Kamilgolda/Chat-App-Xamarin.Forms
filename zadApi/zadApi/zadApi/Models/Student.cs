using System;
using Xamarin.Forms;

namespace zadApi.Models
{
    public class Student:BindableObject
    {
        private int _id;
        public int Id {
            get { return _id; }
            set { _id = value; OnPropertyChanged();}
        }

        private string _imie;
        public string Imie {
            get { return _imie; }
            set { _imie = value; OnPropertyChanged(); }
        }

        private string _nazwisko;
        public string Nazwisko {
            get { return _nazwisko; }
            set { _nazwisko = value; OnPropertyChanged(); }
        }

        private string _nralbumu;
        public string NrAlbumu {
            get { return _nralbumu; }
            set { _nralbumu = value; OnPropertyChanged(); }
        }

        private string _plec;
        public string Plec {
            get { return _plec; }
            set { _plec = value; OnPropertyChanged(); }
        }
    }
}