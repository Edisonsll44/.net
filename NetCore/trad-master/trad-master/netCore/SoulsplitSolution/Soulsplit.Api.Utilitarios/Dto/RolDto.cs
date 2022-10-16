using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class RolDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombre")]
        public string NombreRol { get; set; }
        [JsonProperty("instalacion")]
        public bool RolInstalacion { get; set; }
    }
}
