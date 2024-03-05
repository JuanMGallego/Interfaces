using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Maui.Controls;
using System;
using System.Timers;

namespace JuegoMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly HubConnection hubConnection;
        private System.Timers.Timer timer;
        private int puntosJ1 = 0;
        private int puntosJ2 = 0;

        public MainPage()
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

                timer = new System.Timers.Timer(5000);
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                hubConnection.On("ButtonClicked", () => {
                    imageButton.IsVisible = false;
                    puntosJ2++;

                    j2Label.Text = "Oponente: " + puntosJ2;

                    ComprobarFin(puntosJ1, puntosJ2);
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

        private async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            try
            {
                imageButton.IsVisible = false;

                await hubConnection.InvokeAsync("ClickedButton");
                puntosJ1++;

                j1Label.Text = "Tú: " + puntosJ1;

                ComprobarFin(puntosJ1, puntosJ2);
            }
            catch (Exception ex)
            {
                // Manejar la excepción al invocar el método remoto
                Console.WriteLine($"Error al invocar el método remoto: {ex.Message}");
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Device.InvokeOnMainThreadAsync(() =>
                {
                    var random = new Random();
                    var x = random.Next(0, (int)(absoluteLayout.Width - imageButton.Width));
                    var y = random.Next(0, (int)(absoluteLayout.Height - imageButton.Height));

                    imageButton.TranslationX = x;
                    imageButton.TranslationY = y;
                    imageButton.IsVisible = true;

                    Device.StartTimer(TimeSpan.FromSeconds(4), () =>
                    {
                        imageButton.IsVisible = false;
                        return false;
                    });
                });
            }
            catch (Exception ex)
            {
                // Manejar la excepción en el temporizador
                Console.WriteLine($"Error en el temporizador: {ex.Message}");
            }
        }

        private void ComprobarFin(int puntosJ1, int puntosJ2)
        {
            if (puntosJ1 == 7)
            {
                DisplayAlert("¡Has Ganado!", "Tus puntos: " + puntosJ1 + "\nPuntos Oponente: " + puntosJ2, "Reintentar");
                ReiniciarPuntos();

            }
            else if (puntosJ2 == 7)
            {
                DisplayAlert("Has perdido :(", "Tus puntos: " + puntosJ1 + "\nPuntos Oponente: " + puntosJ2, "Reintentar");
                ReiniciarPuntos();
            }
        }

        private void ReiniciarPuntos()
        {
            puntosJ1 = 0;
            puntosJ2 = 0;
        }
    }
}
