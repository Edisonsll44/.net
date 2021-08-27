using Microsoft.AspNet.SignalR;

namespace SignaRExample
{
    public class DataHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}