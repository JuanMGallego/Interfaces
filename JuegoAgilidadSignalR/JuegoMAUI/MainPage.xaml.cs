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

        public MainPage()
        {
            InitializeComponent();

            var baseUrl = "http://localhost";

            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                baseUrl = "http://10.0.2.2";
            }

            hubConnection = new HubConnectionBuilder()
                .WithUrl($"{baseUrl}:5094/juegoHub")
                .Build();

            button.Clicked += Button_Clicked;

            timer = new System.Timers.Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            hubConnection.On("ButtonClicked", () => {
                button.IsVisible = false;
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            button.IsVisible = false;

            await hubConnection.InvokeCoreAsync("ClickedButton", args: null);

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.InvokeOnMainThreadAsync(() =>
            {
                var random = new Random();
                var x = random.Next(0, (int)(Width - button.Width));
                var y = random.Next(0, (int)(Height - button.Height));

                button.Margin = new Thickness(x, y, 0, 0);
                button.IsVisible = true;

                Device.StartTimer(TimeSpan.FromSeconds(4), () =>
                {
                    button.IsVisible = false;
                    return false;
                });
            });
        }
    }

}
