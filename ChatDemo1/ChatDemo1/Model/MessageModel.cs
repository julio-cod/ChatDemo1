using System;
using System.Collections.Generic;
using System.Text;

namespace ChatDemo1.Model
{
    public class MessageModel
    {
        public string IdMensaje { get; set; }
        public int IdEmisor { get; set; }
        public int IdReceptor { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    

    }
}
