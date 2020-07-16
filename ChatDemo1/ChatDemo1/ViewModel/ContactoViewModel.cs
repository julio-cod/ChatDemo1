using ChatDemo1.Model;
using ChatDemo1.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatDemo1.ViewModel
{
    public class ContactoViewModel : INotifyPropertyChanged
    {

        public ICommand AgregarContactoCommand { get; set; }

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

        public ContactoViewModel()
        {
            BuscarContactos();

            ListaContactos();


            AgregarContactoCommand = new Command(() =>
            {
                AgrgarContacto();


            });
            
        }

       


        private async void BuscarContactos()
        {
            string numCell = BuscContactoPage.numCell;
            //var uri = new Uri("http://julioapp.somee.com/api/UsuarioPerfil");

            var uri = new Uri("http://julioapp.somee.com/api/UsuarioPerfil?numCell=");

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri + numCell);

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


        private async void AgrgarContacto()
        {
           
            var uri = new Uri("http://julioapp.somee.com/api/GrupoContacto");

            var httpClient = new HttpClient();

            var newSpost = new ContactoModel()
            {

                 IdUsuario = BuscContactoPage.IdUsuario,
                 NumCellContacto = BuscContactoPage.NumCellContacto,
                 IdUsuarioReceptor = BuscContactoPage.IdUsuarioReceptor,
                 NombreUsuario = BuscContactoPage.NombreUsuario,
                 ApellidoUsuario = BuscContactoPage.ApellidoUsuario,
                 Correo = BuscContactoPage.Correo,
                 FotoUsuario = BuscContactoPage.FotoUsuario 
                /*
                IdUsuario = 1,
                NumCellContacto = "80987389898",
                IdUsuarioReceptor = 9,
                NombreUsuario = "prueba nombre",
                ApellidoUsuario = "prueba apellido",
                Correo = "pruebacorreo@otmail.com",
                FotoUsuario = "fotousuario.jpg"
                */

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

        private List<ContactoModel> _GetsListContactos { get; set; }
        public List<ContactoModel> GetsListContactos
        {
            get
            {
                return _GetsListContactos;
            }
            set
            {
                if (value != _GetsListContactos)
                {
                    _GetsListContactos = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private async void ListaContactos()
        {
            int idUsuario = MainPage.User;
            var uri = new Uri("http://julioapp.somee.com/api/GrupoContacto?idUsuario=");

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(uri + idUsuario.ToString());

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gets = JsonConvert.DeserializeObject<List<ContactoModel>>(content);

                GetsListContactos = new List<ContactoModel>(gets);

            }
            else
            {
                Debug.WriteLine("un error ha ocurrido mientras cargaba la data");
            }


        }

    }
}
