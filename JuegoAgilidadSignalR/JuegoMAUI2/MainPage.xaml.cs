using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System;
using System.Timers;

namespace JuegoMAUI2
{
    public partial class MainPage : ContentPage
    {
        private readonly HubConnection hubConnection;
        private System.Timers.Timer timer;
        private int opponentClickCount = 0;
        private int myClickCount = 0;

        public MainPage()
        {
            InitializeComponent();

            // Configuraciones anteriores...

            hubConnection.On("ButtonClicked", () => {
                button.IsVisible = false;
                opponentClickCount++;
                Device.InvokeOnMainThreadAsync(() =>
                {
                    opponentCountLabel.Text = $"Contador Contrincante: {opponentClickCount}";
                });
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            button.IsVisible = false;
            myClickCount++;
            myCountLabel.Text = $"Mi Contador: {myClickCount}";

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
