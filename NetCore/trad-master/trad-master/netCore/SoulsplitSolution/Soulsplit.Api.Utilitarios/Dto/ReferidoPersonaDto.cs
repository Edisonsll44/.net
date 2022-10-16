using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class ReferidoPersonaDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("fechaIngreso")]
        public DateTime FechaIngreso { get; set; }
        [JsonProperty("idPersona")]
        public Guid PersonaId { get; set; }
        [JsonProperty("idReferido")]
        public Guid ReferidoId { get; set; }
        public int Accion { get; set; }
    }
}
