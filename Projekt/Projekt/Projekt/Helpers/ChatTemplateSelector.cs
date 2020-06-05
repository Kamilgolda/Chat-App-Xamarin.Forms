using Projekt.Models;
using Projekt.Views.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Projekt.Helpers
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Messages;
            if (messageVm == null)
                return null;


            return (messageVm.IdSender == Projekt.ViewModels.BaseViewModel.zalogowany.IdUser) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}
