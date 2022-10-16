using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCola1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cola = Convert.ToString(args[0]);
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var conecction = factory.CreateConnection())
            {
                using (var chanel = conecction.CreateModel())
                {
                    chanel.QueueDeclare(cola, false, false, false, null);
                    var consumer = new EventingBasicConsumer(chanel);
                    BasicGetResult result = chanel.BasicGet(cola, true);

                    Console.WriteLine("Esperando por los mensajes Ctrl + c pasa salir.....");
                    if (result != null)
                    {
                        string data = Encoding.UTF8.GetString(result.Body.ToArray());
                        Console.WriteLine(data);
                    }
                }

            }
        }
    }
}
