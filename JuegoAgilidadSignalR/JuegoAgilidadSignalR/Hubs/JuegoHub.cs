using Microsoft.AspNetCore.SignalR;

namespace JuegoAgilidadSignalR.Hubs
{
    public class JuegoHub : Hub
    {
        public async Task ClickedButton()
        {
            await Clients.All.SendAsync("ButtonClicked");
        }
    }
}
