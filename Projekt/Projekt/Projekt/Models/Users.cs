using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Projekt.Models
{
    public class Users : BindableObject
    {
        private int _iduser;
        public int IdUser { get { return _iduser; } set { _iduser = value; OnPropertyChanged(); } }

        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }

        private string _lastName;
        public string LastName { get { return _lastName; } set { _lastName = value; OnPropertyChanged(); } }

        private DateTime _dateofbirth;
        public DateTime Dateofbirth { get { return _dateofbirth; } set { _dateofbirth = value; OnPropertyChanged(); } }

        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(); } }

        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(); } }

        private byte[] _image;
        public byte[] Image { get { return _image; } set { _image = value; OnPropertyChanged(); } }

        private ImageSource _imagesource;
        [JsonIgnore]
        public ImageSource ImageSource { get { return _imagesource; } set { _imagesource = value; OnPropertyChanged(); } }
    }
}
