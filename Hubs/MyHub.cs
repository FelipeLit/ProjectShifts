using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class MiHub : Hub
    {
        public async Task SendData()
        {
            await Clients.All.SendAsync("ReceiveData");
        }
    }
}