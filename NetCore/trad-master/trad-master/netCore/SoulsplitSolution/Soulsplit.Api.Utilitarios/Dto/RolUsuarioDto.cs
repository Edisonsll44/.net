using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class RolUsuarioDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("rolid")]
        public Guid RolId { get; set; }
        [JsonProperty("usuarioid")]
        public Guid UsuarioId { get; set; }
    }
}