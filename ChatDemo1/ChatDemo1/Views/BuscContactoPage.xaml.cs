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
    public partial class BuscContactoPage : ContentPage
    {
        public static string numCell = "";

        public static int IdUsuario = MainPage.User;
        public static string NumCellContacto = "";
        public static int IdUsuarioReceptor = 0;
        public static string NombreUsuario = "";
        public static string ApellidoUsuario = "";
        public static string Correo = "";
        public static string FotoUsuario = "";

        public BuscContactoPage()
        {
            InitializeComponent();

           


        }

        private void txtBuscarUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            //BindingContext = new ContactoViewModel(txtBuscarUsuario.Text);
            numCell = txtBuscarUsuario.Text;
            BindingContext = new ContactoViewModel();
            

        }
        
        private async void CVListaContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection[0] is UsuarioPerfilModel usuarioPerfilModel)
            {

                bool answer = await DisplayAlert("Agregar Contacto", "Desea agregar este contacto?", "Si", "No");
            
                
                if (answer == true)
                {
                    
                    NumCellContacto = usuarioPerfilModel.NumCell;
                    IdUsuarioReceptor = usuarioPerfilModel.IdUsuario;
                    NombreUsuario = usuarioPerfilModel.NombreUsuario;
                    ApellidoUsuario = usuarioPerfilModel.ApellidoUsuario;
                    Correo = usuarioPerfilModel.Correo;
                    FotoUsuario = usuarioPerfilModel.FotoUsuario;

                    (this.BindingContext as ContactoViewModel).AgregarContactoCommand.Execute(null);
                    
                    await Navigation.PushAsync(new ChatPageNew(IdUsuarioReceptor.ToString(), NombreUsuario, ApellidoUsuario, Correo, NumCellContacto, FotoUsuario));
                    //await Navigation.PushAsync(new ListaContactoPage());

                }
                else
                {

                }

                BindingContext = new ContactoViewModel();

            }

            

        }
    }
}