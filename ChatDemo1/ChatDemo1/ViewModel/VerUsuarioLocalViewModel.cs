using ChatDemo1.Data;
using ChatDemo1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatDemo1.ViewModel
{
    public class VerUsuarioLocalViewModel : UsuarioLocalModel
    {
        public ICommand VerUsuarioLocalCommand { get; set; }

        private ObservableCollection<UsuarioLocalModel> ListadoUsuario;

        public ObservableCollection<UsuarioLocalModel> ListadoUsuarioLocal
        {
            get
            {
                if (ListadoUsuario == null)
                {
                    ListaUsuarioLocal();
                    //ListadoViewModel();
                    //return ListadoPersonas;
                }
                return ListadoUsuario;
            }
            set
            {
                ListadoUsuario = value;
                //ListadoPersonas = value;

            }
        }
        
        public VerUsuarioLocalViewModel()
        {
            ListaUsuarioLocal();
       

        }
        
        public VerUsuarioLocalViewModel(int idUsuario)
        {
            ListaUsuarioLocal();

            VerUsuarioLocalCommand = new Command(() =>
            {
                BuscarUsuarioLocal(idUsuario);


            });

        }

        public void ListaUsuarioLocal()
        {
            using (var contexto = new DataContext())
            {
                ObservableCollection<UsuarioLocalModel> modelo = new ObservableCollection<UsuarioLocalModel>(contexto.Consultar());
                ListadoUsuario = modelo;
             
            }

        }

        
        public void BuscarUsuarioLocal(int idUsuario)
        {
            
            using (var contexto = new DataContext())
            {
                UsuarioLocalModel modelo = contexto.ConsultaUsuarioLocal(idUsuario);

                MainPage.idUser = modelo.IdUsuario;
                MainPage.NombreUsuario = modelo.NombreUsuario;
                MainPage.ApellidoUsuario = modelo.ApellidoUsuario;
                MainPage.NumCellContacto = modelo.NumCell;
                MainPage.Correo = modelo.Correo;
                MainPage.FotoUsuario = modelo.FotoUsuario;


            }

            


        }



    }
}
