using ChatDemo1.Model;
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
    public partial class VerUsuarioLocalPage : ContentPage
    {
        public VerUsuarioLocalPage()
        {
            InitializeComponent();
            this.BindingContext = new VerUsuarioLocalViewModel();
        }

        private async void CVUsuarioLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection[0] is UsuarioLocalModel UsuarioLocalModel)
            {

                await Navigation.PushAsync(new RegistroInicioPage(UsuarioLocalModel.Id.ToString(),UsuarioLocalModel.IdUsuario.ToString(), UsuarioLocalModel.NombreUsuario, UsuarioLocalModel.ApellidoUsuario, UsuarioLocalModel.Correo, UsuarioLocalModel.NumCell, UsuarioLocalModel.FotoUsuario));
                BindingContext = new VerUsuarioLocalViewModel();

            }
        }
    }
}