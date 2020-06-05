using System;

using Projekt.Models;

namespace Projekt.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Users Item { get; set; }
        public string date { get;}
        public ItemDetailViewModel(Users item = null)
        {
            Title = item?.Name+" "+item?.LastName;
            Item = item;
            date = item.Dateofbirth.ToShortDateString();
            
        }
    }
}
