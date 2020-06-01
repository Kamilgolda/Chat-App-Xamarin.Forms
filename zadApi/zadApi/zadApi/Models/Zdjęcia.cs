using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace zadApi.Models
{
   public class Zdjęcia : BindableObject
    {
        private int _id;
        public int Id {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); } }

        private int _idStudent;
        public int IdStudent {
            get { return _idStudent; }
            set { _idStudent = value; OnPropertyChanged(); } }

        private byte[] _zdjecie;
        public byte[] Zdjęcie {
            get { return _zdjecie; }
            set { _zdjecie = value; OnPropertyChanged(); } }
    }
}
