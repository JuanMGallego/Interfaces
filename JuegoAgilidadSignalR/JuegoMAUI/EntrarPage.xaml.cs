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
                        // Manejar la excepción de inicio de la conexión
                        Console.WriteLine($"Error al iniciar la conexión: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                // Manejar la excepción de inicialización de la página
                Console.WriteLine($"Error en la inicialización de la página: {ex.Message}");
            }
        }

        private async void OnEntrarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
