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
    public partial class ListaContactoPage : ContentPage
    {
        public ListaContactoPage()
        {
            InitializeComponent();
            BindingContext = new ContactoViewModel();
       
        }

        private async void CVListaContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection[0] is ContactoModel contactoModel)
            {

                await Navigation.PushAsync(new ChatPageNew(contactoModel.IdUsuarioReceptor.ToString(), contactoModel.NombreUsuario, contactoModel.ApellidoUsuario, contactoModel.Correo, contactoModel.NumCellContacto, contactoModel.FotoUsuario));
                BindingContext = new ContactoViewModel();
             
            }
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            BindingContext = new ContactoViewModel();
        }
    }
}