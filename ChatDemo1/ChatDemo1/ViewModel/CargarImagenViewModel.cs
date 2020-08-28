using ChatDemo1.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatDemo1.ViewModel
{
    public class CargarImagenViewModel : INotifyPropertyChanged
    {
        private MediaFile _mediaFile;

        public ICommand PickPictureCommand => new Command(async () => await PickPicture());

        

        public CargarImagenViewModel()
        { 
        
        
        }

        #region Properties
        private string responseUrl;

        public string ResponseUrl
        {
            get { return responseUrl; }
            set { responseUrl = value; RaisePropertyChanged(); }
        }

        private ImageSource _image;

        public ImageSource Image
        {
            get { return _image; }
            set { _image = value; RaisePropertyChanged(); }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; RaisePropertyChanged(); }
        }

        #endregion

        private async Task PickPicture()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                ErrorMessage = "This is not support on your device.";
                return;
            }
            else
            {
                PickMediaOptions mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;

                Path = _mediaFile.Path;
                Image = ImageSource.FromStream(() => _mediaFile.GetStream());

                if (_mediaFile != null)
                {
                    RegistroInicioPage.FotoUsuario = System.IO.File.ReadAllBytes(_mediaFile.Path);

                    //viewModel.PhotoByte = System.IO.File.ReadAllBytes(photo.Path);
                }

            }
        }


        //Control de errores
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; RaisePropertyChanged(); }
        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; RaisePropertyChanged(); }
        }


        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handle = PropertyChanged;
            if (handle != null)
                handle(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
