using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatDemo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyPage : ContentPage
    {
        public EmptyPage()
        {
            InitializeComponent();
        }

        private async void btnchatList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaContactoPage());
        }
    }
}