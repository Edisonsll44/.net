using Newtonsoft.Json;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ApiCaller;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.ApiCaller
{
    public class ApiCaller : IApiCaller
    {
        private readonly HttpClient _httpClient;
        public ApiCaller(IAppConfig appConfig)
        {

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(appConfig.ServicioUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetServiceResponseById<T>(string controller, long id)
        {
            var response = await _httpClient.GetAsync($"/{controller}/{id}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
