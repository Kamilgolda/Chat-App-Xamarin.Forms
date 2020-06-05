using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Projekt.Models
{
   public class Messages :BindableObject
    {
        private int _idMessage;
        public int IdMessage
        {
            get { return _idMessage; }
            set { _idMessage = value; OnPropertyChanged(); }
        }

        private int _idSender;
        public int IdSender
        {
            get { return _idSender; }
            set { _idSender = value; OnPropertyChanged(); }
        }

        private int _idReceiver;
        public int IdReceiver
        {
            get { return _idReceiver; }
            set { _idReceiver = value; OnPropertyChanged(); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); }
        }


        private bool _received;
        public bool Received
        {
            get { return _received; }
            set { _received = value; OnPropertyChanged(); }
        }

        private bool _blocked;
        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; OnPropertyChanged(); }
        }

    }
}
