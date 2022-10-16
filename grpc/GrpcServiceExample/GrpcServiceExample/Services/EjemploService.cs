using Grpc.Core;

namespace GrpcServiceExample.Services
{
    public class EjemploService : Ejemplo.EjemploBase
    {
        public override Task<EjemploHelloReply> Saluda(EjemploHelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new EjemploHelloReply() { Message = "Hola sr Lenin " + request.Apellido });
        }

        public override Task<SendReply> SaludaInps(GetEmployees getEmployees, ServerCallContext context)
        {
            var employes = new SendReply();
            employes.EmployeNames.AddRange(new List<string> { "Gabriel Nuñez,", "Vinicio Ortega", "César Chicaiza" });
            return Task.FromResult(employes);
        }
    }
}

