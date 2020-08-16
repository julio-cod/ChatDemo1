using ChatDemo1.Data;
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
    public partial class RegistroInicioPage : ContentPage
    {
        
        public static string NombreUsuario = "";
        public static string ApellidoUsuario = "";
        public static string Correo = "";
        public static string NumCell = "";
        public static string FotoUsuario = "";
        public static int Idusuario;

        public RegistroInicioPage()
        {
            InitializeComponent();
            this.BindingContext = new ConfgUsuarioLocalViewModel();
           

        }

        public RegistroInicioPage(string PId,string PIdUsuario, string NombreUsuario, string ApellidoUsuario, string Correo, string NumCell, string FotoUsuario)
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

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Idusuario = 1;
            NombreUsuario = txtNombre.Text;
            ApellidoUsuario = txtApellido.Text;
            Correo = txtCorreo.Text;
            NumCell = txtNumCell.Text;
            FotoUsuario = txtFotoUsuario.Text; 
            
            if (txtFotoUsuario.Text == "" || txtFotoUsuario.Placeholder == "Imagen")
            {
                FotoUsuario = "http://julioapp.somee.com/imagenPerfil/imagenPerfil.jpg";
            }

            BindingContext = new UsuariosPerfilViewModel();

            (this.BindingContext as UsuariosPerfilViewModel).RegistroIncioCommand.Execute(null);

            BuscarIdUsuarioWebAcutalizarLocal(txtNumCell.Text);

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
            txtFotoUsuario.Placeholder = "Imagen";


        }

        private async void btnMenu_Clicked(object sender, EventArgs e)
        {
            if (Idusuario.ToString() == null || Idusuario.ToString() == "")
            {
                Idusuario = 1;
            }
            await Navigation.PushAsync(new MainPage());
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnBuscIdUsuario_Clicked(object sender, EventArgs e)
        {
            //BindingContext = new UsuariosPerfilViewModel(txtNumCell.Text);
            //(BindingContext as UsuariosPerfilViewModel).BuscarIdUsuarioCommand.Execute(null);

            BuscarIdUsuarioWebAcutalizarLocal(txtNumCell.Text);

          
            
        }

        private void CVListaUsuariosPerfil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //int idUsuario = (e.CurrentSelection.FirstOrDefault() as UsuarioPerfilModel).IdUsuario;

            //txtIdUsuario.Text = idUsuario.ToString();

        }

        private List<UsuarioPerfilModel> _GetsList { get; set; }
        public List<UsuarioPerfilModel> GetsList
        {
            get
            {
                return _GetsList;
            }
            set
            {
                if (value != _GetsList)
                {
                    _GetsList = value;
                   
                }
            }
        }

        private async void BuscarIdUsuarioWebAcutalizarLocal(string numCell)
        {
            //string numCell = BuscContactoPage.numCell;

            var uri = new Uri("http://julioapp.somee.com/api/UsuarioPerfil?numCell=");

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri + numCell);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //var gets = JsonConvert.DeserializeObject<List<UsuarioPerfilModel>>(content);
                var gets = JsonConvert.DeserializeObject<List<UsuarioPerfilModel>>(content);

                //GetsList = new List<UsuarioPerfilModel>(gets);
                GetsList = new List<UsuarioPerfilModel>(gets);


                Idusuario = GetsList[0].IdUsuario;

                txtIdUsuario.Text = Idusuario.ToString();
                (this.BindingContext as ConfgUsuarioLocalViewModel).ActualizarId.Execute(null);
            }
            else
            {
                Debug.WriteLine("un error ha ocurrido mientras cargaba la data");
            }



        }

    }
}