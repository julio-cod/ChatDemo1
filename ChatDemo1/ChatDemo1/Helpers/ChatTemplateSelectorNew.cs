using ChatDemo1.Model;
using ChatDemo1.Views.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatDemo1.Helpers
{
    class ChatTemplateSelectorNew : DataTemplateSelector
    {

        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelectorNew()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCellNew));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCellNew));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as MessageModel;
            if (messageVm == null)
                return null;


            return (messageVm.IdEmisor == MainPage.idUser) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}
