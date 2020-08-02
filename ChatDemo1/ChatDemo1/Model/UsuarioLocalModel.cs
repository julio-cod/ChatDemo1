using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatDemo1.Model
{
    public class UsuarioLocalModel
    {
        [PrimaryKey]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string Correo { get; set; }
        public string NumCell { get; set; }
        public string FotoUsuario { get; set; }
    }
}
