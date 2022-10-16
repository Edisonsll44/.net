using ConsumerGrpc;
using Grpc.Net.Client;
using GrpcServiceExample;

using (var chanel = GrpcChannel.ForAddress("https://localhost:7288"))
{
    //var client = new Greeter.GreeterClient(chanel);
    //var client2 = new Animals.AnimalsClient(chanel);
    var client3 = new Ejemplo.EjemploClient(chanel);
    //var reply = await client.SayHelloAsync(new HelloRequest { Name = "Eddy" });
    //var reply2 = await client2.GetAsync(new AnimalsRequest { });

    //var reply3 = client3.Saluda(new EjemploHelloRequest { Apellido = "Ormaza", Name = "Lenin" });
    var reply4 = await client3.SaludaInpsAsync(new GetEmployees { });
    Console.WriteLine(reply4.EmployeNames);

    foreach (var employee in reply4.EmployeNames)
    {
        Console.WriteLine(employee);
    }
    Console.ReadKey();
}