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
        public static int Id;

        public RegistroInicioPage()
        {
            InitializeComponent();
            
            if (MainPage.UserRegistrado)
            {
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                this.BindingContext = new ConfgUsuarioLocalViewModel();
            }
           

        }


        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
           
            if (btnGuardar.Text == "Registarse")
            {          

                Idusuario = 0;
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

                btnGuardar.Text = "Procesar Registro";
                
            }
            else
            {
                if (btnGuardar.Text == "Procesar Registro")
                {
                    BindingContext = new ConfgUsuarioLocalViewModel();
                    (this.BindingContext as ConfgUsuarioLocalViewModel).Guardar.Execute(null);

                    btnGuardar.Text = "Siguiente";

                }
                else
                {
                    if (btnGuardar.Text == "Siguiente")
                    {

                        BindingContext = new VerUsuarioLocalViewModel();
                        (this.BindingContext as VerUsuarioLocalViewModel).VerIdUsuarioLocalCommand.Execute(null);

                        BuscarIdUsuarioWebAcutalizarLocal(NumCell);

                        btnGuardar.Text = "Aceptar Terminos";
                    }
                    else
                    {
                        if (btnGuardar.Text == "Aceptar Terminos")
                        {

                            BindingContext = new ConfgUsuarioLocalViewModel();
                            (this.BindingContext as ConfgUsuarioLocalViewModel).ActualizarId.Execute(null);
                            btnGuardar.Text = "Iniciar App";
                        }
                        else
                        {
                            if (btnGuardar.Text == "Iniciar App")
                            {

                                await Navigation.PushAsync(new MainPage());
                            }

                        }
                    }
                }

                

            }


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
                //(this.BindingContext as ConfgUsuarioLocalViewModel).ActualizarId.Execute(null);
            }
            else
            {
                Debug.WriteLine("un error ha ocurrido mientras cargaba la data");
            }



        }

    }
}