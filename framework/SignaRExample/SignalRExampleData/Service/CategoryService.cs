using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.Hosting;
using SignalRExampleData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SignalRExampleData.Service
{
    public class ExampleHostedService : IHostedService, IDisposable
    {
        private readonly IHubContext<DataHub> _datHub;
        private Timer timer;

        public ExampleHostedService(IHubContext<DataHub> datHub)
        {
            _datHub = datHub;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(SendInfo, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void SendInfo(object state)
        {
            var categorias = new List<CategoryModel>();
            using (var context = new InventoryContext())
            {
                categorias = Map(context.Categories).ToList();
            }
            _datHub.Clients.All.Send("Receive", categorias);
        }

        IEnumerable<CategoryModel> Map(IEnumerable<Categories> model)
       => model.Select(d => new CategoryModel { CategoryId = d.CategoryId, CategoryName = d.CategoryName });
        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}