using ChatDemo1.Data;
using ChatDemo1.Model;
using System;
using System.Collections.Generic;
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

        public ConfgUsuarioLocalViewModel()
        {
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
                    IdUsuario = 0,
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
                    IdUsuario = IdUsuario
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
                    IdUsuario = IdUsuario
                };

                using (var contexto = new DataContext())
                {
                    contexto.Eliminar(modelo);
                }
            }
           );




        }




    }
}
