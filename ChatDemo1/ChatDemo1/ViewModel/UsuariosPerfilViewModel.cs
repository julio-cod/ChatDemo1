using ChatDemo1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatDemo1.ViewModel
{
    public class UsuariosPerfilViewModel : INotifyPropertyChanged
    {
        

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
            //PostDataAsync();
            //PustDataAsync();
            //DeleteDataAsync();


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

       

    }
}
