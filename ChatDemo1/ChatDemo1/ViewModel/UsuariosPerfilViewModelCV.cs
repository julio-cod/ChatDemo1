using ChatDemo1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChatDemo1.ViewModel
{
    public class UsuariosPerfilViewModelCV : INotifyPropertyChanged
    {
        private ObservableCollection<UsuarioPerfilModel> ListadoPersonas;

        public ObservableCollection<UsuarioPerfilModel> ListadoPersonas1
        {
            get
            {
                if (ListadoPersonas == null)
                {
                    //LlenarPersonas();
                    //ListadoViewModel();
                    //return ListadoPersonas;
                }
                return ListadoPersonas;
            }
            set
            {
                ListadoPersonas = value;
                //ListadoPersonas = value;
                NotifyPropertyChanged();

            }
        }

        public UsuariosPerfilViewModelCV()
        {
            //LlenarPersonas();

        }
        /*
        public void LlenarPersonas()
        {
            using (var contexto = new DataContext())
            {
                ObservableCollection<UsuarioPerfilModel> modelo = new ObservableCollection<UsuarioPerfilModel>(contexto.Consultar());
                ListadoPersonas = modelo;
                //ListadoPersonas1 = modelo;
            }

        }
        */
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
