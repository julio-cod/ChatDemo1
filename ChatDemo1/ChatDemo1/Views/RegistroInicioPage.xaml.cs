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
    public partial class RegistroInicioPage : ContentPage
    {
        
        public static string NombreUsuario = "";
        public static string ApellidoUsuario = "";
        public static string Correo = "";
        public static string NumCell = "";
        public static string FotoUsuario = "";


        public RegistroInicioPage()
        {
            InitializeComponent();
            

        }
       
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            
            NombreUsuario = txtNombre.Text;
            ApellidoUsuario = txtApellido.Text;
            Correo = txtCorreo.Text;
            NumCell = txtNumCell.Text;
            FotoUsuario = txtFotoUsuario.Text; 
            
            if (txtFotoUsuario.Text == "")
            {
                FotoUsuario = "http://julioapp.somee.com/imagenPerfil/imagenPerfil.jpg";
            }

            BindingContext = new UsuariosPerfilViewModel();


            (this.BindingContext as UsuariosPerfilViewModel).RegistroIncioCommand.Execute(null);

            await Navigation.PushAsync(new MainPage());
          
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtNumCell.Text = "";
            txtFotoUsuario.Text = "";

            txtNombre.Placeholder = "Nombre";
            txtApellido.Placeholder = "Apellido";
            txtCorreo.Placeholder = "Correo";
            txtNumCell.Placeholder = "Num. Cell";
            txtFotoUsuario.Placeholder = "Imangen";


        }




    }
}