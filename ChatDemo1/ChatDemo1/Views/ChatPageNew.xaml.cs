using ChatDemo1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatDemo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPageNew : ContentPage
    {

        public static int IdReceptor = 0;
        
        public ChatPageNew(string IdUsuarioReceptor, string NombreUsuario, string ApellidoUsuario, string Correo, string NumCell, byte[] FotoUsuario)
        {
            InitializeComponent();
            
            Title = NombreUsuario +" "+ ApellidoUsuario;
            IdReceptor = int.Parse(IdUsuarioReceptor);
            BindingContext = new ChatPageNewViewModel();

        }
        
       

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as ChatPageNewViewModel;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        while (vm.DelayedMessages.Count > 0)
                        {
                            vm.Messages.Insert(0, vm.DelayedMessages.Dequeue());
                        }
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        vm.PendingMessageCount = 0;
                        ChatList?.ScrollToFirst();
                    });


                }

            }
        }

        private void ChatList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }

        
    }


}