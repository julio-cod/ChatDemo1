using ChatDemo1.Model;
using ChatDemo1.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatDemo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaUsuariosPage : ContentPage
    {
        public ListaUsuariosPage()
        {
            InitializeComponent();

            BindingContext = new UsuariosPerfilViewModel();

            //((NavigationPage)this.Parent).PushAsync(new ChatPageNew());

           

        }

        private async void CVListaUsuariosPerfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


            if (e.CurrentSelection[0] is UsuarioPerfilModel usuarioPerfilModel)
            {
                
                await Navigation.PushAsync(new ChatPageNew(usuarioPerfilModel.IdUsuario.ToString(),usuarioPerfilModel.NombreUsuario, usuarioPerfilModel.ApellidoUsuario, usuarioPerfilModel.Correo, usuarioPerfilModel.NumCell, usuarioPerfilModel.FotoUsuario));
                BindingContext = new UsuariosPerfilViewModel();
                //await Navigation.PushAsync(new ChatPageNew());
            }
            

        }
    }
}