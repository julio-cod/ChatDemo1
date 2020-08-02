using ChatDemo1.Data;
using ChatDemo1.Model;
using ChatDemo1.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatDemo1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        public static int idUser = -1;
        public static string NumCellContacto = "";
        //public static int IdUsuarioReceptor = 0;
        public static string NombreUsuario = "";
        public static string ApellidoUsuario = "";
        public static string Correo = "";
        public static string FotoUsuario = "http://julioapp.somee.com/imagenPerfil/jazz1img.jpg";

        public MainPage()
        {
            InitializeComponent();
            //string nombUsuario;
            BindingContext = new VerUsuarioLocalViewModel(0);

            
            (this.BindingContext as VerUsuarioLocalViewModel).VerUsuarioLocalCommand.Execute(null);

            DisplayAlert("Inicio de App", "Bienvenido " + idUser +" " + NombreUsuario + " " + ApellidoUsuario + " " + NumCellContacto + " " + Correo + " " + FotoUsuario, "Iniciar");

            

        }


        



    }
}
