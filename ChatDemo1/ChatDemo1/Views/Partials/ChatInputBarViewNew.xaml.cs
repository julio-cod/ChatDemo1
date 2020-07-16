using ChatDemo1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatDemo1.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatInputBarViewNew : ContentView
    {
        public ChatInputBarViewNew()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.SetBinding(HeightRequestProperty, new Binding("Height", BindingMode.OneWay, null, null, null, chatTextInput));
            }
        }

        

        public void UnFocusEntry()
        {
            chatTextInput?.Unfocus();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            (this.Parent.Parent.BindingContext as ChatPageNewViewModel).OnSendCommand.Execute(null);
            chatTextInput.Focus();
        }
    }
}