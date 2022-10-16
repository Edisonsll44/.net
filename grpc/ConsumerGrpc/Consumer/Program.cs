using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Test();
            Console.ReadLine();
        }

        static void Test()
        {
            try
            {
                var chanel = GrpcChannel.ForAddress("https://localhost:7288", new GrpcChannelOptions
                {
                    HttpHandler = new WinHttpHandler()
                });

                var client = new Greeter.GreeterClient(chanel);
                var reply = client.SayHello(new HelloRequest { Name = "Framework" });
                Console.WriteLine(reply.Message);
                Console.ReadKey();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
