using ChatDemo1.Data;
using ChatDemo1.Model;
using ChatDemo1.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatDemo1.ViewModel
{
    public class ConfgUsuarioLocalViewModel : UsuarioLocalModel
    {
        public ICommand Guardar { get; private set; }
        public ICommand Modificar { get; private set; }
        public ICommand Eliminar { get; private set; }
        public ICommand Nuevo { get; private set; }

        public ICommand ActualizarId { get; private set; }

        public ICommand EliminarTablaComand { get; private set; }
        

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

        public void ListaUsuarioLocal()
        {
            using (var contexto = new DataContext())
            {
                ObservableCollection<UsuarioLocalModel> modelo = new ObservableCollection<UsuarioLocalModel>(contexto.Consultar());
                ListadoUsuario = modelo;

            }

        }

        public ConfgUsuarioLocalViewModel()
        {
            ListaUsuarioLocal();
            Nuevo = new Command(() => {

                IdUsuario = 0;
                NombreUsuario = string.Empty;
                ApellidoUsuario = string.Empty;
                Correo = string.Empty;
                NumCell = string.Empty;
                FotoUsuario = string.Empty;

            }
          );


            Guardar = new Command(() => {
                FotoUsuario = string.Empty;
                UsuarioLocalModel modelo = new UsuarioLocalModel()
                {
                    IdUsuario = RegistroInicioPage.Idusuario,
                    NombreUsuario = NombreUsuario,
                    ApellidoUsuario = ApellidoUsuario,
                    Correo = Correo,
                    NumCell = NumCell,
                    FotoUsuario = FotoUsuario
                    
                    
                };

                

                using (var contexto = new DataContext())
                {
                    if (modelo.FotoUsuario == string.Empty)
                    {
                        modelo.FotoUsuario = "http://julioapp.somee.com/imagenPerfil/imagenPerfil.jpg";
                    }

                    contexto.Insertar(modelo);
                }  
            }
             );


            Modificar = new Command(() => {
                UsuarioLocalModel modelo = new UsuarioLocalModel()
                {
                    NombreUsuario = NombreUsuario,
                    ApellidoUsuario = ApellidoUsuario,
                    Correo = Correo,
                    NumCell = NumCell,
                    FotoUsuario = FotoUsuario,
                    IdUsuario = IdUsuario,
                    Id = Id
                };

                using (var contexto = new DataContext())
                {
                    contexto.Actualizar(modelo);
                }
            }
            );

            Eliminar = new Command(() => {
                UsuarioLocalModel modelo = new UsuarioLocalModel()
                {
                    NombreUsuario = NombreUsuario,
                    ApellidoUsuario = ApellidoUsuario,
                    Correo = Correo,
                    NumCell = NumCell,
                    FotoUsuario = FotoUsuario,
                    IdUsuario = RegistroInicioPage.Idusuario,
                    Id = Id
                };

                using (var contexto = new DataContext())
                {
                    contexto.Eliminar(modelo);
                }
            }
           );

            
            ActualizarId = new Command(() => {
                //ListaUsuarioLocal();
                UsuarioLocalModel modelo = new UsuarioLocalModel()
                {
                    //IdUsuario = RegistroInicioPage.Idusuario,
                    IdUsuario = IdUsuario,
                    NombreUsuario = NombreUsuario,
                    ApellidoUsuario = ApellidoUsuario,
                    Correo = Correo,
                    NumCell = NumCell,
                    FotoUsuario = FotoUsuario,
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
            );

            EliminarTablaComand = new Command(() => {
                
                using (var contexto = new DataContext())
                {
                    contexto.EliminarTabla();
                }
            }
            );

            

        }

    }
}
