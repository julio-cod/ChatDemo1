using ChatDemo1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatDemo1
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new ListaUsuariosPage(); 
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
