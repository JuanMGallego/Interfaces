using Microsoft.AspNetCore.SignalR;
using Models;

namespace Ejercicio01.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario objMensajeUsuario)
        {
            await Clients.All.SendAsync("ReceiveMessage", objMensajeUsuario);
        }
    }
}
