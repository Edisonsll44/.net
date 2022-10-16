using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class TipoPersonaDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

    }
}