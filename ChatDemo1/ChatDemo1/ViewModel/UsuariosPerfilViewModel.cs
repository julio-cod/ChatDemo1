using ChatDemo1.Data;
using ChatDemo1.Model;
using ChatDemo1.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatDemo1.ViewModel
{
    public class UsuariosPerfilViewModel : INotifyPropertyChanged
    {
        

        public ICommand RegistroIncioCommand { get; set; }

       

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
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public UsuariosPerfilViewModel()
        {
            GetDataAsyncListaUsuarioPerfil();

            RegistroIncioCommand = new Command(() =>
            {
                RegistroInicio();

            });


        }
        
        private async void GetDataAsyncListaUsuarioPerfil()
        {

            var uri = new Uri("http://julioapp.somee.com/api/UsuarioPerfil");

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gets = JsonConvert.DeserializeObject<List<UsuarioPerfilModel>>(content);

                GetsList = new List<UsuarioPerfilModel>(gets);

            }
            else
            {
                Debug.WriteLine("un error ha ocurrido mientras cargaba la data");
            }
         

        }

        private async void RegistroInicio()
        {
          
            var uri = new Uri("http://julioapp.somee.com/api/UsuarioPerfil");

            var httpClient = new HttpClient();

            var newSpost = new UsuarioPerfilModel()
            {

                NombreUsuario = RegistroInicioPage.NombreUsuario,
                ApellidoUsuario = RegistroInicioPage.ApellidoUsuario,
                Correo = RegistroInicioPage.Correo,
                NumCell = RegistroInicioPage.NumCell,
                FotoUsuario = RegistroInicioPage.FotoUsuario


            };
            var jsonObject = JsonConvert.SerializeObject(newSpost);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Datos Guardados");
            }
            else
            {
                Debug.WriteLine("Error ha ocurrido mientras se Guardaba la data");
            }


        }

        private async void BuscarIdUsuarioWebAcutalizarLocal(string numCell)
        {
            /*

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


                RegistroInicioPage.Idusuario = GetsList[0].IdUsuario;

                //txtIdUsuario.Text = Idusuario.ToString();
                //(this.BindingContext as ConfgUsuarioLocalViewModel).ActualizarId.Execute(null);
                UsuarioLocalModel modelo = new UsuarioLocalModel()
                {
                    //IdUsuario = RegistroInicioPage.Idusuario,
                    IdUsuario = GetsList[0].IdUsuario,
                    NombreUsuario = GetsList[0].NombreUsuario,
                    ApellidoUsuario = GetsList[0].ApellidoUsuario,
                    Correo = GetsList[0].Correo,
                    NumCell = GetsList[0].NumCell,
                    FotoUsuario = GetsList[0].FotoUsuario,
                    Id = Id
                };

                using (var contexto = new DataContext())
                {
                    if (modelo.FotoUsuario == string.Empty || modelo.FotoUsuario == "" || modelo.FotoUsuario == null)
                    {
                        modelo.FotoUsuario = "http://julioapp.somee.com/imagenPerfil/imagenPerfil.jpg";
                    }

                    contexto.Actualizar(modelo);
                }


            }
            else
            {
                Debug.WriteLine("un error ha ocurrido mientras cargaba la data");
            }

            */

        }

        private async void BuscarIdUsuarioWeb(string numCell)
        {
            //string numCell = BuscContactoPage.numCell;

            var uri = new Uri("http://julioapp.somee.com/api/UsuarioPerfil?numCell=");

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri + numCell);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gets = JsonConvert.DeserializeObject<List<UsuarioPerfilModel>>(content);

                GetsList = new List<UsuarioPerfilModel>(gets);

                //List<UsuarioPerfilModel> itemUsuario = new List<UsuarioPerfilModel>(gets);

                RegistroInicioPage.Idusuario = GetsList[0].IdUsuario;
          

            }
            else
            {
                Debug.WriteLine("un error ha ocurrido mientras cargaba la data");
            }



        }

        


    }
}
