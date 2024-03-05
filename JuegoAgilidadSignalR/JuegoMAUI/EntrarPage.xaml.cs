using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Maui.Controls;

namespace JuegoMAUI
{
    public partial class EntrarPage : ContentPage
    {

        private readonly HubConnection hubConnection;
        public EntrarPage()
        {
            InitializeComponent();

            try
            {
                var baseUrl = "http://localhost";

                if (DeviceInfo.Platform == DevicePlatform.Android)
                {
                    baseUrl = "http://10.0.2.2";
                }

                hubConnection = new HubConnectionBuilder()
                    .WithUrl($"{baseUrl}:7261/juegoHub")
                    .Build();

               

                hubConnection.On("ButtonClicked", () => {
                    
                });

                Task.Run(async () =>
                {
                    try
                    {
                        await Dispatcher.DispatchAsync(async () =>
                        {
                            await hubConnection.StartAsync();
                        });
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepci�n de inicio de la conexi�n
                        Console.WriteLine($"Error al iniciar la conexi�n: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                // Manejar la excepci�n de inicializaci�n de la p�gina
                Console.WriteLine($"Error en la inicializaci�n de la p�gina: {ex.Message}");
            }
        }

        private async void OnEntrarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
