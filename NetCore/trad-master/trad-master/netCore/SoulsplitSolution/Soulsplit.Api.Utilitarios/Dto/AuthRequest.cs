using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class AuthRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("clave")]
        public string Clave { get; set; }
        [JsonProperty("codigo")]
        public string Codigo { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
