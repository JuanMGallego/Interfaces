using Microsoft.AspNetCore.SignalR;

namespace JuegoAgilidadSignalR.Hubs
{
    public class JuegoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
