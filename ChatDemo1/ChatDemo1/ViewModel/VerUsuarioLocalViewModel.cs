using ChatDemo1.Data;
using ChatDemo1.Model;
using ChatDemo1.Views;
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

        public ICommand VerIdUsuarioLocalCommand { get; set; }

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
            
            VerUsuarioLocalCommand = new Command(() =>
            {
                BuscarUsuarioLocal();


            });
            VerIdUsuarioLocalCommand = new Command(() =>
            {
                BuscarIdUsuarioLocal();


            });


        }

        

        public void ListaUsuarioLocal()
        {
            using (var contexto = new DataContext())
            {
                ObservableCollection<UsuarioLocalModel> modelo = new ObservableCollection<UsuarioLocalModel>(contexto.Consultar());
                ListadoUsuario = modelo;
                if (modelo.Count > 0)
                {
                    MainPage.UserRegistrado = true;
                }
                else
                {
                    MainPage.UserRegistrado = false;
                }
             
            }

        }

        
        public void BuscarUsuarioLocal()
        {
            
            using (var contexto = new DataContext())
            {
                //UsuarioLocalModel modelo = contexto.ConsultaUsuarioLocal(idUsuario);

                UsuarioLocalModel modelo = contexto.ConsultaUsuario();

                MainPage.idUser = modelo.IdUsuario;
                MainPage.NombreUsuario = modelo.NombreUsuario;
                MainPage.ApellidoUsuario = modelo.ApellidoUsuario;
                MainPage.NumCellContacto = modelo.NumCell;
                MainPage.Correo = modelo.Correo;
                MainPage.FotoUsuario = modelo.FotoUsuario;

                

            }

            


        }

        public void BuscarIdUsuarioLocal()
        {

            using (var contexto = new DataContext())
            {
                //UsuarioLocalModel modelo = contexto.ConsultaUsuarioLocal(idUsuario);

                UsuarioLocalModel modelo = contexto.ConsultaUsuario();

                RegistroInicioPage.Id = modelo.Id;
                RegistroInicioPage.Idusuario = modelo.IdUsuario;
                RegistroInicioPage.NombreUsuario = modelo.NombreUsuario;
                RegistroInicioPage.ApellidoUsuario = modelo.ApellidoUsuario;
                RegistroInicioPage.NumCell = modelo.NumCell;
                RegistroInicioPage.Correo = modelo.Correo;
                RegistroInicioPage.FotoUsuario = modelo.FotoUsuario;


            }

        }



    }
}
