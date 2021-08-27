using Microsoft.AspNet.SignalR;
using SignalRExampleData.Models;
using System.Collections.Generic;

namespace SignalRExampleData
{
    public class DataHub : Hub
    {
        public void Send(string name, IEnumerable<CategoryModel> data)
        {
            Clients.All.broadcastMessage(name, data);
        }
    }
}