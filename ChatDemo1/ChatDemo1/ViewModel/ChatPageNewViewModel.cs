using ChatDemo1.Model;
using ChatDemo1.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace ChatDemo1.ViewModel
{
    public class ChatPageNewViewModel : INotifyPropertyChanged
    {
        //MessageModel messageModel = new MessageModel();

        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<MessageModel> DelayedMessages { get; set; } = new Queue<MessageModel>();
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatPageNewViewModel()
        {
            CargarMensajeGetDataAsync();

            MessageAppearingCommand = new Command<MessageModel>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<MessageModel>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    //Messages.Insert(0, new MessageModel() { Mensaje = TextToSend, IdEmisor = MainPage.User});
                    PostDataAsyncEnviarMensaje();
                    TextToSend = string.Empty;
                    CargarMensajeGetDataAsync();
                }

            });
            
            //Code to simulate reveing a new message procces
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                if (LastMessageVisible)
                {
                    //Messages.Insert(0, new MessageModel() { Mensaje = "New message test", IdReceptor = 2 });
                    CargarMensajeGetDataAsync();
                }
                else
                {
                    //DelayedMessages.Enqueue(new MessageModel() { Mensaje = "New message test", IdReceptor = 2 });
                    CargarMensajeGetDataAsync();
                    //PendingMessageCount++;
                }
                return true;
            });
            
            

        }

        void OnMessageAppearing(MessageModel message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(MessageModel message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }

        
       
       private async void CargarMensajeGetDataAsync()
       {
            int IdEmisor = MainPage.idUser;
            int IdRecepter = ChatPageNew.IdReceptor;

           var uri = new Uri("http://julioapp.somee.com/api/Chat?");

           var httpClient = new HttpClient();

           var response = await httpClient.GetAsync(uri + "idEmisor=" + IdEmisor + "&idReceptor=" + IdRecepter);

           if (response.IsSuccessStatusCode)
           {
               var content = await response.Content.ReadAsStringAsync();
               var gets = JsonConvert.DeserializeObject<List<MessageModel>>(content);

               Messages = new ObservableCollection<MessageModel>(gets);

           }
           else
           {
               Debug.WriteLine("un error ha ocurrido mientras cargaba la data");
           }


       }

        private async void PostDataAsyncEnviarMensaje()
        {

            var uri = new Uri("http://julioapp.somee.com/api/Chat");

            //var uri = "http://julioapp.somee.com/api/Estudiante";

            var httpClient = new HttpClient();

            var newSpost = new MessageModel()
            {

                IdEmisor = MainPage.idUser,
                IdReceptor = ChatPageNew.IdReceptor,
                Mensaje = TextToSend,
                Fecha = DateTime.Today


            };
            var jsonObject = JsonConvert.SerializeObject(newSpost);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {

                Debug.WriteLine("Datos Guardados");


            }
            else
            {
                Debug.WriteLine("Error ha ocurrido mientras se Guardaba la data");
            }
          

        }

        public event PropertyChangedEventHandler PropertyChanged;

  
    }
}
