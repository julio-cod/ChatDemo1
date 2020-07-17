﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChatDemo1.Model
{
    public class ContactoModel
    {
        public int IdGrupoContacto { get; set; }

        public int IdUsuario { get; set; }

        public string NumCellContacto { get; set; }

        public int IdUsuarioReceptor { get; set; }

        public string NombreUsuario { get; set; }

        public string ApellidoUsuario { get; set; }

        public string Correo { get; set; }

        public string FotoUsuario { get; set; }

    }
}