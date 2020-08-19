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
    public partial class ConfigDatosPage : ContentPage
    {
        public static string NombreUsuario = "";
        public static string ApellidoUsuario = "";
        public static string Correo = "";
        public static string NumCell = "";
        public static string FotoUsuario = "";
        public static int Idusuario;
        public static int Id;

        public ConfigDatosPage()
        {
            InitializeComponent();
            this.BindingContext = new ConfgUsuarioLocalViewModel();
        }

        public ConfigDatosPage(string PId, string PIdUsuario, string NombreUsuario, string ApellidoUsuario, string Correo, string NumCell, string FotoUsuario)
        {
            InitializeComponent();
            this.BindingContext = new ConfgUsuarioLocalViewModel();
            Idusuario = Convert.ToInt32(PIdUsuario);
            txtId.Text = PId;
            txtIdUsuario.Text = PIdUsuario;
            txtNombre.Text = NombreUsuario;
            txtApellido.Text = ApellidoUsuario;
            txtCorreo.Text = Correo;
            txtNumCell.Text = NumCell;
            txtFotoUsuario.Text = FotoUsuario;

        }

        private async void btnMenu_Clicked(object sender, EventArgs e)
        {
            if (Idusuario.ToString() == null || Idusuario.ToString() == "")
            {
                Idusuario = 1;
            }
            await Navigation.PushAsync(new MainPage());
        }
    }


}