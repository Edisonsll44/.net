using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ApiCaller
{
    public interface IApiCaller
    {
        Task<T> GetServiceResponseById<T>(string controller, long id);
    }
}
